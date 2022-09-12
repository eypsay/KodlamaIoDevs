using Application.Features.UserSocialMedias.Commands.DeleteUserSocialMedia;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.UserSocialMedias.Constants;

namespace Application.Features.UserSocialMedias.Commands.UpdateUserSocialMedia
{
    public class UpdateUserSocialMediaCommandValidator : AbstractValidator<UpdateUserSocialMediaCommand>
    {
        public UpdateUserSocialMediaCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage(UserSocialMediaMessage.UserIdIsRequired);
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
