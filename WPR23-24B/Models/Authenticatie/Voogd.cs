using System.ComponentModel.DataAnnotations;

namespace WPR23_24B.Models.Authenticatie
{
    public class Voogd
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z]", ErrorMessage ="Een naam mag geen cijfers bevatten.")]
        public string Voornaam { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z]", ErrorMessage = "Een naam mag geen cijfers bevatten.")]
        public string Achternaam { get; set; }

        [Required]
        public string PostCode { get; set; }
    }
}
