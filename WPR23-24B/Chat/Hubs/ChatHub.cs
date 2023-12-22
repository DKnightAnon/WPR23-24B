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



        /// <summary>
        /// Method that is called when a user opens a react component that implements signalr.
        /// </summary>
        /// <returns></returns>
        public override async Task OnConnectedAsync() 
        {
            await Clients.All.SendAsync("UserJoinMessage", $"{Context.ConnectionId} has joined!");
            TotalViews++;
            await Clients.All.SendAsync("UserChange", TotalViews ); 

        }

        /// <summary>
        /// Method that is called when a user disconnects from a chat. 
        /// This is usually done by either exiting the website or reloading on any non-chat page.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Clients.All.SendAsync("UserLeftMessage", $"A user has left!");
            TotalViews--;
            await Clients.All.SendAsync("UserChange", TotalViews);
        }

        public async Task OnRoomJoin(ChatRoom room)
        {
            throw new NotImplementedException();
           // await Groups.AddToGroupAsync(Context.ConnectionId, ro)

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
            //message.TimeStamp = DateTime.UtcNow;

            //Timestamp wasn't arriving at client. Circumvented this by sending an anonymous type.
            await Clients.All.SendAsync("ReceiveMessage", new {user = message.User, message = message.Message, timestamp = message.TimeStamp});
            //Console.WriteLine($"Received Message!       Sender : {message.User}| Message:{message.Message} | TimePosted : {message.TimeStamp}");

        }


        /// <summary>
        /// Method to send a chatmessage to a specified group. The basis for group-based chatting.
        /// </summary>
        /// <param name="groupname"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendMessageToGroup(string groupname, ChatMessage message) 
        {
            await Clients.Group(groupname).SendAsync("ReceiveGroupMessage",message);
        }

        public async Task SendToAll(string name, string message) 
        {
            await Clients.All.SendAsync("sendToAll", name, message);
            
        }
    }
}
