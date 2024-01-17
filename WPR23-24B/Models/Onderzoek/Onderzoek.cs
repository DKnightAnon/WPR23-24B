using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WPR23_24B.Models.Authenticatie;

namespace WPR23_24B.Models.Onderzoek
{
    // Representeert een specifiek onderzoek met gerelateerde eigenschappen.
    public class Onderzoek
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Een titel moet ingevuld worden.")]
        public string Titel { get; set; }

        [Required(ErrorMessage = "Een beschrijving moet ingevuld worden.")]
        public string Beschrijving { get; set; }

        [Required(ErrorMessage = "Een datum moet ingevuld worden.")]
        public DateTime Datum { get; set; }

        [Required(ErrorMessage = "Een locatie moet ingevuld worden.")]
        public string Locatie { get; set; }

        public string Status { get; set; }


        // Relationship with Onderzoek_soort
        public List<Onderzoek_Soort> OnderzoekSoorten { get; set; }

        public List<Onderzoek_Resultaat> Resultaten { get; set; }

    }
}