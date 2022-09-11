using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Features.someFeature.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.SubTechnologies.Dtos;
using Application.Features.SubTechnologies.Rules;

namespace Application.Features.SubTechnologies.Commands.CreateSubTechnology
{
    public class CreateSubTechnologyCommand : IRequest<CreatedSubTechnologyDto>
    {

        public string Name { get; set; }

        public class CreateSubTechnologyCommandHandler : IRequestHandler<CreateSubTechnologyCommand, CreatedSubTechnologyDto>
        {
            private readonly ISubTechnologyRepository _subTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly SubTechnologyBusinessRules _subTechnologyBusinessRules;

            public CreateSubTechnologyCommandHandler(ISubTechnologyRepository subTechnologyRepository, IMapper mapper, SubTechnologyBusinessRules subTechnologyBusinessRules)
            {
                _subTechnologyRepository = subTechnologyRepository;
                _mapper = mapper;
                _subTechnologyBusinessRules = subTechnologyBusinessRules;
            }

            public async Task<CreatedSubTechnologyDto> Handle(CreateSubTechnologyCommand request, CancellationToken cancellationToken)
            {
                //burada businessrule isletiliyor
                await _subTechnologyBusinessRules.SubTechnologyNameCanNotDublicatedWhenInserted(
                    request.Name);

                //burada language ekleme islemi
                SubTechnology mappedCreatedSubTechnology = _mapper.Map<SubTechnology>(request);
                SubTechnology createdSubTechnology = await
                    _subTechnologyRepository.AddAsync(mappedCreatedSubTechnology);
                CreatedSubTechnologyDto createdSubTechnologyDto =
                    _mapper.Map<CreatedSubTechnologyDto>(createdSubTechnology);

                return createdSubTechnologyDto;
            }
        }
    }
}
