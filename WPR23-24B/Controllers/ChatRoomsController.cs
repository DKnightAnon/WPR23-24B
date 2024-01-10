using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using WPR23_24B.Chat;
using WPR23_24B.Chat.DTO_s;
using WPR23_24B.Chat.Models;
using WPR23_24B.Data;

namespace WPR23_24B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatRoomsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ChatRoomsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ChatRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChatRoom>>> GetChatRoom()
        {
            if (_context.ChatRoom == null)
            {
                return NotFound();
            }
           

            
            // Om networklatency na te bootsen
            //await Task.Delay(5000);
            
            
            return await _context.ChatRoom.ToListAsync();
        }

        // GET: api/ChatRooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChatRoom>> GetChatRoom(Guid id)
        {
            if (_context.ChatRoom == null)
            {
                return NotFound();
            }
            var chatRoom = await _context.ChatRoom.FindAsync(id);

            if (chatRoom == null)
            {
                return NotFound();
            }

            return chatRoom;
        }


        [HttpGet("berichten/{id}")]
        public async Task<ActionResult<IEnumerable<ChatBerichtDTO>>> GetChatRoomMessages(Guid id)
            {
            if (_context.ChatRoom == null)
            {
                return NotFound();
            }
            var chatRoom = await _context.ChatRoom.FindAsync(id);

            if (chatRoom == null)
            {
                return NotFound();
            }



            //Retrieve messages as list
            var MessageList = await _context.ChatBericht.Include(bericht => bericht.verzender).Where(bericht => bericht.room.Id == id).ToListAsync();

            //Convert message properties to DTO's to prevent exposing data
            var ConvertededMessageList = new List<ChatBerichtDTO>();
            foreach (var message in MessageList)
            {
                //Custom extension method for ChatBericht.
                ConvertededMessageList.Add(message.ChildrenToDTO());
            }



            return ConvertededMessageList;

            //return await _context.ChatBericht.Where(berichten => berichten.Id == id).ToListAsync();

        }


        // PUT: api/ChatRooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChatRoom(Guid id, ChatRoom chatRoom)
        {
            if (id != chatRoom.Id)
            {
                return BadRequest();
            }

            _context.Entry(chatRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatRoomExists(id))
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

        // POST: api/ChatRooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChatRoom>> PostChatRoom(ChatRoom chatRoom)
        {
          if (_context.ChatRoom == null)
          {
              return Problem("Entity set 'ChatContext.ChatRoom'  is null.");
          }
            _context.ChatRoom.Add(chatRoom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChatRoom", new { id = chatRoom.Id }, chatRoom);
        }

        // DELETE: api/ChatRooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChatRoom(Guid id)
        {
            if (_context.ChatRoom == null)
            {
                return NotFound();
            }
            var chatRoom = await _context.ChatRoom.FindAsync(id);
            if (chatRoom == null)
            {
                return NotFound();
            }

            _context.ChatRoom.Remove(chatRoom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("RoomTimestamp/{id}")]
        public async Task<IActionResult> GetLastMessageTimeStamp(Guid id) 
        {
            if (_context.ChatRoom == null)
            {
                return NotFound();
            }
            var chatRoom = await _context.ChatRoom.FindAsync(id);
            if (chatRoom == null)
            {
                return NotFound();
            }

            DateTime timestamp = _context.ChatBericht.Where(bericht => bericht.room.Id == id).Select(bericht => bericht.postedAt).LastOrDefault();
             return Ok(timestamp);
        }

        private bool ChatRoomExists(Guid id)
        {
            return (_context.ChatRoom?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
