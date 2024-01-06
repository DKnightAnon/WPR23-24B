// Models/Authenticatie/Contactpersoon_Bedrijf.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WPR23_24B.Models.Authenticatie
{
    public class Contactpersoon_Bedrijf
    {
        [Key]
        public new int Id { get; set; }

        [Required(ErrorMessage = "Naam moet ingevuld worden")]
        public required string ContactPersoonNaam { get; set; }

        // Navigatie properties voor een associatie met Bedrijf
        [ForeignKey("BedrijfId")]
        public string BedrijfId { get; set; }
        public required Bedrijf Bedrijf { get; set; }

    }
}