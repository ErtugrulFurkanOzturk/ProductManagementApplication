using Common.Dtos;
using Common.ResultConstant;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IApplicationUserBusinessEngine
    {
        Task<Result<object>> CreateApplicationUser(ApplicationUserDto model);
    }
}
