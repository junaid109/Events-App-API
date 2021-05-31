using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persistence;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistence.Events;
using System.Threading;

namespace Events_App_API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<Event>>> GetListAsync()
        {
            return await _mediator.Send(new List.Query());
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<Event>> GetDetailsAsync(Guid id)
        {
            return await _mediator.Send(new Details.Query {Id = id});
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<Unit>> PostCreate(Create.Command command)
        {
            return await _mediator.Send(command);
        }

        //[HttpPost]
        //[Route("[action]")]
        //public async Task<ActionResult<Unit>> PostEdit(Guid id, Edit.Command command)
        //{
        //    command.id = id;
        //    return await _mediator.Send(command);
        //}

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<Unit>> PostDelete(Guid id)
        {
            return await _mediator.Send(new Delete.Command { id = id });
        }
    }
}
