using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        #region Controllers

        [HttpPost("Registration")]
        public async Task<IActionResult> Registration(/*RegistrationCommand command*/)
        {
            //    var result = await _mediator.Send(command);
            return Ok(); //ControllerHandle.Resultchecking(result, true);
        }

        [HttpPost("Authorization")]
        public async Task<IActionResult> Authorization(/*AuthorizationCommand command*/)
        {
            //     var result = await _mediator.Send(command);
            return Ok(); //ControllerHandle.Resultchecking(result.Success, true, result);
        }

        #endregion
    }
}
