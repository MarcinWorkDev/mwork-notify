using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MWork.Notify.Core.Api.Controllers.Bases
{
    [ApiController]
    [Route("api/[controller]")]
    public class MWorkController : ControllerBase
    {
        protected readonly IMediator Mediator;

        public MWorkController(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}