using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Models.Dtos;
using Application.Features.Models.Models;
using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using Application.Features.someFeature.Dtos;
using Application.Features.SubTechnologies.Commands.CreateSubTechnology;
using Application.Features.SubTechnologies.Commands.DeleteSubTechnology;
using Application.Features.SubTechnologies.Commands.UpdateSubTechnology;
using Application.Features.SubTechnologies.Dtos;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Models.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SubTechnology, CreatedSubTechnologyDto>().ReverseMap();
            CreateMap<SubTechnology, CreateSubTechnologyCommand>().ReverseMap();



            CreateMap<SubTechnology, SubTechnologyGetByIdDto>().ReverseMap();

            CreateMap<SubTechnology, DeleteSubTechnologyCommand>().ReverseMap();
            CreateMap<SubTechnology, DeletedSubTechnologyDto>().ReverseMap();

            CreateMap<SubTechnology, UpdateSubTechnologyCommand>().ReverseMap();
            CreateMap<SubTechnology, UpdatedSubTechnologyDto>().ReverseMap();



            CreateMap<SubTechnology, SubTechnologyListDto>().ForMember(
                    c => c.ProgramingLanguageName,
                    opt => opt.MapFrom(
                        c => c.ProgrammingLanguage.Name
                        )
                    )
                .ReverseMap();
            CreateMap<IPaginate<SubTechnology>, SubTechnologyListModel>().ReverseMap();
        }
    }
}
