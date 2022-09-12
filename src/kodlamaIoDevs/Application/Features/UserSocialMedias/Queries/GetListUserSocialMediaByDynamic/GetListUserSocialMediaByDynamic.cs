using Application.Features.UserSocialMedias.Models;
using Application.Features.UserSocialMedias.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.UserSocialMedias.Queries.GetListUserSocialMediaByDynamic
{
    public class GetListUserSocialMediaByDynamic : IRequest<UserSocialMediaListModel>
    {

        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListUserSocialMediaByDynamicHandler : IRequestHandler<GetListUserSocialMediaByDynamic, UserSocialMediaListModel>
        {
            private readonly IUserSocialMediaRepository _userSocialMediaRepository;
            private readonly IMapper _mapper;
            private readonly UserSocialMediaBusinessRules _userSocialMediaBusinessRules;

            public GetListUserSocialMediaByDynamicHandler(IUserSocialMediaRepository userSocialMediaRepository, IMapper mapper, UserSocialMediaBusinessRules userSocialMediaBusinessRules)
            {
                _userSocialMediaRepository = userSocialMediaRepository;
                _mapper = mapper;
                _userSocialMediaBusinessRules = userSocialMediaBusinessRules;
            }

            public async Task<UserSocialMediaListModel> Handle(GetListUserSocialMediaByDynamic request, CancellationToken cancellationToken)
            {

                var userSocialMedia = await _userSocialMediaRepository.GetListByDynamicAsync(request.Dynamic,
                    include:
                    m => m.Include(c => c.User),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize, cancellationToken: cancellationToken);

                var mappedUserSocialMediaListModel = _mapper.Map<UserSocialMediaListModel>(userSocialMedia);
                return mappedUserSocialMediaListModel;

            }
        }
    }
}
