using Application.Features.UserSocialMedias.Commands.CreateUserSocialMedia;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.UserSocialMedias.Constants;

namespace Application.Features.UserSocialMedias.Commands.DeleteUserSocialMedia
{
    public class DeleteUserSocialMediaCommandValidator : AbstractValidator<DeleteUserSocialMediaCommand>
    {
        public DeleteUserSocialMediaCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage(UserSocialMediaMessage.UserIdIsRequired);

        }
    }
}
