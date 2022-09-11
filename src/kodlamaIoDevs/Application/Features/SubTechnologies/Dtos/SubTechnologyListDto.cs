using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Dtos
{
    public class SubTechnologyListDto
    {
        public int Id { get; set; }
        public int ProgramingLanguageId { get; set; }
        public string Name { get; set; }
        public string ProgramingLanguageName { get; set; }
        public string Version { get; set; }


    }

    //public int ProgramingLanguageId { get; set; }
    //public string Name { get; set; }
    //public string Version { get; set; }

    //public virtual ProgrammingLanguage? ProgrammingLanguage { get; set; }
}
