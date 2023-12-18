using WPR23_24B.Models.Medisch;

namespace WPR23_24B.Models.Authenticatie
{
    public class Ervaringsdeskundige : Gebruiker
    {

        public string Postcode { get; set; }
        public bool BenaderingTelefonisch { get; set; }
        public bool BenaderingPortal { get; set; }
        public bool BenaderingCommercieel {  get; set; }
        public Voogd? voogd { get; set; }

        public List<Beperking> beperkingen { get; set; }
        public List<Hulpmiddel> hulpmiddellen { get; set; }
    }
}
