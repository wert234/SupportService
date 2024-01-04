using MediatR;
using Microsoft.AspNetCore.Mvc;
using Modules.Chat.Application.Command;
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
    public class MessageController : ControllerBase
    {
        #region Fileds

        private IMediator _mediator;

        #endregion

        #region Init

        public MessageController(IMediator mediator)
        => _mediator = mediator;

        #endregion

        #region Controllers

        [HttpPost("Send")]
        public async Task<IActionResult> Send(SendMessageCommand command)
        {
            await _mediator.Send(command);
            return StatusCode(201);
        }

        #endregion
    }
}
