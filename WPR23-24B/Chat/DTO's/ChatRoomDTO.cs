namespace WPR23_24B.Chat.DTO_s
{
    public class ChatRoomDTO
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = "Title is empty!";


        public override string ToString()
        {
            return new string($"{Title}|{Id}");
        }
    }
}
