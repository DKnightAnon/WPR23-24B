using System.ComponentModel.DataAnnotations;
using WPR23_24B.Models.Authenticatie;

namespace WPR23_24B.Models.Medisch
{
    public class Beperking
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Een beperking moet een naam hebben.")]
        [StringLength(100)]
        public string Name { get; set; }    
        public List<Gebruiker> GebruikerList { get; set; }

    }
}
