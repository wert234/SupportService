using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Authentication.Application.Commands
{
    public abstract class AuthenticationCommand
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
