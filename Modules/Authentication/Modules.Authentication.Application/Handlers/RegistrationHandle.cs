using MediatR;
using Microsoft.AspNetCore.Identity;
using Modules.Authentication.Application.Behaviours;
using Modules.Authentication.Application.Commands;
using Modules.Authentication.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Authentication.Application.Handlers
{
    public class RegistrationHandle : IRequestHandler<RegistrationCommand, bool>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly UserValidator _userValidator;

        public RegistrationHandle(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _userValidator = new UserValidator();
        }

        public async Task<bool> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.Login);
            if (user != null)
                return false;

            if ((await _userValidator.ValidateAsync(request)).IsValid)
            {
                var result = await _userManager.CreateAsync(new ApplicationUser()
                {
                    UserName = request.Login,

                }, request.Password);

                if (result.Succeeded)
                {
                    var user1 = await _userManager.FindByNameAsync(request.Login);

                    await _userManager.AddClaimsAsync(await _userManager.FindByNameAsync(request.Login),
                         new List<Claim>()
                         {
                            new Claim(ClaimTypes.Role, "user"),
                            new Claim("UserId", user1.Id.ToString()),
                         });
                    return result.Succeeded;
                }

            }
            return false;
        }
    }
}
