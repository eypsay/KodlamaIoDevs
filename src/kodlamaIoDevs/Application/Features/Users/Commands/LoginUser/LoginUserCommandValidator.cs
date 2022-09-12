using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.Users.Commands.LoginUser
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(
                    p => p.Email)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.Password)
                .NotEmpty()
                .NotNull();
        }
    }
}
