using MediatR;
using Microsoft.AspNetCore.Mvc;
using Modules.Chat.Application.Command;
using Modules.Chat.Application.Common;
using Modules.Chat.Application.DTO;
using Modules.Chat.Application.Querys;
using Modules.Chat.Domain.Entitys;
using Shared.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Chat.Application.Handlers
{
    public class GetCurrentAppealsHandler : IRequestHandler<GetCurrentAppealsQuery, IActionResult>
    {
        #region Fileds

        private readonly IAppealRepository repository;

        #endregion

        #region Init

        public GetCurrentAppealsHandler(IAppealRepository repository)
            => this.repository = repository;

        #endregion

        public async Task<IActionResult> Handle(GetCurrentAppealsQuery request, CancellationToken cancellationToken)
        {
            var listAppeal = (await repository.GetListAsync(request.UserId))
                .Where(x => x.Status != Domain.Enums.Status.Closed)
                .Select(appeal => new AppealDTO()
                {
                    UserId = appeal.UserId,
                    Name = appeal.Name,
                    Message = appeal.Messages.ToArray()[0].Text,
                    date = appeal.date,
                });

            if (listAppeal.Count() == 0)
                return new ObjectResult("Токого пользователя не существует") { StatusCode = (int)HttpStatusCode.BadRequest };
            
          return new ObjectResult(listAppeal) { StatusCode = (int)HttpStatusCode.OK };
        }
    }
}
