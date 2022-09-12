using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.UserSocialMedias.Dtos;
using Application.Features.UserSocialMedias.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.UserSocialMedias.Commands.DeleteUserSocialMedia
{
    public class DeleteUserSocialMediaCommand : IRequest<DeletedUserSocialMediaDto>
    {
        public int Id { get; set; }


        public class DeleteUserSocialMediaCommandHandler : IRequestHandler<DeleteUserSocialMediaCommand, DeletedUserSocialMediaDto>
        {
            private readonly IUserSocialMediaRepository _userSocialMediaRepository;
            private readonly IMapper _mapper;
            private readonly UserSocialMediaBusinessRules _userSocialMediaBusinessRules;
            public async Task<DeletedUserSocialMediaDto> Handle(DeleteUserSocialMediaCommand request, CancellationToken cancellationToken)
            {
                var userSocialMedia = await _userSocialMediaRepository.GetAsync(u => u.Id == request.Id);

                var deletedUserSocialMedia = await _userSocialMediaRepository.DeleteAsync(userSocialMedia);
                var mappedDeletedSocialMedia = _mapper.Map<DeletedUserSocialMediaDto>(deletedUserSocialMedia);
                return mappedDeletedSocialMedia;


            }
        }
    }
}
