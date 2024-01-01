using Microsoft.CodeAnalysis.CSharp.Syntax;
using WPR23_24B.Models.Authenticatie.DTOs;

namespace WPR23_24B.Models.Authenticatie.Extensions
{
    public static class GebruikerExtensions
    {
        public static GebruikerDTO ToDTO(this Gebruiker gebruiker) 
        {
            GebruikerDTO convertedGebruiker= new GebruikerDTO 
            {
                Id = gebruiker.Id,
                UserName = gebruiker.UserName
            };
            return convertedGebruiker;
        }
    }
}
