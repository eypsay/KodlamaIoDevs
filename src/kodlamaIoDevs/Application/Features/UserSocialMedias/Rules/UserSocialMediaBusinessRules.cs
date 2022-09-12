using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Features.UserSocialMedias.Rules
{
    public class UserSocialMediaBusinessRules
    {
        private readonly IUserSocialMediaRepository _userSocialMediaRepository;

        public UserSocialMediaBusinessRules()
        {

        }

        public UserSocialMediaBusinessRules(IUserSocialMediaRepository userSocialMediaRepository)
        {
            _userSocialMediaRepository = userSocialMediaRepository;
        }


        public async Task UserSocialMediaNameCanNotDublicatedWhenInserted(string githubUrl)
        {
            IPaginate<UserSocialMedia> result =
                await _userSocialMediaRepository.GetListAsync(u => u.GithubUrl == githubUrl);
            if (result.Items.Any()) throw new BusinessException(" User name exits!!!");
        }

        //public async Task ProgrammingLanguageShouldExistWhenRequest(int id)
        //{
        //    ProgrammingLanguage? programmingLanguage =
        //        await _programmingLanguageRepository.GetAsync(p => p.Id == id);
        //    if (programmingLanguage == null) throw new BusinessException("Request Programming Language does not exits!!!");
        //}
        public void UserSocialMediaShouldExistWhenRequest(UserSocialMedia userSocialMedia)
        {

            if (userSocialMedia == null) throw new BusinessException(userSocialMedia.Id + " id userSocialMedia does not exits!!!");
        }
    }
}

