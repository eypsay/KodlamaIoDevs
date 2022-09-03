﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.ProgrammingLanguages.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage
{
    public class GetListProgrammingLanguageQuery : IRequest<ProgrammingLanguageListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListProgrammingLanguageQueryHandler : IRequestHandler<GetListProgrammingLanguageQuery, ProgrammingLanguageListModel>
        {
            // Burada yapılması gerek 2 islem var.
            // 1-repoya bağlan
            // 2- map leme yap

            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;

            public GetListProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
            }


            public async Task<ProgrammingLanguageListModel> Handle(GetListProgrammingLanguageQuery request, CancellationToken cancellationToken)
            {
                //burada dbden sayfalı bir data geliyor.Cunku Ipaginate Items list var. Onu modele maplemem gerek 
                IPaginate<ProgrammingLanguage> programmingLanguages = await _programmingLanguageRepository.GetListAsync(index: request.PageRequest.Page,
                      size: request.PageRequest.PageSize);
                ProgrammingLanguageListModel
                    mappedListModel = _mapper.Map<ProgrammingLanguageListModel>(programmingLanguages);

                return mappedListModel;

            }
        }
    }
}
