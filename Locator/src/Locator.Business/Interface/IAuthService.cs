using Locator.Models.Models.Auth;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Locator.Business.Interface
{
    public interface IAuthService
    {
        Task<ResponseLogin> ProcessingLogin(LoginModel model);
        Task<ResponseRegister> ProcessingRegister(RegisterModel model);
        Task<ResponseRegister> ProcessingRegisterAdmin(RegisterModel model);
    }
}
