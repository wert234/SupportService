using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Authentication.Application.Commands
{
    public class RegistrationCommand : AuthenticationCommand, IRequest<bool>
    {
        public string PasswordConfirm { get; set; }
    }
}
