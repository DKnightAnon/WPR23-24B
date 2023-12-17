// Models/Authenticatie/Contactpersoon_Bedrijf.cs
using System.ComponentModel.DataAnnotations;

namespace WPR23_24B.Models.Authenticatie
{
    public class Contactpersoon_Bedrijf : Gebruiker
    {
        // [Key]
        // public new int Id { get; set; }

        [Required(ErrorMessage = "Bedrijfsnaam moet ingevuld worden")]
        public required string Bedrijfsnaam { get; set; }

        [Required(ErrorMessage = "Functie moet ingevuld worden.")]
        public required string Functie { get; set; }

        public required Bedrijf Bedrijf { get; set; }

    }
}