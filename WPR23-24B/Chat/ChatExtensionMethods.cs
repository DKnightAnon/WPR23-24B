using Microsoft.CodeAnalysis.CSharp.Syntax;
using WPR23_24B.Chat.DTO_s;
using WPR23_24B.Chat.Models;
using WPR23_24B.Models.Authenticatie;
using WPR23_24B.Models.Authenticatie.Extensions;

namespace WPR23_24B.Chat
{
    /// <summary>
    /// Statuc ckass containing extension methods for the WPR23-24B.Chat namespace.
    /// </summary>
    public static class ChatExtensionMethods
    {

        /// <summary>
        /// Extension method to convert a <see cref="ChatMessageDTO"/> to a <see cref="ChatBericht"/> .
        /// </summary>
        /// <param name="chat"></param>
        /// <returns> A <see cref="ChatBericht"/> containing the values of the supplied <see cref="ChatMessageDTO"/> properties.  </returns>
        public static ChatBericht ToChatBericht(this ChatMessageDTO chat) 
        {
            //Guid roomParsedId = ne

            ChatBericht convertedChat = new ChatBericht() 
                {
                    content = chat.message,
                    verzender =  new Gebruiker { Id = chat.verzenderId},
                    room = chat.roomId,
                    postedAt = DateTime.UtcNow
                       
                    

                };
            return convertedChat;
        }


        /// <summary>
        /// Extension method to convert a <see cref="ChatBericht"/> to a <see cref="ChatMessageDTO"/>.
        /// </summary>
        /// <param name="chat"></param>
        /// <returns> A <see cref="ChatMessageDTO"/> containing the values of the supplied <see cref="ChatBericht"/> properties.  </returns>
        public static ChatMessageDTO ToDTO (this ChatBericht chat) 
        {
            ChatMessageDTO convertedMessage = new ChatMessageDTO()
            {
                message = chat.content,
                verzenderId = chat.verzender.Id,
                roomId = chat.room              
            };

            return convertedMessage;
        }

        public static ChatBerichtDTO ChildrenToDTO(this ChatBericht chat) 
        {
            ChatBerichtDTO convertedChat = new ChatBerichtDTO() 
            {
                Id = chat.Id,
                postedAt = chat.postedAt,
                content = chat.content,
                room = chat.room ?? null,
                verzender =chat.verzender.ToDTO() ?? null 
            };
            return convertedChat;
        }

    }
}
