using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CommandServics.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult TestInboundConnetion()
        {

            Console.WriteLine("--> Inbound POST　＃ Command Service");

            return Ok("Inbound test of from Platforms Controller");
        }


    }
}
