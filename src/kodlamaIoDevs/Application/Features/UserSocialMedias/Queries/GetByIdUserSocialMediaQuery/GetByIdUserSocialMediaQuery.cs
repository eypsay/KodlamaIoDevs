using Application.Features.UserSocialMedias.Commands.CreateUserSocialMedia;
using Application.Features.UserSocialMedias.Dtos;
using Application.Features.UserSocialMedias.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.UserSocialMedias.Queries.GetByIdSocialMediaQuery
{
    public class GetByIdUserSocialMediaQuery : IRequest<UserSocialMediaGetByIdDto>
    {

        public int Id { get; set; }

        public class GetByIdUserSocialMediaQueryHandler : IRequestHandler<GetByIdUserSocialMediaQuery, UserSocialMediaGetByIdDto>
        {
            private readonly IUserSocialMediaRepository _userSocialMediaRepository;
            private readonly IMapper _mapper;
            private readonly UserSocialMediaBusinessRules _userSocialMediaBusinessRules;

            public GetByIdUserSocialMediaQueryHandler(IUserSocialMediaRepository userSocialMediaRepository, IMapper mapper, UserSocialMediaBusinessRules userSocialMediaBusinessRules)
            {
                _userSocialMediaRepository = userSocialMediaRepository;
                _mapper = mapper;
                _userSocialMediaBusinessRules = userSocialMediaBusinessRules;
            }

            public async Task<UserSocialMediaGetByIdDto> Handle(GetByIdUserSocialMediaQuery request, CancellationToken cancellationToken)
            {

                var userSocialMedia = await _userSocialMediaRepository.Query().Include(x => x.User).FirstOrDefaultAsync(
                      x => x.Id == request.Id, cancellationToken: cancellationToken
                      );

                var userSocialMediaAddressGetByIdDto = _mapper.Map<UserSocialMediaGetByIdDto>(userSocialMedia);
                return userSocialMediaAddressGetByIdDto;

            }
        }
    }
}
