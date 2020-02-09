using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using MWork.Notify.Services.Messages.Domain;

namespace MWork.Notify.Services.Messages.Commands
{
    public class UpdateMessageCategoryCommand : JsonPatchDocument<Category>, IRequest
    {
        
    }
}