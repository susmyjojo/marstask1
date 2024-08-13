using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace ProjectMarsAutomation.utitlities
{
    [Binding]
    public class CommonDriver
    {
       public static IWebDriver driver;
     
       public void initialise()
        {
            driver = new ChromeDriver();
        }
    }
}