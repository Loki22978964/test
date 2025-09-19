using LibraryPersonModels.WrapperClass;
using LibraryPersonModels.Helpers;
using StoragePersonModels;

class Program
{
    static async Task Main()
    {
        wrapper data = await Storage.LoadAsync();

        Console.WriteLine("Кого додати? (1 - Студент, 2 - Акробат, 3 - Таксист)");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                data.Students.Add(EntityCreator.CreateStudent());
                break;
            case "2":
                data.Acrobats.Add(EntityCreator.CreateAcrobat());
                break;
            case "3":
                data.TaxiDrivers.Add(EntityCreator.CreateTaxiDriver());
                break;
            default:
                Console.WriteLine("Невірний вибір!");
                return;
        }

        await Storage.SaveAsync(data);
        Console.WriteLine("✅ Дані збережені у JSON!");
    }
}
