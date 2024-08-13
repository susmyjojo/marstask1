using NUnit.Framework;
using OpenQA.Selenium;
using ProjectMarsAutomation.utitlities;


namespace ProjectMarsAutomation.pages
{

    public class LoginPage : CommonDriver
    {

        private IWebElement usernameTextbox => driver.FindElement(By.XPath("//input[@type='text' and @placeholder='Email address' and @name='email']"));
        private IWebElement passwordTextbox => driver.FindElement(By.XPath("//input[@placeholder='Password']"));
        private IWebElement LoginButton => driver.FindElement(By.XPath("//button[@class='fluid ui teal button']"));
        private IWebElement ForgotPasswordButton => driver.FindElement(By.XPath("//button[@class='fluid ui teal button']"));
        private IWebElement VerificationButton => driver.FindElement(By.XPath("//button[@id='submit-btn']"));



        public void LoginActions(string username, string password)
        {
            try
            {

                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                Thread.Sleep(5000);
                //identify username feildbox and enter username
                usernameTextbox.SendKeys(username);
                passwordTextbox.SendKeys(password);
                Thread.Sleep(5000);
                LoginButton.Click();

            }
            catch (Exception ex)
            {
                Assert.Fail("Portal does not launch.");
            }

        }


        public void InvalidData(string username, string password)
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Thread.Sleep(5000);
            //identify username feildbox and enter username
            usernameTextbox.SendKeys(username);
            passwordTextbox.SendKeys(password);
            Thread.Sleep(5000);
            LoginButton.Click();


        }

        public void ForgotPassword(string username)
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Thread.Sleep(5000);
            //identify username feildbox and enter username
            usernameTextbox.SendKeys(username);
            ForgotPasswordButton.Click();

        }
        public void SendVerificationEmail(string username)
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Thread.Sleep(5000);
            //identify username feildbox and enter username
            usernameTextbox.SendKeys(username);
            VerificationButton.Click();
        }


    }
}
