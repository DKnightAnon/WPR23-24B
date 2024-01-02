using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WPR23_24B.Models.Authenticatie
{
    public class Gebruiker : IdentityUser
    {
        [Required(ErrorMessage = "Een naam moet ingevuld worden.")]
        [StringLength(50)]
        public string? Naam { get; set; }

        [Required(ErrorMessage = "Een postcode moet ingevuld worden.")]
        [StringLength(50)]
        public string? Postcode { get; set; }

        [Required(ErrorMessage = "Een telefoonummer moet ingevuld worden")]
        [StringLength(50)]
        public string? TelefoonNummer { get; set; }

    }
}
