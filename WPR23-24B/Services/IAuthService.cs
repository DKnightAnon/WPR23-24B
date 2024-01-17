using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WPR23_24B.DTO;
using WPR23_24B.Models.Authenticatie;

namespace WPR23_24B.Services
{
    public interface IAuthService
    {
        Task<bool> SignInAsync(SignInDTO model);
        Task<string> GenerateJwtToken(string email);
        Task<string> GenerateRefreshToken(Gebruiker user);
        Task<RefreshResult> RefreshTokenAsync(string refreshToken);
    }
}