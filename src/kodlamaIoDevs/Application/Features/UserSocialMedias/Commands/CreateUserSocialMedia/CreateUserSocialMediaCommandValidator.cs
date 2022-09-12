using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.UserSocialMedias.Constants;
using FluentValidation;

namespace Application.Features.UserSocialMedias.Commands.CreateUserSocialMedia
{
    public class CreateUserSocialMediaCommandValidator :AbstractValidator<CreateUserSocialMediaCommand>
    {
        public CreateUserSocialMediaCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .NotNull()
                .WithMessage(UserSocialMediaMessage.UserIdIsRequired);

            RuleFor(x => x.GithubUrl)
                .NotEmpty()
                .NotNull()
                .WithMessage(UserSocialMediaMessage.GithubUrlIsRequired);
        }
    }
    
}
