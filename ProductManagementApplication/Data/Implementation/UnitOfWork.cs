using Data.DataContracts;
using Data.DataContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductManagementApplicationDbContext _db;
        public UnitOfWork(ProductManagementApplicationDbContext db)
        {
            _db = db;
            products = new ProductRepository(_db);
        }

        public IProductRepository products { get; private set; }
        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
