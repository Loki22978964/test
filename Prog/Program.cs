using ClassLibrary1;
using LibraryPersonModels.Helpers;
using LibraryPersonModels.Models;
using LibraryPersonModels.WrapperClass;
using StoragePersonModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        wrapper data = new wrapper();

        // Завантаження існуючих даних
        List<IEntity> loaded = Serializer.Load();
        foreach (var e in loaded)
        {
            switch (e)
            {
                case Student s: data.Students.Add(s); break;
                case Acrobat a: data.Acrobats.Add(a); break;
                case TaxiDriver_ t: data.TaxiDrivers.Add(t); break;
            }
        }

        while (true)
        {
            Console.WriteLine("\nWho do you want to add?");
            Console.WriteLine("1 - Student");
            Console.WriteLine("2 - Acrobat");
            Console.WriteLine("3 - Taxi Driver");
            Console.WriteLine("4 - Percentage of first-year students from another city");
            Console.WriteLine("0 - Exit");

            string choice = Console.ReadLine()?.Trim();

            switch (choice)
            {
                case "1":
                    data.Students.Add(EntityCreator.CreateStudent());
                    Console.WriteLine("Student added!");
                    break;
                case "2":
                    data.Acrobats.Add(EntityCreator.CreateAcrobat());
                    Console.WriteLine("Acrobat added!");
                    break;
                case "3":
                    data.TaxiDrivers.Add(EntityCreator.CreateTaxiDriver());
                    Console.WriteLine("Taxi Driver added!");
                    break;
                case "4":
                    EntityCreator.PrintFirstCourseOtherCityPercentage(data);
                    break;
                case "0":
                    Console.WriteLine("Exiting program...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    continue;
            }

            // Об’єднуємо всі списки в один і зберігаємо
            var allEntities = new List<IEntity>();
            allEntities.AddRange(data.Students);
            allEntities.AddRange(data.Acrobats);
            allEntities.AddRange(data.TaxiDrivers);

            await Serializer.Save(allEntities);

            Console.WriteLine("Data successfully saved!\n");
        }
    }
}
