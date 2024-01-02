using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WPR23_24B.Models.Medisch;

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
        public int? VoogdId { get; set; } // Buitenlandse sleutel naar Voogd
        public Voogd? Voogd { get; set; }

        // Informatie betreffende zijn/haar beperkingen
        public bool FysiekeBeperking { get; set; }
        public bool AuditieveBeperkin { get; set; }
        public bool VisueleBeperking { get; set; }
        public string? AndereBeperking { get; set; }
        public List<Beperking> beperkingen { get; set; }
        public List<Hulpmiddel> hulpmiddellen { get; set; }
    }
}
