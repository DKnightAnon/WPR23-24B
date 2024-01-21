using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WPR23_24B.Models.Authenticatie;

namespace WPR23_24B.Models.Medisch
{
    public class ErvaringsdeskundigeBeperking
    {
        public string ErvaringsdeskundigeId { get; set; }
        public Ervaringsdeskundige Ervaringsdeskundige { get; set; }

        public int BeperkingId { get; set; }
        public Beperking Beperking { get; set; }
    }
}