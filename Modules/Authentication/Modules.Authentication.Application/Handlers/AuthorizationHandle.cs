using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Modules.Authentication.Application.Commands;
using Modules.Authentication.Domain.Entitys;
using Modules.Authentication.Domain.JWT.Classes;
using Modules.Authentication.Domain.JWT.Interfaces;
using System.Net;

namespace Modules.Authentication.Application.Handlers
{
    public class AuthorizationHandle : IRequestHandler<AuthorizationCommand, IActionResult>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtTokenGenerator _tokenGenerator;

        public AuthorizationHandle(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, JwtTokenGenerator tokenGenerator)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<IActionResult> Handle(AuthorizationCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.Login);

            if (user is null)
                return new ObjectResult("Токого пользователя не существует") { StatusCode = (int)HttpStatusCode.BadRequest };

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);

            if (result.Succeeded)
                return new ObjectResult(_tokenGenerator.CreateToken(await _userManager.GetClaimsAsync(user))) { StatusCode = (int)HttpStatusCode.OK };

            return new ObjectResult("Неправельный логин или пароль") { StatusCode = (int)HttpStatusCode.BadRequest };
        }
    }
}
