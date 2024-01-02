using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WPR23_24B.Models.Authenticatie;

namespace WPR23_24B.Services
{
    public interface IRolService
    {
        public Task InitializeRoles();
        Task<string> GetUserRole(Gebruiker user);
    }
}