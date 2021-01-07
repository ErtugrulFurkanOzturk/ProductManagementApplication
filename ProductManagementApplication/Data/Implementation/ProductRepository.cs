using Data.DataContext;
using Data.DataContracts;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Implementation
{
    public class ProductRepository:  Repository<Product> ,IProductRepository
    {
        private readonly ProductManagementApplicationDbContext _db;
        public ProductRepository(ProductManagementApplicationDbContext db): base(db)
        {
            _db = db;
        }
    }
}
