using NUnit.Framework;
using ProjectMarsAutomation.pages;
using ProjectMarsAutomation.Pages;
using ProjectMarsAutomation.utitlities;

namespace ProjectMarsAutomation.StepDefinitions
{
    [Binding]


    public class LogInFeaturesStepDefinitions : CommonDriver

    {

        HomePage HomePageObj;
        LoginPage LoginPageObj;
        [Given(@"user enters valid username '([^']*)' and password '([^']*)'  clicks login button")]
        public void GivenUserEntersValidUsernameAndPasswordClicksLoginButton(string username, string password)
        {
            LoginPageObj = new LoginPage();

            LoginPageObj.LoginActions(username, password);
        }

        [Then(@"User should be redirected to the home page and User should see his name on the topright")]
        public void ThenUserShouldBeRedirectedToTheHomePageAndUserShouldSeeHisNameOnTheTopright()
        {
            HomePageObj = new HomePage();
            string welcomeText = HomePageObj.getWelcomeText();
            Assert.That(welcomeText == "Hi jojo" || welcomeText == "Hi", "Actual welcome text and expected welcome text do not match");
            driver.Close();

        }

    }
}
