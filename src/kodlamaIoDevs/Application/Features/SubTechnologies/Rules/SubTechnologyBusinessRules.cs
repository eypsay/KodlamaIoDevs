using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SubTechnologies.Rules
{
    // SubTechnology
    public class SubTechnologyBusinessRules
    {
        private readonly ISubTechnologyRepository _subTechnologyRepository;

        public SubTechnologyBusinessRules(ISubTechnologyRepository subTechnologyRepository)
        {
            _subTechnologyRepository = subTechnologyRepository;
        }

        public async Task SubTechnologyNameCanNotDublicatedWhenInserted(string name)
        {
            IPaginate<SubTechnology> result =
                await _subTechnologyRepository.GetListAsync(p => p.Name == name);
            if (result.Items.Any()) throw new BusinessException("subTechnology Language name exits!!!");
        }

        //public async Task ProgrammingLanguageShouldExistWhenRequest(int id)
        //{
        //    ProgrammingLanguage? programmingLanguage =
        //        await _programmingLanguageRepository.GetAsync(p => p.Id == id);
        //    if (programmingLanguage == null) throw new BusinessException("Request Programming Language does not exits!!!");
        //}
        public void SubTechnologyShouldExistWhenRequest(SubTechnology subTechnology)
        {

            if (subTechnology == null) throw new BusinessException(subTechnology.Id + " id Programming Language does not exits!!!");
        }
    }

    
}
