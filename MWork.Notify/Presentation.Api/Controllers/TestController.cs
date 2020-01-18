using MediatR;
using MWork.Notify.Presentation.Api.Controllers.Bases;

namespace MWork.Notify.Presentation.Api.Controllers
{
    public class TestController : MWorkController
    {
        public TestController(IMediator mediator)
            : base(mediator)
        {
        }
    }
}