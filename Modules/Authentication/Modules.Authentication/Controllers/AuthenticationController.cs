using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Modules.Authentication.Application.Commands;
using Modules.Authentication.Application.Queries;
using Shared.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Authentication.Controllers
{
    [Route("api/Authentication/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {
        #region Fileds

        private IMediator _mediator;

        #endregion

        #region Init

        public AuthenticationController(IMediator mediator)
        => _mediator = mediator;

        #endregion

        #region Controllers

        [HttpPost("Registration")]
        public async Task<IActionResult> Registration(RegistrationCommand command)
        {
                var result = await _mediator.Send(command);
            return ControllerHandle.Resultchecking(result, true);
        }

        [HttpPost("Authorization")]
        public async Task<IActionResult> Authorization(/*AuthorizationCommand command*/)
        {
            //     var result = await _mediator.Send(command);
            return Ok(); //ControllerHandle.Resultchecking(result.Success, true, result);
        }

        [HttpPost("GetToken")]
        public async Task<IActionResult> GetToken()
        {
            var querie = new GetTokenQuerie();
            querie.User = new Domain.Entitys.ApplicationUser() { UserName = "Влад", Id = 1 };

            return Ok(await _mediator.Send(querie));
        }

        #endregion
    }
}
