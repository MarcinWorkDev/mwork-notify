using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using MWork.Common.Sdk.Repository;
using MWork.Notify.Services.Messages.Commands;
using MWork.Notify.Services.Messages.Domain;
using Newtonsoft.Json.Serialization;

namespace MWork.Notify.Services.Messages.Handlers
{
    public class UpdateMessageCommandHandler : AsyncRequestHandler<UpdateMessageCommand>
    {
        private readonly IDataRepository<Message> _repository;

        public UpdateMessageCommandHandler(IDataRepository<Message> repository)
        {
            _repository = repository;
        }

        protected override async Task Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
        {
            if ((request.Operations?.Any() ?? false) == false) return;
            
            var message = await _repository.GetOne(request.MessageId);

            if (message == default)
            {
                throw new Exception($"Message with id '{request.MessageId}' not found or found but you are not the owner.");
            }
            
            var canPatchProperties = new List<string>()
            {
                nameof(message.ReadAtUtc),
                nameof(message.Starred),
                nameof(message.Deleted)
            };

            if (request.Operations.Any(x => canPatchProperties.Contains(x.path) == false))
            {
                //throw new Exception($"Invalid operations!");
            }

            var doc = new JsonPatchDocument(request.Operations.ToList(), new DefaultContractResolver());

            doc.ApplyTo(message);
        }
    }
}