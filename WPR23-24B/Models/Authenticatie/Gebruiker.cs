using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WPR23_24B.Models.Authenticatie
{
    public class Gebruiker : IdentityUser
    {
        [Required(ErrorMessage ="Een naam moet ingevuld worden.")]
        [StringLength(50)]
        public string Voornaam { get; set; }


        [Required(ErrorMessage = "Een naam moet ingevuld worden.")]
        [StringLength(50)]
        public string Achternaam { get; set; }

        [Required(ErrorMessage = "Een Emailadres moet ingevuld worden.")]
        [EmailAddress]
        public string Email {  get; set; }

        [Required]
        //RegularExpression limits the allowed inputs to the specified characters
        [RegularExpression("^[0-9]{10}$", ErrorMessage ="Telefoonnummer moet 10 cijfers lang zijn, en starten met 06 .")]
        public string Telefoon_Nummer { get; set; }

        //Used for concurrency. Concurrency is a technique used to prevent two suers from updating the same record at the same time.
        [Timestamp]
        public byte[] Timestamp { get; set; }

    }
}
