using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Authentication.Domain.JWT.Interfaces
{
    public interface IJwtTokenGenerator
    {
        public string CreateToken(IEnumerable<Claim> claims);
    }
}
