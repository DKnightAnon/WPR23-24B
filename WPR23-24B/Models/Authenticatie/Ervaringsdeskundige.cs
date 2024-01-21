using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WPR23_24B.Models.Medisch;
using WPR23_24B.Models.Onderzoek;

namespace WPR23_24B.Models.Authenticatie
{
    public class Ervaringsdeskundige : Gebruiker
    {
        public DateTime? GeboorteDatum { get; set; }
        public bool BenaderingTelefonisch { get; set; }
        public bool BenaderingPortal { get; set; }
        public bool BenaderingCommercieel { get; set; }
        public bool IsJongerDan18 { get; set; }

        // Informatie betreffende zijn/haar voogd
        [ForeignKey("VoogdId")]
        public int? VoogdId { get; set; }
        public Voogd? Voogd { get; set; }

        // Navigation properties for related entities
        public List<ErvaringsdeskundigeBeperking> ErvaringsdeskundigeBeperkingen { get; set; }
        public List<ErvaringsdeskundigeOnderzoek> EnrolledOnderzoeken { get; set; }
        public List<ErvaringsdeskundigeHulpmiddel> ErvaringsdeskundigeHulpmiddelen { get; set; }

    }
}
