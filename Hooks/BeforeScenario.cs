using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProjectMarsAutomation.Pages;
using ProjectMarsAutomation.utitlities;

namespace ProjectMarsAutomation.Hooks
{
    [Binding]
    public sealed class BeforeScenario : CommonDriver
    {

        [BeforeScenario]

       
        public void SetUpsigninpage()
        {
            
            //Open Chrome/Firefox browser
             driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.Navigate().GoToUrl("http://localhost:5000/");
            IWebElement SigninButton = driver.FindElement(By.XPath("//a[@class=\"item\"][text()=\"Sign In\"]"));
             SigninButton.Click();
          
        }


       /* [AfterScenario]
          public void AfterScenario()
          {
             driver.Quit();
       }
        */
      
    }
}