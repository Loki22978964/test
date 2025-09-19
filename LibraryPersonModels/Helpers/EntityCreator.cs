using LibraryPersonModels.Models;
using LibraryPersonModels.WrapperClass;
using System;

namespace LibraryPersonModels.Helpers
{
    public static class EntityCreator
    {
        public static Student CreateStudent()
        {
            Console.Write("Surname: ");
            string surname = Console.ReadLine() ?? "";

            Console.Write("First Name: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Course: ");
            int course = int.Parse(Console.ReadLine() ?? "1");

            Console.Write("Student Card Number: ");
            string studentCard = Console.ReadLine() ?? "";

            Console.Write("Arrival City: ");
            string arrivalCity = Console.ReadLine() ?? "";

            Console.Write("Home City: ");
            string HomeCity = Console.ReadLine() ?? "";

            Console.Write("Passport Number: ");
            string passport = Console.ReadLine() ?? "";

            return new Student(surname, name, course, studentCard, arrivalCity, passport);
        }

        public static Acrobat CreateAcrobat()
        {
            Console.Write("First Name: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Surname: ");
            string surname = Console.ReadLine() ?? "";

            Console.Write("Can dance? (yes/no): ");
            string input = Console.ReadLine()?.ToLower() ?? "no";
            bool canDance = input == "yes";

            return new Acrobat(name, surname, canDance);
        }

        public static TaxiDriver_ CreateTaxiDriver()
        {
            Console.Write("First Name: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Surname: ");
            string surname = Console.ReadLine() ?? "";

            Console.Write("Can dance? (yes/no): ");
            string input = Console.ReadLine()?.ToLower() ?? "no";
            bool canDance = input == "yes";

            return new TaxiDriver_(name, surname, canDance);
        }

        public static void PrintFirstCourseOtherCityPercentage(wrapper data)
        {
            var firstCourseStudents = data.Students
                .Where(s => s.Course == 1)
                .ToList();

            if (firstCourseStudents.Count == 0)
            {
                Console.WriteLine("No first-course students found.");
                return;
            }

            int fromOtherCities = firstCourseStudents
                .Count(s => s.ArrivalCity != s.HomeCity); 

            double percentage = (double)fromOtherCities / firstCourseStudents.Count * 100;

            Console.WriteLine($"Total 1st course students: {firstCourseStudents.Count}");
            Console.WriteLine($"From other cities: {fromOtherCities}");
            Console.WriteLine($"Percentage: {percentage:F2}%");
        }
    }
}
