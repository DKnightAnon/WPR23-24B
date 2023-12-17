using WPR23_24B.Models.Authenticatie;

namespace WPR23_24B.Chat.Hubs
{

    //Interface to list all required methods.
    public interface IChatHub
    {
        public Task SendChatMessage(Gebruiker gebruiker, ChatBericht bericht, ChatRoom room);

        public Task OnRoomJoin(ChatRoom room);

        public Task OnConnectedAsync();


    }
}
