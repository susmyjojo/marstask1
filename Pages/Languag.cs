using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProjectMarsAutomation.utitlities;

namespace ProjectMarsAutomation.Pages
{
    internal class Languag : CommonDriver
    {

        private IWebElement AddNewButton => driver.FindElement(By.XPath("//div[@data-tab='first']//div[@class ='ui teal button ']"));
        private By ByLanguageTextBox = By.XPath("//input[@type='text' and @placeholder='Add Language']");
        private By AddButton = By.XPath("//input[@type='button' and @class='ui teal button' and @value='Add']");
        private IWebElement dropdownLanguage => driver.FindElement(By.XPath("//div[@data-tab='first']//select[@class='ui dropdown']"));
        private IWebElement editLanguageButton => driver.FindElement(By.XPath("//span[@class='button']/i[@class='outline write icon']"));
        private IWebElement editLanguage => driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
        private IWebElement UpdateButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        private IWebElement languageLevel => driver.FindElement(By.XPath("//div[@data-tab='first']//tbody[last()]/tr/td[2]"));
        private IWebElement DeleteButton => driver.FindElement(By.XPath("//div[@data-tab='first']//tbody[last()]/tr/td[3]/span[2]/i"));
        private IWebElement message => driver.FindElement(By.XPath(e_message));
        private IWebElement language => driver.FindElement(By.XPath(e_language));
        private string e_language = "//div[@data-tab='first']//tbody[last()]/tr/td[1]";
        private string e_message = "//div[@class='ns-box-inner']";
        public void clickAddnewButton()
        {

            //Click on add new button
            Thread.Sleep(3000);
            AddNewButton.Click();

        }
        public void AddNewLanguage(string language, string languagelevel)
        {
            IWebElement LanguageTextBox = driver.FindElement(ByLanguageTextBox);


            LanguageTextBox.Click();
            LanguageTextBox.SendKeys(language);

            var selectLanguageDropdown = new SelectElement(dropdownLanguage);
            selectLanguageDropdown.SelectByValue(languagelevel);
            //Click on the Save Button
            IWebElement AddButton = driver.FindElement(By.XPath("//input[@type='button' and @class='ui teal button' and @value='Add']"));
            AddButton.Click();

        }

        public void EditLanguage(string language, string newlevel)
        {

            //Click edit button
            editLanguageButton.Click();

            //Edit language
            editLanguage.Clear();
            editLanguage.SendKeys(language);

            //Edit Lanuage Level
            var selectLanguage = new SelectElement(dropdownLanguage);
            selectLanguage.SelectByValue(newlevel);
        }
        public void updateButton()
        { 
            //Click Update
            UpdateButton.Click();
        }
        public void DeleteLanguage(string language)
        {
            try
            {
                string strLanguage = GetLanguage();
                if (strLanguage == language)
                {
                    //Click delete
                    DeleteButton.Click();
                }
                else
                {
                    Assert.Fail("No matching language found.");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("No language is found");
            }
        }
        public string GetLanguageLevel()
        {
            //Get last record Language level
            return languageLevel.Text;
        }
        public string GetMessage()
        {
            Waitutilities.WaitToBeVisible(driver, "XPath", e_message, 3);
            return message.Text;
        }
        public string GetLanguage()
        {
            //Get last record language text
            try
            {
                Waitutilities.WaitToBeVisible(driver, "XPath", e_language, 5);
                return language.Text;
            }
            catch (Exception)
            {
                return "locator not found";
            }
        }
    }
}

