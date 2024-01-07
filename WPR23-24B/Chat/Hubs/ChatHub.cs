using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using System;
using WPR23_24B.Chat.DTO_s;
using WPR23_24B.Chat.Models;
using WPR23_24B.Data;
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

        private readonly ApplicationDbContext _dbContext;
        public ChatHub(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

       
        /// <summary>
        ///  If a client connects to the hub, this method is executed. It increments the parameter
        /// </summary>
        /// <returns></returns>
        public async Task newUserAccess()
        {
            TotalViews++;
            await Clients.All.SendAsync("updateTotalViews", TotalViews);
            
        }



 //Connections

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



        public async Task JoinRoom(ChatRoomDTO roomname) 
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomname.Id.ToString());
            string message = $"{Context.ConnectionId} has joined the group {roomname.Title} with Id {roomname.Id.ToString()}.";

            await Clients.Group(roomname.Id.ToString()).SendAsync("RoomNotification", message);
            Console.WriteLine(roomname);
            Console.WriteLine(message);
        }

        public async Task LeaveRoom(string roomname)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomname);

            string message = $"{Context.ConnectionId} has left the group {roomname}.";

            await Clients.Group(roomname).SendAsync("RoomNotification", message);

            Console.WriteLine(message);
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
            await Clients.All.SendAsync("ReceiveMessage", 
                new {
                    verzender = message.User, 
                    content = message.Message, 
                    postedAt = message.TimeStamp,
                    //room = message.
                }
                );
            Console.WriteLine($"Received Message!       | Sender : {message.User}| Message:{message.Message} | TimePosted : {message.TimeStamp}");

        }

        //With the below attribute it should be possible to give the .invoke method on client side and the method on serverside(below) different names.
        //[HubMethodName("SendGroupMessage")]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="roomname"></param>
        /// <returns>Sends a <see cref="ChatMessage"/> to the client as a JSON string after saving the message to the database. </returns>
        public async Task SendGroupMessage(ChatMessage message, ChatRoom roomname)
        {
            //Console.WriteLine(message);
            //await saveMessageToDB(message);

            if (checkIfDbExist())
            {


                ChatBericht convertedChat = new ChatBericht()
                {

                    content = message.Message,
                    verzender = await _dbContext.Gebruikers.FindAsync(message.User.Id),
                    room = await _dbContext.ChatRoom.FindAsync(roomname.Id),
                };


                _dbContext.ChatBericht.Add(convertedChat);



                await _dbContext.SaveChangesAsync();
            }



            await Clients.Group(roomname.Id.ToString()).SendAsync(
                "ReceiveGroupMessage",
                 new {
                     verzender = message.User,
                     content = message.Message,
                     postedAt = message.TimeStamp, 
                     room = roomname
                 }
                 
                );
            Console.WriteLine($"Message received!       | Sender : {message.User} | Room : {roomname} | Message : {message.Message} | TimePosted : {message.TimeStamp.ToLocalTime()}");
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

        private bool checkIfDbExist() {
        
            if (_dbContext.ChatBericht == null) { return false; }
            else { return true; }

        }

        private async Task saveMessageToDB(ChatMessage message) 
        {
            if (checkIfDbExist())
            {


                ChatBericht convertedChat = new ChatBericht()
                {

                    content = message.Message,
                    verzender = await _dbContext.Gebruikers.FindAsync(message.User.Id),
                    room = await _dbContext.ChatRoom.FindAsync(message.room.Id),
                };


                _dbContext.ChatBericht.Add(convertedChat);



                await _dbContext.SaveChangesAsync();
            }

        }
    }
}
