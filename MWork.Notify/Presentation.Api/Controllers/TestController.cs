using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MWork.Notify.Core.Logic.Commands.Command;
using MWork.Notify.Core.Logic.Queries.Query;
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
            //await _mediator.Publish(new SayHelloCommand(say ?? "Hello World!"));
            //var date = await _mediator.Send(new GetCurrentTimeQuery());

            var token =
                @"deo4rzsMZ_WxelnbPsIqqh:APA91bGAa536jL3xAtdK09pDHRcNLrsBW9gMc031lkDO9gZRC61ax9Xx3Zb0tzZGKCKFwC8dnvgB9K5m8ZsNanZwPrdPer8z5eax_hkLFF5koBgdAyInrjsQOYLt9XSrwQ-9nB48_yNO";
            await _mediator.Publish(new DispatchBasicMessageCommand(token, "Test message tile", "Test message content!"));
            
            return Ok();
        }
    }
}