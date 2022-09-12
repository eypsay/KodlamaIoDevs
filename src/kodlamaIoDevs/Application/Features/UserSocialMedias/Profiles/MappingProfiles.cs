using AutoMapper;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Models.Models;
using Application.Features.UserSocialMedias.Commands.CreateUserSocialMedia;
using Application.Features.UserSocialMedias.Commands.DeleteUserSocialMedia;
using Application.Features.UserSocialMedias.Commands.UpdateUserSocialMedia;
using Application.Features.UserSocialMedias.Dtos;
using Application.Features.UserSocialMedias.Models;
using Domain.Entities;

namespace Application.Features.UserSocialMedias.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserSocialMedia, CreatedUserSocialMediaDto>().ReverseMap();
            CreateMap<UserSocialMedia, CreateUserSocialMediaCommand>().ReverseMap();

            CreateMap<UserSocialMedia, DeleteUserSocialMediaCommand>().ReverseMap();
            CreateMap<UserSocialMedia, DeletedUserSocialMediaDto>().ReverseMap();

            CreateMap<UserSocialMedia, UpdateUserSocialMediaCommand>().ReverseMap();
            CreateMap<UserSocialMedia, UpdatedUserSocialMediaDto>().ReverseMap();

            CreateMap<IPaginate<UserSocialMedia>, UserSocialMediaListModel>().ReverseMap();
            CreateMap<UserSocialMedia, UserSocialMediaListDto>().ReverseMap();

            CreateMap<UserSocialMedia, UserSocialMediaGetByIdDto>()
                .ForMember(c =>
                        c.FirstName,
                    opt =>
                        opt.MapFrom(c => c.User.FirstName))
                .ForMember(c =>
                        c.LastName,
                    opt =>
                        opt.MapFrom(c => c.User.LastName))
                .ForMember(c =>
                        c.Email,
                    opt =>
                        opt.MapFrom(c => c.User.Email)).ReverseMap();

            CreateMap<UserSocialMedia, UserSocialMediaListDto>()
                .ForMember(c =>
                        c.FirstName,
                    opt =>
                        opt.MapFrom(c => c.User.FirstName))
                .ForMember(c =>
                        c.LastName,
                    opt =>
                        opt.MapFrom(c => c.User.LastName))
                .ForMember(c =>
                        c.Email,
                    opt =>
                        opt.MapFrom(c => c.User.Email)).ReverseMap();


            CreateMap<IPaginate<UserSocialMedia>, SubTechnologyListModel>().ReverseMap();
        }
    }
}
