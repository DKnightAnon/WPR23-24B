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
        public async Task newUserAccess()
        {
            TotalViews++;
            await Clients.All.SendAsync("updateTotalViews", TotalViews);
            
        }

        public override async Task OnConnectedAsync() 
        {
            await Clients.All.SendAsync("UserJoinMessage", $"{Context.ConnectionId} has joined!");
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Clients.All.SendAsync("UserLeftMessage", $"{Context.ConnectionId} has left!");
        }

        public async Task OnRoomJoin(ChatRoom room)
        {
            throw new NotImplementedException();
        }

        public async Task SendChatMessage(Gebruiker gebruiker, ChatBericht bericht, ChatRoom room)
        {
            throw new NotImplementedException();
        }

        //public async Task SendChatMessage(string user, string message) 
        //{
        //   await Clients.All.SendAsync("ReceiveMessage", user, message);
        //}

        public async Task SendTyping(object sender)
        {
            await Clients.Others.SendAsync("typing", sender);
        }

        //public async Task SendMessage() 
        //{
        //    await Clients.All.SendAsync("SendMessage", "testmessage");
        //}

        public async Task Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            await Clients.All.SendAsync("broadcastMessage", name, message);
        }

        public async Task SendMessage(ChatMessage message)
        {
            //trigger every client that has an implementation for a ReceiveMessage method.
            await Clients.All.SendAsync("ReceiveMessage", message);
            Console.WriteLine($"Received Message!       Sender : {message.User}| Message:{message.Message} | TimePosted : {DateTime.UtcNow}");
        }

        public async Task SendToAll(string name, string message) 
        {
            await Clients.All.SendAsync("sendToAll", name, message);
            
        }
    }
}
