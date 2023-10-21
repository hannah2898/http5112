using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01626469_Assignment2.Controllers
{
    ///<summary>
    ///Calculates shifty sum For example, the shifty sum when N is 12 and k is 1 is: 12 + 120 = 132
    /// </summary>
    /// <param name= "n"> n is the input number(1 ≤ n ≤ 10000). </param>
    /// /// <param name= "k"> k is the number of times the number is shifted (0 ≤ k ≤ 5)</param>
    /// returns Output the integer which is the shifty sum of N by k.
    public class J2Controller : ApiController
    {
        [HttpGet]
        [Route("api/J2/Shift/{n}/{k}")]
        ///api/J2/Shift/12/3 -->Output =13332
        public double Shift(int n, int k)
        {
            double sum;
            sum = 0;
            for (int i = 0; i <= k; i++)
            {
                sum = sum + (n * Math.Pow(10, i));
            }
            return sum;
        }
    }
}
