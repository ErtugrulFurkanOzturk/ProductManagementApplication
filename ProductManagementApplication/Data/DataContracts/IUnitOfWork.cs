using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DataContracts
{
    public interface IUnitOfWork:IDisposable //In order for transactions to be performed collectively through a single channel instead of reflecting any changes made in the business layer to the database or other layers instantly
    {
        IProductRepository products { get; }

        void Save();

    }
}
