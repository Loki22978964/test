using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPersonModels.Models
{
     public class Acrobat : IEntity
    {
        public Guid id { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool AbilityToDance { get; set; }

        public Acrobat() { }

        public Acrobat(string name, string surname, bool abilityToDance)
        {
            Name = name;
            Surname = surname;
            AbilityToDance = abilityToDance;
        }

        public bool CanDance()
        {
            return AbilityToDance;
        }
    }
}
