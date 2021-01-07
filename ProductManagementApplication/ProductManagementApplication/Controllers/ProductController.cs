using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Contracts;
using Common.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagementApplication.Controllers
{
    [Route("api/[Product]")]
    [ApiController]
    public class ProductController : ControllerBase //to taking database tables
    {
        private readonly IProductBusinessEngine _productBusiness;

        public ProductController(IProductBusinessEngine productBusiness)
        {
            _productBusiness = productBusiness;
        }
        [HttpGet("GetProducts")]
        public List<ProductDto> GetProducts()
        {
            return _productBusiness.GetProducts().Data;
        }
    }
}
