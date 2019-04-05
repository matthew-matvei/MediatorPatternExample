using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatorPatternExample.Extensions;
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
        public async Task<IActionResult> Get(int id)
        {
            return Ok(_mapper.Map<ValueDTO>(await _mediator.Dispatch<ValueQuery, ValueModel>(new ValueQuery { Id = id })));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateValueCommand command)
        {
            return Ok(_mapper.Map<ValueDTO>(await _mediator.Dispatch<CreateValueCommand, ValueModel>(command)));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateValueCommand command)
        {
            await _mediator.Dispatch<UpdateValueCommandWithId>(_mapper.Map<UpdateValueCommandWithId>(command).With(_ => _.Id = id));
            return NoContent();
        }
    }
}
