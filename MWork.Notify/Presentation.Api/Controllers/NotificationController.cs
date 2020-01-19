using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MWork.Notify.Core.Api.Commands;
using MWork.Notify.Presentation.Api.Controllers.Bases;

namespace MWork.Notify.Presentation.Api.Controllers
{
    public class NotificationController : MWorkController
    {
        public NotificationController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<ActionResult> DispatchMessage(DispatchBasicMessageCommand command)
        {
            await Mediator.Publish(command);

            return Accepted();
        }
    }
}