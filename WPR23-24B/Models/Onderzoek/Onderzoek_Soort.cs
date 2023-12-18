using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WPR23_24B.Models.Onderzoek
{
    // Representeert het type onderzoek met gerelateerde eigenschappen.
    public class Onderzoek_Soort
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Een naam voor het onderzoekstype moet ingevuld worden.")]
        public string Naam { get; set; }

        // public List<Onderzoek_Soort_Link> OnderzoekSoortLinks { get; set; }
    }
}