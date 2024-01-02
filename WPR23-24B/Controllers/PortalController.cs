using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WPR23_24B.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PortalController : ControllerBase
    {
        [Authorize(Roles = "Ervaringsdeskundige")]
        [HttpGet("ervaringsdeskundige-portal")]
        public IActionResult ErvaringsdeskundigePortal()
        {
            // Implement logic for Ervaringsdeskundige portal
            return Ok(new { Message = "Welcome to Ervaringsdeskundige Portal" });
        }

        [Authorize(Roles = "Bedrijf")]
        [HttpGet("bedrijf-portal")]
        public IActionResult BedrijfPortal()
        {
            // Implement logic for Bedrijf portal
            return Ok(new { Message = "Welcome to Bedrijf Portal" });
        }

        [HttpGet("default-portal")]
        public IActionResult DefaultPortal()
        {
            // Implement logic for Default portal
            return Ok(new { Message = "Welcome to Default Portal" });
        }
    }
}