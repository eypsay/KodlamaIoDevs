using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class SubTechnology : Entity
    {
        public int ProgramingLanguageId { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }

        public virtual ProgrammingLanguage? ProgrammingLanguage { get; set; }

        public SubTechnology()
        {

        }

        public SubTechnology(int id, int programingLanguageId, string name, string version) : this()
        {
            Id = id;
            ProgramingLanguageId = programingLanguageId;
            Name = name;
            Version = version;

        }
    }
}
