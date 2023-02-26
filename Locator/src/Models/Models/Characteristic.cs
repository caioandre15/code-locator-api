using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.Models
{
    public class Characteristic : Entity
    {
        public Guid CarId { get; set; }
        public string Model { get; set; }
        public string Motorization { get; set; }
        public string Color { get; set; }
        public string TransportLoadCapacity { get; set; }

        // EF Relation
        public Car Car { get; set; }
    }
}
