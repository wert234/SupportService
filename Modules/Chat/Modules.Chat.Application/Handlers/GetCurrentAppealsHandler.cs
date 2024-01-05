using MediatR;
using Modules.Chat.Application.Command;
using Modules.Chat.Application.Common;
using Modules.Chat.Application.DTO;
using Modules.Chat.Application.Querys;
using Modules.Chat.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Chat.Application.Handlers
{
    public class GetCurrentAppealsHandler : IRequestHandler<GetCurrentAppealsQuery, IEnumerable<AppealDTO>>
    {
        #region Fileds

        private readonly IAppealRepository repository;

        #endregion

        #region Init

        public GetCurrentAppealsHandler(IAppealRepository repository)
            => this.repository = repository;

        #endregion

        public async Task<IEnumerable<AppealDTO>> Handle(GetCurrentAppealsQuery request, CancellationToken cancellationToken)
        {
            return (await repository.GetListAsync(request.UserId))
                .Where(x => x.Status != Domain.Enums.Status.Closed)
                .Select(appeal => new AppealDTO()
                {
                    UserId = appeal.UserId,
                    Name = appeal.Name,
                    Message = appeal.Messages.ToArray()[0].Text,
                    date = appeal.date,
                });
        }
    }
}
