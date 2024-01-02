using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WPR23_24B.DTO
{
    public class RegisterOver18DTO
    {
        public required string Email { get; set; }
        public required string Wachtwoord { get; set; }
        public required string Naam { get; set; }
        public required string Postcode { get; set; }
        public DateTime? GeboorteDatum { get; set; }
        public required string TelefoonNummer { get; set; }
        public bool IsJongerDan18 { get; set; }
        public bool FysiekeBeperking { get; set; }
        public bool AuditieveBeperkin { get; set; }
        public bool VisueleBeperking { get; set; }
        public string? AndereBeperking { get; set; }
        public bool BenaderingTelefonisch { get; set; }
        public bool BenaderingPortal { get; set; }
        public bool BenaderingCommercieel { get; set; }
    }
}