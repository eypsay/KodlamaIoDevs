using Application.Features.SubTechnologies.Commands.DeleteSubTechnology;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SubTechnologies.Commands.UpdateSubTechnology
{
    public class UpdateSubTechnologyCommandValidator : AbstractValidator<UpdateSubTechnologyCommand>
    {
        public UpdateSubTechnologyCommandValidator()
        {
            RuleFor(u => u.Name).NotEmpty();
        }
    }
}
