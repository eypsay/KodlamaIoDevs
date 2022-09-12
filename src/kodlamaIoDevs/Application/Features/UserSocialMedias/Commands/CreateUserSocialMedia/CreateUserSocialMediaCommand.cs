using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.UserSocialMedias.Dtos;
using Application.Features.UserSocialMedias.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserSocialMedias.Commands.CreateUserSocialMedia
{
    public class CreateUserSocialMediaCommand : IRequest<CreatedUserSocialMediaDto>
    {
        public int UserId { get; set; }
        public string GithubUrl { get; set; }



        public class CreateUserSocialMediaCommandHandler : IRequestHandler<CreateUserSocialMediaCommand, CreatedUserSocialMediaDto>
        {
            private readonly IUserSocialMediaRepository _userSocialMediaRepository;
            private readonly IMapper _mapper;
            private readonly UserSocialMediaBusinessRules _userSocialMediaBusinessRules;

            public CreateUserSocialMediaCommandHandler(IUserSocialMediaRepository userSocialMediaRepository, IMapper mapper, UserSocialMediaBusinessRules userSocialMediaBusinessRules)
            {
                _userSocialMediaRepository = userSocialMediaRepository;
                _mapper = mapper;
                _userSocialMediaBusinessRules = userSocialMediaBusinessRules;
            }

            public async Task<CreatedUserSocialMediaDto> Handle(CreateUserSocialMediaCommand request, CancellationToken cancellationToken)
            {

                var mappedUserSocialMedia = _mapper.Map<UserSocialMedia>(request);
                var createdUserSocialMedia = await _userSocialMediaRepository.AddAsync(mappedUserSocialMedia);
                var mappedCreatedUserSocialMediaDto = _mapper.Map<CreatedUserSocialMediaDto>(createdUserSocialMedia);
                return mappedCreatedUserSocialMediaDto;

            }
        }
    }
}
