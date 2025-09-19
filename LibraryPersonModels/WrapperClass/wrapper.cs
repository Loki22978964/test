using LibraryPersonModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LibraryPersonModels.WrapperClass
{
    public class wrapper
    {
        public List<Student> Students { get; set; } = new();
        public List<Acrobat> Acrobats { get; set; } = new();
        public List<TaxiDriver_> TaxiDrivers { get; set; } = new();

        public string ToJson()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }

        public static wrapper FromJson(string json)
        {
            return JsonSerializer.Deserialize<wrapper>(json) ?? new wrapper();
        }

    }
}
