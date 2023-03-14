using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.Models.Models.Auth
{
    public class ResponseLogin
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
