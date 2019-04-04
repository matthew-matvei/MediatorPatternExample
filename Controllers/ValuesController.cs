using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatorPatternExample.Mediator;
using MediatorPatternExample.Models;
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
        private readonly IMapper _mapper;

        public ValuesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_mapper.Map<IEnumerable<ValueDTO>>(await _mediator.Dispatch<ValuesQuery, IEnumerable<ValueModel>>()));
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
