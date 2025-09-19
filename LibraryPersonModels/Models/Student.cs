using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPersonModels.Models
{
    public class Student : IEntity
    {
        public Guid id { get; } = Guid.NewGuid(); 
        public string Surname { get; set; }
        public string Name { get; set; }
        public int Course { get; set; }
        public string StudentCard { get; set; }
        public string ArrivalCity { get; set; }
        public string HomeCity    { get; set; }
        public string Passport { get; set; }


        public Student(string surname, string name, int course, string studentCard, string arrivalCity, string passport)
        {
            if (string.IsNullOrWhiteSpace(surname)) throw new ArgumentException("Last name cannot be empty.");
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty.");
            if (course <= 0) throw new ArgumentException("The rate must be a positive number.");

            Surname = surname;
            Name = name;
            Course = course;
            StudentCard = studentCard;
            ArrivalCity = arrivalCity;
            Passport = passport;
        }

    }
}
