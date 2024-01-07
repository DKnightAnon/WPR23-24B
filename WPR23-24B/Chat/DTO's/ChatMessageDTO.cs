using System.ComponentModel.DataAnnotations;
using WPR23_24B.Chat.Models;

namespace WPR23_24B.Chat
{


    /// <summary>
    /// <c>Data Transfer Object</c> for sending chatmessages though the API.
    /// </summary>
    public class ChatMessageDTO
    {

        [Required]
        public string message { get; set; }

        [Required]
        public string verzenderId { get; set; }

        [Required]
        public ChatRoom roomId { get; set; }
    }
}
