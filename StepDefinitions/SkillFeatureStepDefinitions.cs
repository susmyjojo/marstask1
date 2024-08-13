using NUnit.Framework;
using ProjectMarsAutomation.pages;
using ProjectMarsAutomation.Pages;
using ProjectMarsAutomation.utitlities;

namespace ProjectMarsAutomation.StepDefinitions
{
    [Binding]
    public class SkillFeatureStepDefinitions : CommonDriver
    {

        Skill skillObj;
        HomePage homePageObj;
        LoginPage LoginPageObj;

        [Given(@"Given enters valid username '([^']*)' and password '([^']*)'  clicks login button")]
        public void GivenGivenEntersValidUsernameAndPasswordClicksLoginButton(string username, string password)
        {
            LoginPageObj = new LoginPage();
            LoginPageObj.LoginActions(username, password);
        }
        [Given(@"user naviagate to skill tab and click Add new button")]
        public void GivenUserNaviagateToSkillTabAndClickAddNewButton()
        {
           
                
            skillObj = new Skill();
                       skillObj.clickAddnewButton();
        }

        [When(@"User navigates to Skill tab and User adds a  '([^']*)' with  '([^']*)' and clicks on Add button")]
        public void WhenUserNavigatesToSkillTabAndUserAddsAWithAndClicksOnAddButton(string skill, string level)
        {

            skillObj.AddNewSkill(skill, level);

        }
        [Then(@"User should see the '([^']*)' and '([^']*)'added to the profile")]
        public void ThenUserShouldSeeTheAndAddedToTheProfile(string skill, string level)
        {

            //assert message skill added successfully
            string assertMessage = skill + " has been added to your skills";
            string addedMessage = skillObj.GetMessage();
            Assert.That(addedMessage == assertMessage, "Actual message and Expected message do not match.");

            //assert if skill and skill level has been added accordingly
            string addedSkill = skillObj.GetSkill();
            string addedSkillLevel = skillObj.GetSkillLevel();

            Assert.That(addedSkill == skill, "Actual skill and Expected skill do not match");
            Assert.That(addedSkillLevel == level, "Actual skill level and Expected skill level do not match");
            driver.Close();
        }


        [Given(@"User navigates to Skill tab")]
        public void GivenUserNavigatesToSkillTab()
        {
            skillObj = new Skill();
            skillObj.ClickAnyTab("Skills");
        }


        [When(@"User edits the '([^']*)' level to new'([^']*)'")]
        public void WhenUserEditsTheLevelToNew(string skill, string level)
        {
            skillObj = new Skill();
            skillObj.EditSkill(skill, level);
        }

        [When(@"User clicks on Update button to save changes")]
        public void WhenUserClicksOnUpdateButtonToSaveChanges()
        {
            skillObj = new Skill();
            skillObj.UPdateSkill();
        }

        [Then(@"User should see the SQL and Intermediate")]
        public void ThenUserShouldSeeTheSQLAndIntermediate(string skill, string level)
        {
            //Check if popup message is correct
            string assertMessage = skill + " has been updated to your skills";
            string message = skillObj.GetMessage();
            Assert.That(message == assertMessage, "Actual message and Expected message do not match.");

            //Check if skill and skill level have been updated successfully
            string editedSkill = skillObj.GetSkill();
            string editedSkillLevel = skillObj.GetSkillLevel();

            Assert.That(editedSkill == skill, "Actual skill and Expected skill do not match.");
            Assert.That(editedSkillLevel == level, "Actual skill level and Expected skill level do not match.");
            driver.Close();
        }
        [When(@"User deletes skill '([^']*)'")]
        public void WhenUserDeletesSkill(string skill)
        {
            skillObj = new Skill();

            skillObj.DeleteSkill(skill);
        }

       

    [Then(@"User should not see the  SQL in the profile")]
    public void ThenUserShouldNotSeeTheSQLInTheProfile(string skill)
    {
        //Check if popup message is correct
        string assertMessage = skill + " has been deleted";
        string message = skillObj.GetMessage();
        Assert.That(message == assertMessage, "Actual message and Expected message do not match.");

        //Check if skill has been deleted
        string lastSkill = skillObj.GetSkill();
        Assert.That(lastSkill != skill, "Expected Skill has not been deleted successfully");
        driver.Close();
    }
}



       
    
    
}
