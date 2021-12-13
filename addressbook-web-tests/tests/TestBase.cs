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
        public static bool PERFORM_LONG_UI_CHECKS = true;

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
                builder.Append(Convert.ToChar(32+Convert.ToInt32(rnd.NextDouble() * 65)));
            }
            return builder.ToString();           
        }

        public static string GenerateRandomPhoneNumber()
        {
            StringBuilder phoneNumber = new StringBuilder();
            for (int i = 0; i < 12; i++) 
                {
                int l = rnd.Next(9);
                phoneNumber.Append(l.ToString());
                }
            return phoneNumber.ToString();      
        }
        public static string GenerateRandomMonth()
        {
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            int i = rnd.Next(12);
            return months[i];
        }
        public static string GenerateRandomYear()
        {
            int i =  rnd.Next(1900, (DateTime.Now.Year));
            return i.ToString();
        }
        public static string GenerateRandomEmail()
        {
            string text = "{0}@{1}.{2}";                
            return string.Format(text, GenerateRandomString(20), GenerateRandomString(20), GenerateRandomString(5));
        }
        public static string GenerateRandomWebAddress()
        {
            string text = "https://{0}.{1}";
            return string.Format(text, GenerateRandomString(20), GenerateRandomString(5));
        }

        public static string GenerateRandomNumber(int max)
        {
            int i = rnd.Next(1, max);
            return i.ToString();
        }
    }
}
