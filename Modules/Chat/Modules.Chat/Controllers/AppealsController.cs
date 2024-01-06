using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modules.Chat.Application.Command;
using Modules.Chat.Application.Commands;
using Modules.Chat.Application.DTO;
using Modules.Chat.Application.Querys;
using Modules.Chat.Domain.Entitys;
using Shared.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Chat.Controllers
{
    [Route("api/Chat/[controller]")]
    [ApiController]
    [Authorize(Roles = "user3")]
    public class AppealsController : ControllerBase
    {
        #region Fileds

        private IMediator _mediator;

        #endregion

        #region Init

        public AppealsController(IMediator mediator)
        => _mediator = mediator;

        #endregion

        #region Controllers

        [HttpPost("CreateAppeal")]
        public async Task CreateAppeal(AppealDTO appealDTO)
            => await _mediator.Send(new CreateAppealCommand(appealDTO));
        
        [HttpPost("CloseAppeals/AppealId")]
        public async Task<IActionResult> CloseAppeal(int AppealId)
            =>await _mediator.Send(new CloseAppealsCommand(AppealId));

        [HttpGet("GetCurrentAppeals/UserId")]
        public async Task<object> GetCurrentAppeals(int UserId)
            => await _mediator.Send(new GetCurrentAppealsQuery(UserId));
        
        [HttpGet("GetHistoryAppeals/UserId")]
        public async Task<IActionResult> GetHistoryAppeals(int UserId)
            => await _mediator.Send(new GetHistoryAppealsQuery(UserId));
        
        #endregion
    }
}
