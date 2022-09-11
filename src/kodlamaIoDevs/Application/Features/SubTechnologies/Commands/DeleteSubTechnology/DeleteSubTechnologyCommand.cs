using Application.Features.SubTechnologies.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Application.Features.SubTechnologies.Rules;

namespace Application.Features.SubTechnologies.Commands.DeleteSubTechnology
{
    //SubTechnology
    public class DeleteSubTechnologyCommand : IRequest<DeletedSubTechnologyDto>
    {
        public int Id { get; set; }

        public class DeleteSubTechnologyCommandHandler : IRequestHandler<DeleteSubTechnologyCommand,
            DeletedSubTechnologyDto>
        {
            private readonly ISubTechnologyRepository _subTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly SubTechnologyBusinessRules _subTechnologyBusinessRules;

            public DeleteSubTechnologyCommandHandler(ISubTechnologyRepository subTechnologyRepository, IMapper mapper, SubTechnologyBusinessRules subTechnologyBusinessRules)
            {
                _subTechnologyRepository = subTechnologyRepository;
                _mapper = mapper;
                _subTechnologyBusinessRules = subTechnologyBusinessRules;
            }

            public async Task<DeletedSubTechnologyDto> Handle(DeleteSubTechnologyCommand request, CancellationToken cancellationToken)
            {
                SubTechnology? subTechnology = await _subTechnologyRepository.GetAsync(p => p.Id == request.Id);
                _subTechnologyBusinessRules.SubTechnologyShouldExistWhenRequest(subTechnology);


                SubTechnology deletedSubTechnology = await _subTechnologyRepository.DeleteAsync(subTechnology);
                DeletedSubTechnologyDto deletedSubTechnologyDto = _mapper.Map<DeletedSubTechnologyDto>(deletedSubTechnology);
                return deletedSubTechnologyDto;
            }
        }
    }
}
