using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.Business.Models
{
    public class Car : Vehicle
    {
        public Characteristics characteristics { get; set; }
        public Optional optional { get; set; }
    }
}
