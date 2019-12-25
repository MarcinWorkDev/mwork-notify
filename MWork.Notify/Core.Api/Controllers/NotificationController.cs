using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MWork.Notify.Core.Api.Controllers.Bases;
using MWork.Notify.Core.Logic.Commands.Command;

namespace MWork.Notify.Core.Api.Controllers
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