using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.Business.Models
{
    public class Characteristics : Entity
    {
        public string Model { get; set; }
        public string Motorization { get; set; }
        public string Color { get; set; }
        public string TransportLoadCapacity { get; set; }

        // EF Relation
        public Guid CharacteristicsId { get; set; }
        public Car Car { get; set; }
    }
}
