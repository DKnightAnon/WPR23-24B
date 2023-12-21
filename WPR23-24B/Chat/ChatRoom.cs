using System.ComponentModel.DataAnnotations;
using WPR23_24B.Models.Authenticatie;

namespace WPR23_24B.Chat
{
    public class ChatRoom
    {

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        public ICollection<ChatBericht> Messages { get; set; }

        public ICollection<Gebruiker> gebruikers { get; set; }

        public ChatRoom() { }
    }
}
