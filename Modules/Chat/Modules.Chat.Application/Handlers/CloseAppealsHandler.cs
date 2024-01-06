using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Modules.Chat.Application.Commands;
using Modules.Chat.Application.Common;
using Modules.Chat.Domain.Entitys;
using Modules.Chat.Domain.Enums;
using Shared.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Chat.Application.Handlers
{
    public class CloseAppealsHandler : IRequestHandler<CloseAppealsCommand, IActionResult>
    {
        #region Fileds

        private readonly IAppealRepository repository;

        #endregion

        #region Init

        public CloseAppealsHandler(IAppealRepository repository)
            => this.repository = repository;

        #endregion

        public async Task<IActionResult> Handle(CloseAppealsCommand request, CancellationToken cancellationToken)
        {

            var appeal = await repository.GetAsync(request.AppealId);

            if (appeal is null)
                return new ObjectResult("Токого обращения не существует") {StatusCode = (int)HttpStatusCode.BadRequest };

            if (appeal.Status is Status.Closed)
                return new ObjectResult("Это обращение уже закрыто") { StatusCode = (int)HttpStatusCode.BadRequest };

            appeal.Status = Status.Closed;
            await repository.SaveAsync();
            return new StatusCodeResult(201);
        }
    }
}
