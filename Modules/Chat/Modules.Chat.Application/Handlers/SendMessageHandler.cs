using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Modules.Chat.Application.Command;
using Modules.Chat.Application.Common;
using Modules.Chat.Application.Hubs;
using Modules.Chat.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Modules.Chat.Application.Handlers
{
    public class SendMessageHandler : IRequestHandler<SendMessageCommand>
    {
        #region Fileds

        private readonly IAppealRepository _repository;
        private readonly IHubContext<ChatHub> _hubContext;

        #endregion

        #region Init

        public SendMessageHandler(IAppealRepository repository, IHubContext<ChatHub> context)
        {
           _repository = repository;
           _hubContext = context;
        }

        public async Task Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            await _repository.AddMessageAsync(new Message() { Text = request.Text, UserId = request.UserId }, request.AppealId);
            await _repository.SaveAsync();

            await _hubContext.Clients.All.SendAsync("Send", request.UserId, request.Text);
        }

        #endregion


    }
}
