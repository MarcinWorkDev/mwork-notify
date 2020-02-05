using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MWork.Notify.Common.Api.Controllers
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