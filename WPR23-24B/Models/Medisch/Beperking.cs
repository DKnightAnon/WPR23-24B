using System.ComponentModel.DataAnnotations;
using WPR23_24B.Models.Authenticatie;
using WPR23_24B.Models.Onderzoek;

namespace WPR23_24B.Models.Medisch
{
    public class Beperking
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Een beperking moet een naam hebben.")]
        [StringLength(100)]
        public string Name { get; set; }

        // Navigation property for related entities
        public List<ErvaringsdeskundigeBeperking> ErvaringsdeskundigeBeperkingen { get; set; }

    }
}
