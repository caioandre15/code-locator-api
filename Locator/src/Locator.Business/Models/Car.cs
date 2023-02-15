using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.Business.Models
{
    public class Car : Vehicle
    {
        public Characteristics Characteristics { get; set; }
        public Optional Optional { get; set; }
    }
}
