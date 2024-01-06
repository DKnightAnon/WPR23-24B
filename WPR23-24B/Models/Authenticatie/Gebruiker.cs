using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using WPR23_24B.Chat.Models;

namespace WPR23_24B.Models.Authenticatie
{

    /// <summary>
    /// Model class for application users. Inheretis from <see cref="IdentityUser"/>.
    /// </summary>
    public class Gebruiker : IdentityUser

    {
<<<<<<< HEAD


        [Required(ErrorMessage ="Een naam moet ingevuld worden.")]
        [StringLength(50)]
        public string Voornaam { get; set; }


=======
>>>>>>> main
        [Required(ErrorMessage = "Een naam moet ingevuld worden.")]
        [StringLength(50)]
        public virtual string Naam { get; set; }

        [Required(ErrorMessage = "Een postcode moet ingevuld worden.")]
        [StringLength(50)]
        public string? Postcode { get; set; }

        [Required]
        //RegularExpression limits the allowed inputs to the specified characters
<<<<<<< HEAD
        [RegularExpression("^[0-9]{10}$", ErrorMessage ="Telefoonnummer moet 10 cijfers lang zijn, en starten met 06 .")]
        public string Telefoon_Nummer { get; set; }

        //Used for concurrency. Concurrency is a technique used to prevent two suers from updating the same record at the same time.
        //[Timestamp]
        //public byte[] Timestamp { get; set; }

        public ICollection<ChatRoom>? Gesprekken {  get; set; }

        public override string ToString()
        {
            return new string($"{UserName ?? Voornaam}");
        }

=======
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Telefoonnummer moet 10 cijfers lang zijn, en starten met 06 .")]
        public string TelefoonNummer { get; set; }
>>>>>>> main
    }
}
