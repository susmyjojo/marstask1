using NUnit.Framework;
using ProjectMarsAutomation.pages;
using ProjectMarsAutomation.Pages;
using ProjectMarsAutomation.utitlities;

namespace ProjectMarsAutomation.StepDefinitions
{
    [Binding]
    public class LanguageStepDefinitions : CommonDriver
    {
        Languag LanguageObj = new Languag();
        HomePage HomePageObj;
        LoginPage LoginPageObj;
       

        [Given(@"enters valid username '([^']*)' and password '([^']*)'  clicks login button")]
        public void GivenEntersValidUsernameAndPasswordClicksLoginButton(string username, string password)
        {
            LoginPageObj = new LoginPage();
           
            LoginPageObj.LoginActions(username, password);
        }
        [When(@"user naviagate to language tab and click Add new button")]
        public void WhenUserNaviagateToLanguageTabAndClickAddNewButton()
        {
           
            LanguageObj.clickAddnewButton();
        }
        [When(@"User adds a language '([^']*)' with level '([^']*)' clicks  Add button")]
        public void WhenUserAddsALanguageWithLevelClicksAddButton(string language, string languagelevel)
        {
            //Initiate objects
            LanguageObj = new Languag();
            LanguageObj.AddNewLanguage(language, languagelevel); ;
        }


      
        [Then(@"User should see the language '([^']*)' '([^']*)' added to the profile")]
        public void ThenUserShouldSeeTheLanguageAddedToTheProfile(string language, string languageLevel)
        {
            {
                //Check success message
                string message = LanguageObj.GetMessage();
                string assertMessage = language + " has been added to your languages";
                Assert.That(message == assertMessage, "Actual message and Expected message do not match");

                //check language and language level are created successfully
                string addedLanguage = LanguageObj.GetLanguage();
                string addedLanguageLevel = LanguageObj.GetLanguageLevel();
                Assert.That(addedLanguage == language, "Actual language and Expected language do not match");
                Assert.That(addedLanguageLevel == languageLevel, "Actual language level and Expected language level do not match");
                driver.Close();
            }
        }   
        

       
      
        [When(@"User edits the existing '([^']*)' level to new '([^']*)'")]
        public void WhenUserEditsTheExistingLevelToNew(string language, string languageLevel)
        {
            LanguageObj = new Languag();
            LanguageObj.EditLanguage(language, languageLevel);
        }


        [When(@"User clicks on Update button to save language changes")]
        public void WhenUserClicksOnUpdateButtonToSaveLanguageChanges()
        {
            LanguageObj = new Languag();
            LanguageObj.updateButton();
        }

        [Then(@"User should see the '([^']*)' and '([^']*)'")]
        public void ThenUserShouldSeeTheAnd(string language, string languageLevel)
        {
            //Check success message
            string message = LanguageObj.GetMessage();
            string assertMessage = language + " has been updated to your languages";
            Assert.That(message == assertMessage, "Actual message and Expected message do not match");

            //check language and language level are created successfully
            string addedLanguage = LanguageObj.GetLanguage();
            string addedLanguageLevel = LanguageObj.GetLanguageLevel();
            Assert.That(addedLanguage == language, "Actual language and Expected language do not match");
            Assert.That(addedLanguageLevel == languageLevel, "Actual language level and Expected language level do not match");
            driver.Close();
        }
    

        [When(@"User deletes  '([^']*)'")]
        public void WhenUserDeletes(string language)
        {
            LanguageObj = new Languag();
           LanguageObj.DeleteLanguage(language);
           
        }

        [Then(@"User should not see the  '([^']*)' in the profile")]
        public void ThenUserShouldNotSeeTheInTheProfile(string language)
        {
        //Check message
        string message = LanguageObj.GetMessage();
        string assertMessage = language + " has been deleted from your languages";
        Assert.That(message == assertMessage, "Actual message and Expected message do not match.");

        //check if language is deleted successfully
        string lastLanguage = LanguageObj.GetLanguage();
        Assert.That(lastLanguage != language, "Expected language has not been deleted.");
        driver.Close();
    }
}

    }

