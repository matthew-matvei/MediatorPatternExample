using System;
using MediatorPatternExample.Models.Commands;
using Microsoft.AspNetCore.Mvc;

namespace MediatorPatternExample.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateValueCommand command)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] UpdateValueCommand command)
        {
            return Ok();
        }
    }
}
