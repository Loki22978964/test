using ClassLibrary1;
using LibraryPersonModels.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace StoragePersonModels
{
    public static class Serializer
    {
        private const string FilePath = @"C:\Users\Asus\Desktop\ооп1\res\all_entities.txt";

        public static async Task Save(IEnumerable<IEntity> entities)
        {
            using StreamWriter writer = new(FilePath, false);

            foreach (var entity in entities)
            {
                await writer.WriteLineAsync(entity.GetType().Name); // header

                foreach (var prop in entity.GetType().GetProperties())
                {
                    var value = prop.GetValue(entity) ?? "";
                    await writer.WriteLineAsync($"{prop.Name}:{value}");
                }

                await writer.WriteLineAsync("}"); // delimiter
            }
        }

        public static List<IEntity> Load()
        {
            var result = new List<IEntity>();

            if (!File.Exists(FilePath)) return result;

            string[] lines = File.ReadAllLines(FilePath);
            int i = 0;

            while (i < lines.Length)
            {
                if (string.IsNullOrWhiteSpace(lines[i])) { i++; continue; }

                string typeName = lines[i].Trim(); // перший рядок = тип
                i++;

                Dictionary<string, string> props = new();

                while (i < lines.Length && lines[i] != "}")
                {
                    var parts = lines[i].Split(':', 2);
                    if (parts.Length == 2)
                    {
                        props[parts[0]] = parts[1];
                    }
                    i++;
                }

                // тут створюємо об'єкт вручну залежно від типу
                IEntity? obj = typeName switch
                {
                    "Student" => new Student(
                        props["Surname"],
                        props["Name"],
                        int.Parse(props["Course"]),
                        props["StudentCard"],
                        props["ArrivalCity"],
                        props["Passport"]
                    )
                    {
                        HomeCity = props.ContainsKey("HomeCity") ? props["HomeCity"] : ""
                    },

                    "Acrobat" => new Acrobat(
                        props["Name"],
                        props["Surname"],
                        bool.Parse(props["AbilityToDance"])
                    ),

                    "TaxiDriver_" => new TaxiDriver_(
                        props["Name"],
                        props["Surname"],
                        bool.Parse(props["AbilityToDance"])
                    ),

                    _ => null
                };

                if (obj != null)
                    result.Add(obj);

                i++; // перескочити "}"
            }

            return result;
        }
    }
}
