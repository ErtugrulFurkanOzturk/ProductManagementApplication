using Common.Dtos;
using Common.ResultConstant;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Contracts
{
    public interface IProductBusinessEngine
    {
        Result<List<ProductDto>> GetProducts();
    }
}
