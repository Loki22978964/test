using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPersonModels.Models
{
    public class TaxiDriver_ : IEntity
    {
        public Guid id { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool AbilityToDance { get; set; }

        public TaxiDriver_() { }
        public TaxiDriver_(string name, string surname, bool abilityToDance)
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
