using System.ComponentModel.DataAnnotations;
using WPR23_24B.Models.Authenticatie;

namespace WPR23_24B.Chat
{
    public class ChatBericht
    {
        [Key]
        public int Id { get; set; }


        public DateTime postedAt { get; set; }


        public string content { get; set; }

        [Required]
        public Gebruiker verzender { get; set; }

        public ChatBericht() 
        {
            postedAt = DateTime.UtcNow;
        }
    }
}
