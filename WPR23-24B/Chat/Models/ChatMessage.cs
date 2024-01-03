using WPR23_24B.Models.Authenticatie.DTOs;

namespace WPR23_24B.Chat.Models
{
    public class ChatMessage
    {
        public GebruikerDTO User { get; set; }

        public string Message { get; set; }

        public ChatRoom room { get; set; }  

        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;


        public override string ToString()
        {
            return new string($"{User},{Message},{room},{TimeStamp}");
        }


    }
}
