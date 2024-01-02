using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WPR23_24B.DTO;
using WPR23_24B.Services;

namespace WPR23_24B.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistratieController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public RegistratieController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost("ervaringsdeskundige/registerUnder18")]
        public async Task<IActionResult> RegisterUnder18(RegisterUnder18DTO model)
        {

            var result = await _registrationService.RegisterUnder18Async(model);

            if (result.Succeeded)
            {
                return Ok("Registration successful");
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("ervaringsdeskundige/registerOver18")]
        public async Task<IActionResult> RegisterOver18(RegisterOver18DTO model)
        {

            var result = await _registrationService.RegisterOver18Async(model);

            if (result.Succeeded)
            {
                return Ok("Registration successful");
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("bedrijf/register")]
        public async Task<IActionResult> RegisterCompany(RegisterCompanyDTO model)
        {
            var result = await _registrationService.RegisterCompanyAsync(model);

            if (result.Succeeded)
            {
                return Ok("Company registration successful");
            }

            return BadRequest(result.Errors);
        }
    }
}