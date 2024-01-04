﻿using MediatR;
using Modules.Chat.Application.Command;
using Modules.Chat.Application.Commands;
using Modules.Chat.Application.Common;
using Modules.Chat.Application.DTO;
using Modules.Chat.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Chat.Application.Handlers
{
    public class GetAppealsHandler : IRequestHandler<GetAppealsQuery, IEnumerable<AppealDTO>>
    {
        #region Fileds

        private readonly IAppealRepository repository;

        #endregion

        #region Init

        public GetAppealsHandler(IAppealRepository repository)
            => this.repository = repository;

        public async Task<IEnumerable<AppealDTO>> Handle(GetAppealsQuery request, CancellationToken cancellationToken)
        {
            return (await repository.GetListAsync(request.UserId)).Select(appeal => new AppealDTO()
            {
                UserId = appeal.Id,
                Name = appeal.Name,
                Message = appeal.Messages.ToArray()[0].Text,
            });
        }


        #endregion


    }
}
