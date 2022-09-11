using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Features.SubTechnologies.Dtos;
using Application.Features.SubTechnologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SubTechnologies.Commands.UpdateSubTechnology
{
    //SubTechnology
    public class UpdateSubTechnologyCommand : IRequest<UpdatedSubTechnologyDto>
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public class UpdateSubTechnologyCommandHandler : IRequestHandler<UpdateSubTechnologyCommand,
            UpdatedSubTechnologyDto>
        {
            private readonly ISubTechnologyRepository _subTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly SubTechnologyBusinessRules _subTechnologyBusinessRules;

            public UpdateSubTechnologyCommandHandler(ISubTechnologyRepository subTechnologyRepository, IMapper mapper, SubTechnologyBusinessRules subTechnologyBusinessRules)
            {
                _subTechnologyRepository = subTechnologyRepository;
                _mapper = mapper;
                _subTechnologyBusinessRules = subTechnologyBusinessRules;
            }

            public async Task<UpdatedSubTechnologyDto> Handle(UpdateSubTechnologyCommand request, CancellationToken cancellationToken)
            {
                SubTechnology? subTechnology = await _subTechnologyRepository.GetAsync(p => p.Id == request.Id);
                _subTechnologyBusinessRules.SubTechnologyShouldExistWhenRequest(subTechnology);

                await _subTechnologyBusinessRules.SubTechnologyNameCanNotDublicatedWhenInserted(
                    request.Name);


                SubTechnology mappedSubTechnology = _mapper.Map<SubTechnology>(request);
                SubTechnology updatedSubTechnology = await _subTechnologyRepository.UpdateAsync(mappedSubTechnology);
                UpdatedSubTechnologyDto updatedProgrammingLanguageDto =
                    _mapper.Map<UpdatedSubTechnologyDto>(updatedSubTechnology);

                return updatedProgrammingLanguageDto;


            }
        }
    }
}
