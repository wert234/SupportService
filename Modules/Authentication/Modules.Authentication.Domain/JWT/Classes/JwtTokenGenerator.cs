using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Modules.Authentication.Domain.JWT.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Authentication.Domain.JWT.Classes
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IConfiguration _configuration;
        private readonly SecurityKey _key;
        private SecurityTokenDescriptor _tokenDescriptor;
        private JwtSecurityTokenHandler _tokenHandler;

        public JwtTokenGenerator(IConfiguration config)
        {
            _tokenDescriptor = new SecurityTokenDescriptor();
            _tokenHandler = new JwtSecurityTokenHandler();
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            _configuration = config;
        }

        public string CreateToken(IEnumerable<Claim> claims)
        {
            _tokenDescriptor.Issuer = _configuration["Jwt:Issuer"];
            _tokenDescriptor.Audience = _configuration["Jwt:Audience"];
            _tokenDescriptor.Subject = new ClaimsIdentity(claims);
            _tokenDescriptor.Expires = DateTime.Now.AddDays(7);
            _tokenDescriptor.SigningCredentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            return _tokenHandler.WriteToken(_tokenHandler.CreateToken(_tokenDescriptor));
        }
    }
}
