using Business.Contracts;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Common.Dtos;
using Common.ResultConstant;
using System.Threading.Tasks;
using System.Linq;

namespace Business.Implementation
{
    public class ApplicationUserBusinessEngine : IApplicationUserBusinessEngine
    {
        private UserManager<ApplicationUser> _userManager;//the layer that will do the operations related to the user
        private SignInManager<ApplicationUser> _signInManager;
        public ApplicationUserBusinessEngine(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<Result<object>> CreateApplicationUser(ApplicationUserDto model)
        {
            var applicationUser = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName
            };
            try
            {
                var result = await _userManager.CreateAsync(applicationUser, model.Password);
                if (result.Errors.Count() > 0)
                {
                    return new Result<object>(false, ResultConstant.RecordNotCreated, result);
                }
                return new Result<object>(true, ResultConstant.RecordCreated,result);
        }
            catch (Exception)
            {
                return new Result<object>(false, ResultConstant.RecordNotCreated);
            }
        }
        
        
        
    }
}
