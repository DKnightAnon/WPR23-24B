using System.ComponentModel.DataAnnotations;
using WPR23_24B.Models.Authenticatie;

namespace WPR23_24B.Models.Onderzoek
{
    // Representeert het resultaat van een specifiek onderzoek.
    public class OnderzoekResultaat
    {
        [Key]
        public int OnderzoekResultaatId { get; set; }

        [Required(ErrorMessage = "Resultaat moet ingevuld worden")]
        public string Resultaat { get; set; }

        public DateTime Datum { get; set; }
        public Ervaringsdeskundige Deelnemer { get; set; }
    }
}