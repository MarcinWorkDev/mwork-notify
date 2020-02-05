using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MWork.Notify.Common.Api.Controllers;
using MWork.Notify.Services.Messages.Commands;

namespace MWork.Notify.Services.Messages.Controllers
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