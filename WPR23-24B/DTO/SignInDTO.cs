using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WPR23_24B.DTO
{
    public class SignInDTO
    {
        [EmailAddress]
        [Required(ErrorMessage = "Emailadress is verplicht.")]
        public string? Email { get; init; }


        [Required(ErrorMessage = "Wachtwoord is verplicht.")]
        public string? Password { get; init; }
    }
}