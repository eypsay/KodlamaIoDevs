using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.UserSocialMedias.Dtos;
using Application.Features.UserSocialMedias.Models;
using Application.Features.UserSocialMedias.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.UserSocialMedias.Queries.GetListSocialMediaQuery
{
    public class GetListUserSocialMediaQuery : IRequest<UserSocialMediaListModel>
    {

        public PageRequest PageRequest { get; set; }

        public class GetListUserSocialMediaQueryHandler : IRequestHandler<GetListUserSocialMediaQuery, UserSocialMediaListModel>
        {
            private readonly IUserSocialMediaRepository _userSocialMediaRepository;
            private readonly IMapper _mapper;
            private readonly UserSocialMediaBusinessRules _userSocialMediaBusinessRules;

            public GetListUserSocialMediaQueryHandler(IUserSocialMediaRepository userSocialMediaRepository, IMapper mapper, UserSocialMediaBusinessRules userSocialMediaBusinessRules)
            {
                _userSocialMediaRepository = userSocialMediaRepository;
                _mapper = mapper;
                _userSocialMediaBusinessRules = userSocialMediaBusinessRules;
            }

            public async Task<UserSocialMediaListModel> Handle(GetListUserSocialMediaQuery request, CancellationToken cancellationToken)
            {

                var userSocialMedia = await _userSocialMediaRepository.GetListAsync(include:
                    m => m.Include(c => c.User),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize,
                    cancellationToken: cancellationToken);
                var userSocialMediaListModel = _mapper.Map<UserSocialMediaListModel>(userSocialMedia);
                return userSocialMediaListModel;

            }
        }
    }
}
