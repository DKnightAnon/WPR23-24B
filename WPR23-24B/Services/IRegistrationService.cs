using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WPR23_24B.DTO;

namespace WPR23_24B.Services
{
    public interface IRegistrationService
    {
        Task<IdentityResult> RegisterUnder18Async(RegisterUnder18DTO model);
        Task<IdentityResult> RegisterOver18Async(RegisterOver18DTO model);
        Task<IdentityResult> RegisterCompanyAsync(RegisterCompanyDTO model);
    }
}