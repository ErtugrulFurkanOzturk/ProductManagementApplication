using Business.Contracts;
using Common.Dtos;
using Common.ResultConstant;
using Data.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Implementation
{
    public class ProductBusinessEngine : IProductBusinessEngine
    {
        private readonly IUnitOfWork _uow;

        public ProductBusinessEngine(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public Result<List<ProductDto>> GetProducts()
        {
            List<ProductDto> products = new List<ProductDto>();
            var data = _uow.products.GetAll().ToList();
            if (data != null)
            {
                foreach (var item in data)
                {
                    products.Add(new ProductDto()
                {
                Code=item.Code,
                Title=item.Title,
                        Description=item.Description,
                        Stoke=item.Stoke,
                        Price=item.Price,
                        Image=item.Image
                    });
                }
                return new Result<List<ProductDto>>(true, ResultConstant.RecordFound, products);
            }
            return new Result<List<ProductDto>>(false, ResultConstant.RecordNotFound);
        }
    }
}
