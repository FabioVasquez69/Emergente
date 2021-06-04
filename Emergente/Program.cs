using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using FluentAssertions;
using System;

namespace Emergente
{
    public class UnitTest1
    {
        static void Main(string[] args)
        {
                        
            ChromeOptions full = new ChromeOptions();
            full.AddArgument("start-maximized");
            ChromeDriver driver = new ChromeDriver(full);

            driver.Url = "https://demoqa.com/alerts";
            var buttonClickMe = driver.FindElement(By.XPath("//button[text()= 'Click me' and @id='confirmButton']"));
            buttonClickMe.Click();
            var alert = driver.SwitchTo().Alert();
            Console.WriteLine("El texto es " +alert.Text);
            
            alert.Accept();

            var msnConfirmation = driver.FindElement(By.XPath("//span[@id='confirmResult']")).Text;
            msnConfirmation.Should().Equals("You selected Ok");
            Thread.Sleep(9000);
            buttonClickMe.Click();

            driver.Quit();
        }
    }
}
