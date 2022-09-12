using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Rules
{
    public class UserBusinessRules
    {

        private readonly IUserRepository _userRepository;

        public UserBusinessRules()
        {

        }

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task UserNameCanNotDublicatedWhenInserted(string email)
        {
            IPaginate<User> result =
                await _userRepository.GetListAsync(u => u.Email == email);
            if (result.Items.Any()) throw new BusinessException(" User name exits!!!");
        }

        //public async Task ProgrammingLanguageShouldExistWhenRequest(int id)
        //{
        //    ProgrammingLanguage? programmingLanguage =
        //        await _programmingLanguageRepository.GetAsync(p => p.Id == id);
        //    if (programmingLanguage == null) throw new BusinessException("Request Programming Language does not exits!!!");
        //}
        public void UserShouldExistWhenRequest(User user)
        {

            if (user == null) throw new BusinessException(user.Id + " id user does not exits!!!");
        }
    }
}
