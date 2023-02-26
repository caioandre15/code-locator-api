using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.Models
{
    public class Car : Vehicle
    {
        public Characteristic Characteristics { get; set; }
        public Optional Optional { get; set; }
    }
}
