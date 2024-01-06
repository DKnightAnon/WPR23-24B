using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WPR23_24B.Services
{
    public interface IJwtService
    {
        string GenerateJwtToken(string email, IEnumerable<Claim> claims);

    }
}