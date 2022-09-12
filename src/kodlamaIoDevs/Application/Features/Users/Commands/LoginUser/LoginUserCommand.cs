using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.JWT;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Users.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<AccessToken>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, AccessToken>
        {
            private readonly IUserRepository _userRepository;
            private readonly UserBusinessRules _userBusinessRules;
            private readonly IMapper _mapper;
            private readonly ITokenHelper _tokenHelper;
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;

            public LoginUserCommandHandler(IUserRepository userRepository, UserBusinessRules userBusinessRules, IMapper mapper, ITokenHelper tokenHelper, IUserOperationClaimRepository userOperationClaimRepository)
            {
                _userRepository = userRepository;
                _userBusinessRules = userBusinessRules;
                _mapper = mapper;
                _tokenHelper = tokenHelper;
                _userOperationClaimRepository = userOperationClaimRepository;
            }

            public async Task<AccessToken> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {

                var user = await _userRepository.GetAsync(u => u.Email == (request.Email));

                var userClaims = await _userOperationClaimRepository.GetListAsync(
                    u => u.UserId == user.Id,
                    include:
                    x => x.Include(c => c.OperationClaim),
                    cancellationToken: cancellationToken
                );

                var accessToken =
                    _tokenHelper.CreateToken(user, userClaims.Items.Select(x => x.OperationClaim).ToList());



                return accessToken;
            }
        }

    }
}
