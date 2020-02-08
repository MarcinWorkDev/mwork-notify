using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MWork.Notify.Services.Messages.Commands;
using MWork.Notify.Services.Messages.Queries;

namespace MWork.Notify.Services.Messages.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MessageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> DispatchMessage(DispatchBasicMessageCommand command)
        {
            await _mediator.Publish(command);

            return Accepted();
        }

        [HttpGet]
        public async Task<ActionResult> GetCurrentTime()
        {
            var query = new GetCurrentTimeQuery();
            var time = await _mediator.Send(query);
            return Ok(time);
        }
    }
}