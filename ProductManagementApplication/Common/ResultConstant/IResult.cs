using System;
using System.Collections.Generic;
using System.Text;

namespace Common.ResultConstant
{
    public interface IResult
    {
        bool IsSuccess { get; set; }
        string Message { get; set; }
    }
}
