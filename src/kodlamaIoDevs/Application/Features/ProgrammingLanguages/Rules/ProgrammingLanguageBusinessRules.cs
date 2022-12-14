using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task ProgrammingLanguageNameCanNotDublicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingLanguage> result =
                await _programmingLanguageRepository.GetListAsync(p => p.Name == name);
            if (result.Items.Any()) throw new BusinessException("Programming Language name exits!!!");
        }

        //public async Task ProgrammingLanguageShouldExistWhenRequest(int id)
        //{
        //    ProgrammingLanguage? programmingLanguage =
        //        await _programmingLanguageRepository.GetAsync(p => p.Id == id);
        //    if (programmingLanguage == null) throw new BusinessException("Request Programming Language does not exits!!!");
        //}
        public void ProgrammingLanguageShouldExistWhenRequest(ProgrammingLanguage programmingLanguage)
        {

            if (programmingLanguage == null) throw new BusinessException( programmingLanguage.Id + " id Programming Language does not exits!!!");
        }
    }
}
