using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WPR23_24B.Models.Authenticatie
{
    public class Bedrijf : Gebruiker
    {
        [Required(ErrorMessage = "Telefoonnummer moet ingevuld worden.")]
        public new string? TelefoonNummer { get; set; }

        [Required(ErrorMessage = "Locatie moet ingevuld worden.")]
        public string Locatie { get; set; }

        [Required(ErrorMessage = "Website moet ingevuld worden.")]
        [Url]
        public string Website { get; set; }

        [Required(ErrorMessage = "TrackingID moet ingevuld worden.")]
        public string TrackingID { get; set; }

        public string? ContactPersoon { get; set; }

        //Navigatie voor de 1 op veel relatie met onderzoek. Namespace/ class
        // public List<Onderzoek.Onderzoek>? Onderzoeken { get; set; }

        //Relatie met contactpersoon
        public List<Contactpersoon_Bedrijf>? Contactpersonen { get; set; }


    }
}
