using MediatR;
using Microsoft.AspNetCore.Mvc;
using Modules.Chat.Application.Command;
using Modules.Chat.Application.Common;
using Modules.Chat.Application.DTO;
using Modules.Chat.Application.Querys;
using Modules.Chat.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Chat.Application.Handlers
{
    public class GetHistoryAppealsHandler : IRequestHandler<GetHistoryAppealsQuery, IActionResult>
    {
        #region Fileds

        private readonly IAppealRepository repository;

        #endregion

        #region Init

        public GetHistoryAppealsHandler(IAppealRepository repository)
            => this.repository = repository;

        #endregion

        public async Task<IActionResult> Handle(GetHistoryAppealsQuery request, CancellationToken cancellationToken)
        {
            var listAppeal = (await repository.GetListAsync(request.UserId)).Select(appeal => new AppealDTO()
            {
                UserId = appeal.UserId,
                Name = appeal.Name,
                Message = appeal.Messages.ToArray()[0].Text,
                date = appeal.date,
            });

            if (listAppeal.Count() == 0)
                return new ObjectResult("Токого пользователя не существует или у него ещё нет обращений") { StatusCode = (int)HttpStatusCode.BadRequest };

            return new ObjectResult(listAppeal) { StatusCode = (int)HttpStatusCode.OK };
        }
    }
}
