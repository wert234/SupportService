using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modules.Chat.Application.Command;
using Modules.Chat.Application.DTO;
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

        [HttpGet("GetAppeals")]
        public async Task<IActionResult> GetAppeals(/*GetAppealsQuere quere*/)
            => Ok(/*await _mediator.Send(quere)*/);

        [HttpPost("CreateAppeal")]
        public async Task<IActionResult> CreateAppeal(AppealDTO appealDTO)
        {
            await _mediator.Send(new AddAppealCommand(appealDTO));
            return StatusCode(201);
        }
        #endregion
    }
}
