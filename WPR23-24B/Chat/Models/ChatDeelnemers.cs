using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WPR23_24B.Models.Authenticatie;

namespace WPR23_24B.Chat.Models
{
    public class ChatDeelnemers
    {

        public string? GebruikerId { get; set; }

        public Gebruiker Gebruiker { get; set; }


       
        public Guid? RoomId { get; set; }
        public ChatRoom ChatRoom { get; set; }


    }
}
