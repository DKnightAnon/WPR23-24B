using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WPR23_24B.DTO;

namespace WPR23_24B.Services
{
    public interface IAuthService
    {
        Task<bool> SignInAsync(SignInDTO model);
        Task<string> GenerateJwtToken(string email);
    }
}