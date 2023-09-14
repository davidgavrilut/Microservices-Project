using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CommandsService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        public PlatformsController()
        { }

        [HttpPost]
        public ActionResult TestInbound()
        {
            Console.WriteLine("--> Inbound Post # Command Service");
            return Ok("Inbound test ok from Platforms Controller"); 
        }

    }
}
