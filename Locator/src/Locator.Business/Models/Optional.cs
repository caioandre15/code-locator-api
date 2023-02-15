using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.Business.Models
{
    public class Optional : Entity
    {
        public Guid CarId { get; set; }
        public bool ElectricWindow { get; set; }
        public bool EletricLock { get; set; }
        public bool HydraulicSteering { get; set; }
        public bool AirBag { get; set; }
        public bool Abs { get; set; }
        public bool AutomaticTransmission { get; set; }
        public bool AirConditioning { get; set; }
        public int QuantitiesOfDoorserty { get; set; }
        public int QuantitiesOfPeople { get; set; }
        public int QuantitiesOfBags { get; set; }

        // EF Relation
        public Car Car { get; set; }

    }
}
