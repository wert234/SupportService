using MediatR;
using Modules.Chat.Application.Commands;
using Modules.Chat.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Chat.Application.Handlers
{
    public class CloseAppealsHandler : IRequestHandler<CloseAppealsCommand>
    {
        #region Fileds

        private readonly IAppealRepository repository;

        #endregion

        #region Init

        public CloseAppealsHandler(IAppealRepository repository)
            => this.repository = repository;

        #endregion

        public async Task Handle(CloseAppealsCommand request, CancellationToken cancellationToken)
        {
            var appeal = await repository.GetAsync(request.AppealId);
            if (appeal != null)
                appeal.Status = Domain.Enums.Status.Closed;

            await repository.SaveAsync();
        }
    }
}
