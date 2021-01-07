using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Contracts;
using Common.Dtos;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagementApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly IApplicationUserBusinessEngine _applicationUserEngine;
        public ApplicationUserController(IApplicationUserBusinessEngine applicationUserEngine)
        {
            _applicationUserEngine = applicationUserEngine;
        }

        [HttpGet("Index")]
        
        public IActionResult Index()
        {
            
            return Ok();
        }


         [HttpPost]
         [Route("Register")]
        public async Task<Object> PostApplicationUser(ApplicationUserDto model)
        {
            var data = _applicationUserEngine.CreateApplicationUser(model);
            var result = data.Result.Data;
            return Ok(result);
        }
    }
}
