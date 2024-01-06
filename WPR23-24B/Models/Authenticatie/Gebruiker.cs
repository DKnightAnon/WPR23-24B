﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WPR23_24B.Models.Authenticatie
{
    public class Gebruiker : IdentityUser
    {
        [Required(ErrorMessage = "Een naam moet ingevuld worden.")]
        [StringLength(50)]
        public virtual string Naam { get; set; }

        [Required(ErrorMessage = "Een postcode moet ingevuld worden.")]
        [StringLength(50)]
        public string? Postcode { get; set; }

        [Required]
        //RegularExpression limits the allowed inputs to the specified characters
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Telefoonnummer moet 10 cijfers lang zijn, en starten met 06 .")]
        public string TelefoonNummer { get; set; }
    }
}
