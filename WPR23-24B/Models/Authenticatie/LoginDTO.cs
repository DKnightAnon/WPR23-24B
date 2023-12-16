using System.ComponentModel.DataAnnotations;

namespace WPR23_24B.Models.Authenticatie
{
    //Data Transfer Object to allow the logging
    public class LoginDTO
    {
        [EmailAddress]
        [Required(ErrorMessage = "Emailadress is verplicht.")]
        public string? UserName { get; init; }

        
        [Required(ErrorMessage = "Wachtwoord is verplicht.")]
        public string? Password { get; init; }
    }
}
