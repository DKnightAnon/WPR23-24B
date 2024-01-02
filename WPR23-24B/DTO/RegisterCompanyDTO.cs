using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WPR23_24B.DTO
{
    public class RegisterCompanyDTO
    {
        [Required(ErrorMessage = "E-mail is verplicht")]
        [EmailAddress(ErrorMessage = "Ongeldig e-mailadres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Wachtwoord is verplicht")]
        [StringLength(100, ErrorMessage = "Het {0} moet minimaal {2} tekens lang zijn.", MinimumLength = 6)]
        public string Wachtwoord { get; set; }

        [Required(ErrorMessage = "Naam is verplicht")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "Locatie is verplicht")]
        public string Postcode { get; set; }

        [Required(ErrorMessage = "Website is verplicht")]
        [Url(ErrorMessage = "Ongeldige URL-indeling")]
        public string Website { get; set; }

        [Required(ErrorMessage = "TrackingId is verplicht")]
        public string TrackingId { get; set; }

        [Required(ErrorMessage = "Telefoonnummer is verplicht")]
        public string TelefoonNummer { get; set; }

        [Required(ErrorMessage = "Contactpersoon is verplicht")]
        public string Contactpersoon { get; set; }
    }
}