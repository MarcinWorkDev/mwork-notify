using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MWork.Notify.Core.Logic.Commands.Command;
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