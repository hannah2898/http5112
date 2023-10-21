using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
///<summary>
///Finds which quadrant a particular point lies on
/// </summary>
/// <param name= "x"> x coordinate where (−1000 ≤ x ≤ 1000; x 6 = 0)</param>
/// /// <param name= "y"> y coordinate (−1000 ≤ y ≤ 1000; y 6 = 0)</param>
/// returns quadrant number (1, 2, 3 or 4) for the point (x, y).
namespace n01626469_Assignment2.Controllers
{
    public class J1Controller : ApiController
    {
        [Route("api/J1/getquadrant/{x}/{y}")]
        public int GetQuadrant(int x,int y)
        {
            if(x>0 && y > 0)
            {
                return 1;
            } 
            else if(y>0 && x < 0)
            {
                return 2;
            }
            else if (x<0 && y < 0)
            {
                return 3;
            }
            else if (x > 0 && y < 0)
            {
                return 4;
            }
            else 
            { return 0;}

        
        }
    }
}
