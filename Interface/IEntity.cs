using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public interface IEntity
    {
        public Guid  id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
