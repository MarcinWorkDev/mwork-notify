using MediatR;
using MWork.Notify.Core.Api.Controllers.Bases;

namespace MWork.Notify.Core.Api.Controllers
{
    public class TestController : MWorkController
    {
        public TestController(IMediator mediator)
            : base(mediator)
        {
        }
    }
}