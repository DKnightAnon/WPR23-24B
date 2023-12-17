using Microsoft.AspNetCore.SignalR;
using WPR23_24B.Models.Authenticatie;

namespace WPR23_24B.Chat.Hubs
{
    /// <summary>
    /// A hub class responsible for user interaction.
    /// </summary>
    public class ChatHub : Hub, IChatHub
    {

        public static readonly List<Gebruiker> _connectedUsers = new List<Gebruiker>();

        /// <summary>
        /// Parameter used to keep track of the amount of users on the page/ 
        /// </summary>
        public static int TotalViews { get; set; } = 0;

       
        /// <summary>
        ///  If a client connects to the hub, this method is executed. It increments the parameter
        /// </summary>
        /// <returns></returns>
        public override async Task OnConnectedAsync()
        {
            TotalViews++;
            await Clients.All.SendAsync("updateTotalViews", TotalViews);
            
        }

        public async Task OnRoomJoin(ChatRoom room)
        {
            throw new NotImplementedException();
        }

        public async Task SendChatMessage(Gebruiker gebruiker, ChatBericht bericht, ChatRoom room)
        {
            throw new NotImplementedException();
        }

        public async Task SendChatMessage(string user, string message) 
        {
           await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task SendTyping(object sender)
        {
            await Clients.Others.SendAsync("typing", sender);
        }



    }
}
