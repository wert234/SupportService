﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Chat.Controllers
{
    [Route("api/Chat/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        #region Fileds

     //   private IMediator _mediator;

        #endregion

        #region Init

     //   public ChatController(IMediator mediator)
    //    => _mediator = mediator;

        #endregion

        #region Controllers

        [HttpPost("Send")]
        public async Task<IActionResult> Send(/*RegistrationCommand command*/)
        {
            //    var result = await _mediator.Send(command);
            return Ok(); // ControllerHandle.Resultchecking(result, true);
        }

        #endregion
    }
}
