using MediatR;
using Modules.Chat.Application.Command;
using Modules.Chat.Application.Common;
using Modules.Chat.Domain.Entitys;
using Shared.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Chat.Application.Handlers
{
    public class CreateAppealHandler : IRequestHandler<CreateAppealCommand>
    {
        #region Fileds

        private readonly IAppealRepository repository;

        #endregion

        #region Init

        public CreateAppealHandler(IAppealRepository repository)
            => this.repository = repository;

        #endregion

        public async Task Handle(CreateAppealCommand request, CancellationToken cancellationToken)
        {
            await repository.CreateAsync(request.Appeal);
            await repository.SaveAsync();
        }
    }
}
