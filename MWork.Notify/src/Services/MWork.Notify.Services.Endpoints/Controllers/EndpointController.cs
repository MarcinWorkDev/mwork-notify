using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MWork.Notify.Services.Endpoints.Commands;
using MWork.Notify.Services.Endpoints.Domain;
using MWork.Notify.Services.Endpoints.Queries;

namespace MWork.Notify.Services.Endpoints.Controllers
{
    [ApiController]
    public class EndpointController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EndpointController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetUserEndpoints([FromQuery]string userId)
        {
            var query = new GetUserEndpointsQuery(userId);
            return Ok(await _mediator.Send(query));
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserEndpoint(string id)
        {
            var query = new GetUserEndpointQuery(id);
            return Ok(await _mediator.Send(query));
        }
        
        [HttpPost]
        public async Task<ActionResult> CreateUserEndpoint(CreateUserEndpointCommand request)
        {
            request.Id = Guid.NewGuid().ToString("N");
            await _mediator.Send(request);
            return CreatedAtAction(nameof(GetUserEndpoint), new {id = request.Id}, null);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateUserEndpoint(string id, JsonPatchDocument<UserEndpoint> operations)
        {
            var request = new UpdateUserEndpointCommand(id, operations);
            await _mediator.Send(request);
            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserEndpoint(string id)
        {
            var request = new DeleteUserEndpointCommand(id);
            await _mediator.Send(request);
            return Accepted();
        }
    }
}