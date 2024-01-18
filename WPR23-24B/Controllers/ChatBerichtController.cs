using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WPR23_24B.Chat;
using WPR23_24B.Chat.DTO_s;
using WPR23_24B.Chat.Models;
using WPR23_24B.Models.Authenticatie.Extensions;
using WPR23_24B.Chat.DTO_s;
using WPR23_24B.Data;
using Microsoft.AspNetCore.Authorization;

namespace WPR23_24B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatBerichtController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ChatBerichtController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("ChatRoom")]
        //This has no different name because URL parameters are used. If you make the method accept a paramter as below, the framework automatically binds values from the query string even without the [FromQuery] attribute.
        public async Task<ActionResult<IEnumerable<ChatBerichtDTO>>> GetMessagesFromRoom(
            [FromQuery(Name = "Id")]Guid gesprekId) 
        {
            //Retrieve messages as list
            var MessageList = await _context.ChatBericht.Include(bericht => bericht.room).Include(bericht => bericht.verzender).ToListAsync();


            //Convert message properties to DTO's to prevent exposing data
            var ConvertededMessageList = new List<ChatBerichtDTO>();
            foreach (var message in MessageList)
            {
                //Custom extension method for ChatBericht.
                ConvertededMessageList.Add(message.ChildrenToDTO());
            }




            return ConvertededMessageList;

        }

        // GET: api/ChatBericht
        [Authorize(Roles = "Bedrijf")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChatBerichtDTO>>> GetAllChatBericht()
        {
          if (_context.ChatBericht == null)
          {
              return NotFound();
          }
            
            //Retrieve messages as list
            var MessageList = await _context.ChatBericht.Include(bericht => bericht.room).Include(bericht => bericht.verzender).ToListAsync();


            //Convert message properties to DTO's to prevent exposing data
            var ConvertededMessageList = new List<ChatBerichtDTO>();
            foreach (var message in MessageList) 
            {
                                                   //Custom extension method for ChatBericht.
                ConvertededMessageList.Add(message.ChildrenToDTO());
            }
            



            return ConvertededMessageList;
        }

        // GET: api/ChatBericht/5
        [Authorize(Roles = "Ervaringsdeskundige")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ChatBericht>> GetChatBericht(Guid id)
        {
          if (_context.ChatBericht == null)
          {
              return NotFound();
          }
            var chatBericht = await _context.ChatBericht.FindAsync(id);

            if (chatBericht == null)
            {
                return NotFound();
            }

            return Ok(chatBericht);
        }


        [Authorize(Roles = "Ervaringsdeskundige,Bedrijf")]
        [HttpGet("AuthorizeTest")]
        public async Task<string> authorizeTest() 
        {

            return new string("Authorize werkt correct");
        }


        // PUT: api/ChatBericht/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChatBericht(Guid id, ChatBericht chatBericht)
        {
            if (id != chatBericht.Id)
            {
                return BadRequest();
            }

            _context.Entry(chatBericht).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatBerichtExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ChatBericht
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChatBericht>> PostChatBericht(ChatMessageDTO chat)
        {
          if (_context.ChatBericht == null)
          {
              return Problem("Entity set 'ChatContext.ChatBericht'  is null.");
          }

          //ChatBericht convertedChat = chat.ToChatBericht();

         

          ChatBericht convertedChat = new ChatBericht() 
          {
              postedAt = DateTime.UtcNow,
              content = chat.message,
              verzender = await _context.Gebruikers.FindAsync(chat.verzenderId),
              room = await _context.ChatRoom.FindAsync(chat.roomId.Id),
          };


            _context.ChatBericht.Add(convertedChat);



            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChatBericht", new { id = convertedChat.Id }, convertedChat);
        }

        // DELETE: api/ChatBericht/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChatBericht(int id)
        {
            if (_context.ChatBericht == null)
            {
                return NotFound();
            }
            var chatBericht = await _context.ChatBericht.FindAsync(id);
            if (chatBericht == null)
            {
                return NotFound();
            }

            _context.ChatBericht.Remove(chatBericht);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChatBerichtExists(Guid id)
        {
            return (_context.ChatBericht?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
