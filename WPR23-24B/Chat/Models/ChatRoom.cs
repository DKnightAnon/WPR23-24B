using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WPR23_24B.Models.Authenticatie;

namespace WPR23_24B.Chat.Models
{
    public class ChatRoom
    {

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [JsonIgnore]
        public ICollection<ChatBericht>? Messages { get; set; }

        [JsonIgnore]
        public ICollection<Gebruiker>? gebruikers { get; set; }

        public ChatRoom() { }
    }
}
