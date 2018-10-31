using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sandbox.Models;

namespace Sandbox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        [HttpGet("xml")]
        [Produces("application/xml")]
        [FormatFilter]
        public IActionResult TestGetXml()
        {
            return Ok(new Person() { Id = 1, Name = "Test" });
        }

        [HttpGet("json")]
        [Produces("application/json")]
        public IActionResult TestGetJson()
        {
            return Ok(new Person() { Id = 1, Name = "Test" });
        }

        [HttpPost("xml")]
        [Produces("application/xml")]
        public IActionResult TestPostXml([FromBody]Person model)
        {
            return Ok(model);
        }

        [HttpPost("json")]
        [Produces("application/json")]
        public IActionResult TestPostJson([FromBody]Person model)
        {
            return Ok(model);
        }

        [HttpPost("form")]
        [Produces("application/json")]
        public IActionResult TestPostForm([FromForm]IFormCollection form)
        {
            var person = new Person() { Id=Convert.ToInt32(form["id"]), Name=form["name"]};
            return Ok(person);
        }

    }
}