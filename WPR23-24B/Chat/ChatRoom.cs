using System.ComponentModel.DataAnnotations;

namespace WPR23_24B.Chat
{
    public class ChatRoom
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }



        public ChatRoom() { }
    }
}
