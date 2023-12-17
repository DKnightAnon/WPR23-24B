using System.ComponentModel.DataAnnotations;
using WPR23_24B.Models.Authenticatie;

namespace WPR23_24B.Models.Medisch
{
    public class Hulpmiddel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Een Hulpmiddel moet een naam hebben.")]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Doel { get; set; }


        public List<Gebruiker> gebruikers { get; set; }
    }
}
