using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
//TestBase is responsible for initialisation and for stopping the browser 

namespace WebAddressbookTests
{
    public class TestBase
    {  
        //protected bool acceptNextAlert = true;
        protected ApplicationManager app;

        [SetUp]
        public void SetUpApplicationManager()
        {
            //Singletone
           app = ApplicationManager.GetInstance();
           
        }

       
        //static - we have a single rnd within the solution which will generate random values each time
        public static Random rnd = new Random();
        public static string GenerateRandomString(int max)
        {
            //create a number in between 0 and max = string length
            //convert float to integer, rounding
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            System.Console.Out.Write(l);

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                //ASCI symbols with code < 32 are not printable 
                //generate a random ASCI symbol code l times 
                builder.Append(Convert.ToChar(32+Convert.ToInt32(rnd.NextDouble() * 223)));
            }
            return builder.ToString();           
        }
    }
}
