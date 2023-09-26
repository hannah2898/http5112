using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01626469Assignment1.Controllers
{
    public class HostingCostController : ApiController
    {
        public String Get(int id)
        {
            int n = (id / 14) + 1;
            double amount = n * 5.50;
            double hst = (amount * 0.13);
            double total = amount + hst;

            return n+" fortnights at $5.50/FN = $"+amount+" CAD HST 13% = $"+hst+" CAD Total=$"+total+" CAD";
        }
    }
}
