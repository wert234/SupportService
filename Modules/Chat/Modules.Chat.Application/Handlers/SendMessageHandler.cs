using MediatR;
using Modules.Chat.Application.Command;
using Modules.Chat.Application.Common;
using Modules.Chat.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Chat.Application.Handlers
{
    public class SendMessageHandler : IRequestHandler<SendMessageCommand>
    {
        #region Fileds

        private readonly IAppealRepository repository;

        #endregion

        #region Init

        public SendMessageHandler(IAppealRepository repository)
            => this.repository = repository;

        public async Task Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            await repository.AddMessageAsync(new Message() { Text = request.Text }, request.AppealId);
            await repository.SaveAsync();
        }

        #endregion


    }
}
