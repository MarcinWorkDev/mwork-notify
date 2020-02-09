using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MWork.Common.Sdk.Extensions;
using MWork.Notify.Services.Messages.Commands;
using MWork.Notify.Services.Messages.Domain;
using MWork.Notify.Services.Messages.Repositories;

namespace MWork.Notify.Services.Messages.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IMessageRepository _repository;
        private readonly IMediator _mediator;

        public TestController(IMessageRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _repository.GetByUser("zxc", DateTime.MinValue, DateTime.MaxValue));
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            return Ok(await _repository.Get(id));
        }
        
        [HttpPost]
        public async Task<ActionResult> Post(Message message)
        {
            message.UserId = "zxc";
            await _repository.Create(message);
            return Accepted();
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _repository.SoftDelete(id);
            return Accepted();
        }

        [HttpPut]
        public async Task<ActionResult> Error()
        {
            throw new NotSupportedException()
                .SetHttpStatus(400)
                .ShowErrorMessage();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(UpdateMessageCommand patch, string id)
        {
            patch.MessageId = id;
            await _mediator.Send(patch);

            return Accepted();
        }
    }
}