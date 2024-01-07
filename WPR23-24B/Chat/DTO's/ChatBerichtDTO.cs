using WPR23_24B.Chat.Models;
using WPR23_24B.Models.Authenticatie;
using WPR23_24B.Models.Authenticatie.DTOs;

namespace WPR23_24B.Chat.DTO_s
{
    public class ChatBerichtDTO
    {
        public Guid Id { get; set; }


        public DateTime postedAt { get; set; }


        public string content { get; set; }

        public GebruikerDTO verzender { get; set; }

        public ChatRoom room { get; set; }

    }
}
