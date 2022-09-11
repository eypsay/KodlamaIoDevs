using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Models.Dtos;
using Application.Features.Models.Models;
using Application.Services.Repositories;
using AutoMapper;
using AutoMapper.Configuration;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.SubTechnologies.Queries.GetListSubTechnology
{
    public class GetListSubTechnologyQuery : IRequest<SubTechnologyListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListSubTechnologyHandler : IRequestHandler<GetListSubTechnologyQuery, SubTechnologyListModel>
        {
            private readonly IMapper _mapper;
            private readonly ISubTechnologyRepository _subTechnologyRepository;

            public GetListSubTechnologyHandler(IMapper mapper, ISubTechnologyRepository subTechnologyRepository)
            {
                _mapper = mapper;
                _subTechnologyRepository = subTechnologyRepository;
            }

            public async Task<SubTechnologyListModel> Handle(GetListSubTechnologyQuery request, CancellationToken cancellationToken)
            {

                IPaginate<SubTechnology> subTechnologies = await _subTechnologyRepository.GetListAsync(
                      include:
                      s => s.Include(p => p.ProgrammingLanguage),
                      index: request.PageRequest.Page,
                      size: request.PageRequest.PageSize

                  );

                SubTechnologyListModel mappedModels = _mapper.Map<SubTechnologyListModel>(subTechnologies);
                return mappedModels;
            }
        }
    }
}
