using System.ComponentModel.DataAnnotations;
using WPR23_24B.Models.Authenticatie;

namespace WPR23_24B.Chat.Models
{



    /// <summary>
    /// Model class for chatmessages. This model is saved in a database.
    /// </summary>
    public class ChatBericht
    {
        [Key]
        public Guid Id { get; set; }


        public DateTime postedAt { get; set; }


        public string content { get; set; }

        [Required]
        public Gebruiker verzender { get; set; }

        public ChatRoom room { get; set; }

        public ChatBericht()
        {
            postedAt = DateTime.UtcNow;
        }

        public override string ToString()
        {
            string verzenderResult = this.verzender?.ToString() ?? "NULL";
            string roomResult = this.room?.ToString() ?? "NULL";
            return new string($"|{Id}|{postedAt}|{content}|{verzenderResult}|{roomResult}");

        }
    }
}
