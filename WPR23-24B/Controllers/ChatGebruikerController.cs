using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WPR23_24B.Chat;
using WPR23_24B.Models.Authenticatie;




namespace WPR23_24B.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class ChatGebruikerController : ControllerBase
    {
        private readonly ChatContext _context;

        public ChatGebruikerController(ChatContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gebruiker>>> GetAllGebruikers()
        {

            if (_context.Gebruiker == null)
            {
                return NotFound();
            }

            var Gebruikers = await _context.Gebruiker.ToListAsync();

            return Ok(Gebruikers);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Gebruiker>> GetGebruikerAtID(string ID) 
        {
            if (_context.Gebruiker == null) { return Problem("Entity set Gebruiker is null."); }

            var gebruiker = _context.Gebruiker.FirstOrDefault(gebruikerid => gebruikerid.Id == ID);
            return gebruiker;
        }



        [HttpPost]
        public async Task<ActionResult<Gebruiker>> PostNieuweGebruiker(Gebruiker nieweGebruiker) 
        {
            if (_context.Gebruiker == null) { return Problem("Entity set Gebruiker is null."); }

            _context.Gebruiker.Add(nieweGebruiker);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetGebruiker", new {id = nieweGebruiker.Id}, nieweGebruiker);
        }





        }
}
