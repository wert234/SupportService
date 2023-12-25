using MediatR;
using Modules.Authentication.Application.Queries;
using Modules.Authentication.Domain.JWT.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Authentication.Application.Handlers
{
    public class GetTokenHandler : IRequestHandler<GetTokenQuerie, string>
    {

        private readonly JwtTokenGenerator _jwtTokenGenerator;

        public GetTokenHandler(JwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<string> Handle(GetTokenQuerie request, CancellationToken cancellationToken)
        {
           return _jwtTokenGenerator.CreateToken(new List<Claim>() { new Claim(ClaimTypes.Role, "User") });
        }
    }
}
