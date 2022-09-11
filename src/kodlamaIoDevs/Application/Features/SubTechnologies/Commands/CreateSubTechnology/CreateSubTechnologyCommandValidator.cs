using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Features.SubTechnologies.Commands.CreateSubTechnology.CreateSubTechnologyCommand;

namespace Application.Features.SubTechnologies.Commands.CreateSubTechnology
{
    public class CreateSubTechnologyCommandValidator : AbstractValidator<CreateSubTechnologyCommand>
    {
        public CreateSubTechnologyCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(2);

        }
    }
}
