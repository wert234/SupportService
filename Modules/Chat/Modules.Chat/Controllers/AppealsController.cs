using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modules.Chat.Application.Command;
using Modules.Chat.Application.Commands;
using Modules.Chat.Application.DTO;
using Modules.Chat.Application.Querys;
using Modules.Chat.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Chat.Controllers
{
    [Route("api/Chat/[controller]")]
    [ApiController]
    [AllowAnonymous]
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
        public async Task<IActionResult> CreateAppeal(AppealDTO appealDTO)
        {
            await _mediator.Send(new CreateAppealCommand(appealDTO));
            return StatusCode(201);
        }

        [HttpPost("CloseAppeals/AppealId")]
        public async Task<IActionResult> CloseAppeal(int AppealId)
        {
            await _mediator.Send(new CloseAppealsCommand(AppealId));
            return StatusCode(201);
        }


        [HttpGet("GetCurrentAppeals/UserId")]
        public async Task<IEnumerable<AppealDTO>> GetCurrentAppeals(int UserId)
        {
            return await _mediator.Send(new GetCurrentAppealsQuery(UserId));
        }

        [HttpGet("GetHistoryAppeals/UserId")]
        public async Task<IEnumerable<AppealDTO>> GetHistoryAppeals(int UserId)
        {
            return await _mediator.Send(new GetHistoryAppealsQuery(UserId));
        }

        #endregion
    }
}
