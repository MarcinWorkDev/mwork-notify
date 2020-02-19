using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MWork.Notify.Services.Endpoints.Consumers.Commands;
using MWork.Notify.Services.Endpoints.Domain;

namespace MWork.Notify.Services.Endpoints.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EndpointsController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetUserEndpoints([FromQuery]Guid userId)
        {
            throw new NotImplementedException();
            /*var query = new GetUserEndpointsQuery(userId);
            return Ok(await _mediator.Send(query));*/
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserEndpoint(Guid id)
        {
            throw new NotImplementedException();
            /*var query = new GetEndpointQuery(id);
            return Ok(await _mediator.Send(query));*/
        }
        
        [HttpPost]
        public async Task<ActionResult> CreateUserEndpoint(CreateEndpointCommand request)
        {
            throw new NotImplementedException();
            /*request.Id = Guid.NewGuid();
            await _mediator.Send(request);
            return CreatedAtAction(nameof(GetUserEndpoint), new {id = request.Id}, null);*/
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateUserEndpoint(Guid id, JsonPatchDocument<Endpoint> operations)
        {
            throw new NotImplementedException();
            /*var request = new UpdateEndpointCommand(id, operations);
            await _mediator.Send(request);
            return Accepted();*/
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserEndpoint(Guid id)
        {
            throw new NotImplementedException();
            /*var request = new DeleteEndpointCommand(id);
            await _mediator.Send(request);
            return Accepted();*/
        }
    }
}