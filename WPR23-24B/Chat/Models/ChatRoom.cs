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

        //JsonIgnore to prevent a json loop from occuring.
        //This seems to create an infinite loop of sorts where room points to message points to room ad infinitum.
        [JsonIgnore]
        public ICollection<ChatBericht>? Messages { get; set; }

        [JsonIgnore]
        public ICollection<Gebruiker>? gebruikers { get; set; }

        public ChatRoom() { }

        public override string ToString()
        {
            return new string($"{Title}");
        }
    }
}
