using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.Models
{
    public abstract class Vehicle : Entity
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string YearOfManufacture { get; set; }
        public string Version { get; set; }
        public string Plate { get; set; }
        public string TypeOfUse { get; set; }
        public string Group { get; set; }
        public string Description { get; set; }
    }
}
