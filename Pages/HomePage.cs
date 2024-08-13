using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProjectMarsAutomation.utitlities;




namespace ProjectMarsAutomation.Pages
{
    internal class HomePage : CommonDriver
    {
        //Finding for elements
        private IWebElement welcomeText => driver.FindElement(By.XPath(e_welcomeText));
        private By ByskillButton = By.XPath("//a[@class=\"item\" and @data-tab=\"second\"]");

        //Element for wait
        private string e_welcomeText = "//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span";

        public void clickSkillButton()
        {  //Click on skill
            IWebElement SkillButton = driver.FindElement(ByskillButton);
            SkillButton.Click();
        }
        public string getWelcomeText()
        {

            Waitutilities.WaitToBeVisible(driver, "XPath", e_welcomeText, 3);
            return welcomeText.Text;
        }

    }
}
