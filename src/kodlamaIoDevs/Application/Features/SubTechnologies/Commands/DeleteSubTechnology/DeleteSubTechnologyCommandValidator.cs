using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SubTechnologies.Commands.DeleteSubTechnology
{
    public class DeleteSubTechnologyCommandValidator : AbstractValidator<DeleteSubTechnologyCommand>
    {
        public DeleteSubTechnologyCommandValidator()
        {
            RuleFor(d => d.Id).NotEmpty();
            RuleFor(d => d.Id).GreaterThan(0);
        }
    }
}

