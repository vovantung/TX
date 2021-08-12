using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TX.ViewModels.Common;
using TX.ViewModels.Login;

namespace TX.Admin.Services
{
    public interface IUserApiClient
    {
        //Task<string> Authenticate(LoginRequest request);
        Task<ApiResult<string>> Authenticate(LoginRequest request);

    }
}
