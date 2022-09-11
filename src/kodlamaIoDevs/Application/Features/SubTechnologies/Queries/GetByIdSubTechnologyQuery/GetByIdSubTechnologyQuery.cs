using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Rules;
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

namespace Application.Features.SubTechnologies.Queries.GetByIdSubTechnologyQuery
{
    // SubTechnology
    public class GetByIdSubTechnologyQuery : IRequest<SubTechnologyGetByIdDto>
    {

        public int Id { get; set; }


        public class GetByIdSubTechnologyQueryHandler : IRequestHandler<GetByIdSubTechnologyQuery, SubTechnologyGetByIdDto>
        {
            // Burada yapılması gerek 2 islem var.
            // 1-repoya bağlan
            // 2- map leme yap

            private readonly ISubTechnologyRepository _subTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly SubTechnologyBusinessRules _subTechnologyBusinessRules;

            public GetByIdSubTechnologyQueryHandler(ISubTechnologyRepository subTechnologyRepository, IMapper mapper, SubTechnologyBusinessRules subTechnologyBusinessRules)
            {
                _subTechnologyRepository = subTechnologyRepository;
                _mapper = mapper;
                _subTechnologyBusinessRules = subTechnologyBusinessRules;
            }


            public async Task<SubTechnologyGetByIdDto> Handle(GetByIdSubTechnologyQuery request, CancellationToken cancellationToken)
            {

                SubTechnology? subTechnology = await _subTechnologyRepository.GetAsync(p => p.Id == request.Id);

                _subTechnologyBusinessRules.SubTechnologyShouldExistWhenRequest(subTechnology);

                SubTechnologyGetByIdDto subTechnologyGetByIdDto =
                    _mapper.Map<SubTechnologyGetByIdDto>(subTechnology);

                return subTechnologyGetByIdDto;

            }
        }

    }
}
