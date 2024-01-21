using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WPR23_24B.Models.Authenticatie;

namespace WPR23_24B.Models.Onderzoek
{
    public class ErvaringsdeskundigeOnderzoek
    {
        public string ErvaringsdeskundigeId { get; set; }
        public Ervaringsdeskundige Ervaringsdeskundige { get; set; }

        public int OnderzoekId { get; set; }
        public Onderzoek Onderzoek { get; set; }
    }
}