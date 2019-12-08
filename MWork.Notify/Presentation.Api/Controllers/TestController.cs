using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MWork.Notify.Core.Services.Commands.Command;
using MWork.Notify.Core.Services.Queries.Query;
using MWork.Notify.Presentation.Api.Controllers.Bases;

namespace MWork.Notify.Presentation.Api.Controllers
{
    public class TestController : MWorkController
    {
        private readonly IMediator _mediator;

        public TestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> SayHello([FromQuery]string say)
        {
            await _mediator.Publish(new SayHelloCommand(say ?? "Hello World!"));
            var date = await _mediator.Send(new GetCurrentTimeQuery());

            return Ok(date);
        }
    }
}