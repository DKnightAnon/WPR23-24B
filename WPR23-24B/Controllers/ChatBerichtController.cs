using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WPR23_24B.Chat;
using WPR23_24B.Chat.Models;

namespace WPR23_24B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatBerichtController : ControllerBase
    {
        private readonly ChatContext _context;

        public ChatBerichtController(ChatContext context)
        {
            _context = context;
        }

        [HttpGet("Gesprek/{id}")]
        public async Task<ActionResult<IEnumerable<ChatBericht>>> GetMessagesFromRoom(string gesprekId) 
        {
             return await _context.ChatBericht.Where(bericht => bericht.room.Id.ToString() == gesprekId).ToListAsync();

        }

        // GET: api/ChatBericht
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChatBericht>>> GetChatBericht()
        {
          if (_context.ChatBericht == null)
          {
              return NotFound();
          }
            
            
            var MessageList = await _context.ChatBericht.ToListAsync();
            foreach (ChatBericht chat in MessageList) { Console.WriteLine(chat); }



            return MessageList;
        }

        // GET: api/ChatBericht/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChatBericht>> GetChatBericht(int id)
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
