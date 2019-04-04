using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatorPatternExample.Mediator;
using MediatorPatternExample.Models.Commands;
using MediatorPatternExample.Models.DTOs;
using MediatorPatternExample.Models.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MediatorPatternExample.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IMediator _mediator;

        public ValuesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Dispatch<ValuesQuery, IEnumerable<ValueDTO>>());
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
