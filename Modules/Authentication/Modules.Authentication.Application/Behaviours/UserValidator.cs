using FluentValidation;
using Modules.Authentication.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Authentication.Application.Behaviours
{
    public class UserValidator : AbstractValidator<RegistrationCommand>
    {
        public UserValidator()
        {
            RuleFor(user => user.Login)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("Логин не должен быть пустым")
                .Length(3, 25)
                .WithMessage("Логин должен быть не менее 3 и не более 25 символов");

            RuleFor(user => user.Password)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("Пароль не должен быть пустым")
                .Length(3, 25)
                .WithMessage("Пароль должен быть не менее 3 и не более 25 символов");

            RuleFor(user => user.Password)
                .Equal(user => user.PasswordConfirm)
                .WithMessage("Пароли не совпадают");
        }
    }
}
