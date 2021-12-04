using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace WebAddressbookTests


{

    public class Loops
    {
        [Test]
        public void ForLoops()
        {
            string[] stringArray = new string[] { "I", "want", "to", "sleep" };
            for (int i = 0; i < stringArray.Length; i = i + 1)
            {
                System.Console.Out.Write(stringArray[i] + "\n");
                System.Console.Out.Write(stringArray.Length + "\n");
            }


            foreach (string element in stringArray)
            {
                System.Console.Out.Write(element + "\n");
            }
        }


        public void WhileLoops1()
        {
            IWebDriver driver = null ;

            //infinite loop may accure
            while (driver.FindElements(By.Id("test")).Count == 0)

            {
                System.Threading.Thread.Sleep(1000);
            }
         
        }

        public void WhileLoops2()
        {
            IWebDriver driver = null;
            int attempt = 0;

            //infinite loop solution
            while (driver.FindElements(By.Id("test")).Count == 0 && attempt < 60)

            {
                System.Threading.Thread.Sleep(1000);
                attempt++;
            }

        }

        public void WhileLoops3()
        {
            IWebDriver driver = null;
            int attempt = 0;
            do
            {
                System.Threading.Thread.Sleep(1000);
                attempt++;
            }
            while (driver.FindElements(By.Id("test")).Count == 0 && attempt < 60);
        }
    }
}
