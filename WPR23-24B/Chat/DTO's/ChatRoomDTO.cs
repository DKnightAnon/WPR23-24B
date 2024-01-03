namespace WPR23_24B.Chat.DTO_s
{
    public class ChatRoomDTO
    {

        public Guid Id { get; set; }
        public string Title { get; set; }


        public override string ToString()
        {
            return new string($"{Title}");
        }
    }
}
