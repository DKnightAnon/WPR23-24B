using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WPR23_24B.Models.Onderzoek;

namespace WPR23_24B.Models.Authenticatie
{
    public class Bedrijf
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Bedrijfsnaam moet ingevuld worden.")]
        public string Bedrijfsnaam { get; set; }

        [Required(ErrorMessage = "Locatie moet ingevuld worden.")]
        public string Locatie { get; set; }

        [Required(ErrorMessage = "Website moet ingevuld worden.")]
        [Url]
        public string Website { get; set; }
        public string TrackingID { get; set; }
        
        public void UpdateProfile(string nieuweLocatie, string nieuweWebsite)
        {
            Locatie = nieuweLocatie;
            Website = nieuweWebsite;
        }

        // TODO:
        // Voeg andere methode of properties voor Bedrijf

        //Navigation properties

        //Navigatie voor de 1 op veel relatie met onderzoek. Namespace/ class
        public List<Onderzoek.Onderzoek> Onderzoeken { get; set; }

        //Relatie met contactpersoon
        public List<Contactpersoon_Bedrijf> Contactpersonen { get; set; }


    }
}
