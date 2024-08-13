using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProjectMarsAutomation.utitlities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMarsAutomation.Pages
{
    internal class Skill : CommonDriver
    {

       
        private By ByAddNewSkillButton = By.XPath("//div[@class=\"ui teal button\"]");
        private By skillButton = By.XPath("//a[@class=\"item\" and @data-tab=\"second\"]");

        private IWebElement SkillTextBox = driver.FindElement(By.XPath("//div[@class='ui teal button' and contains(text(), 'Add New')]"));
        private By BySkillTextBox = By.XPath("//input[@type=\"text\" and @placeholder=\"Add Skill\" and @name=\"name\"]");
        private IWebElement skill => driver.FindElement(By.XPath("//div[@data-tab='second']//table/tbody[last()]/tr/td[1]"));
        private IWebElement addedSkillLevel => driver.FindElement(By.XPath("//div[@data-tab='second']//table/tbody[last()]/tr/td[2]"));
        private IWebElement AddButton => driver.FindElement(By.XPath("//input[@value='Add']"));
        private IWebElement editButton => driver.FindElement(By.XPath("//span[@class=\"button\"]/i[@class=\"outline write icon\"]"));
        private IWebElement SkillLeveldropdown => driver.FindElement(By.XPath("//select[@name='level']"));
        private IWebElement message => driver.FindElement(By.XPath(e_message));
        private IWebElement deletedSkill => driver.FindElement(By.XPath(e_recordLastSkill));
        private IWebElement DeleteButton => driver.FindElement(By.XPath("//div[@data-tab='second']//table/tbody[last()]/tr/td[3]/span[2]"));
        private By ByUpdateButton => (By.XPath(e_UpdateButton));
        private IWebElement CompleteUpdateButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        private IWebElement tabOption => driver.FindElement(By.XPath("//div[@class = 'ui top attached tabular menu']/a[2]"));


        //wait elements
        private string e_recordLastSkill = "//div[@data-tab='second']//table/tbody[last()]/tr/td[1]";
        private string e_UpdateButton = "//div[@data-tab='second']//table/tbody[last()]/tr/td[3]/span[1]";
        private string e_tab = "//div[@class='ui top attached tabular menu']";

        private string e_message = "//div[@class='ns-box-inner']";

       
        public void clickAddnewButton()
        {
            //IWebElement SkillButton = driver.FindElement(BySkillButton);
            //Click on skill
            IWebElement SkillButton = driver.FindElement(skillButton); 
           SkillButton.Click();
            //Click on add new button
            IWebElement AddNewSkillButton = driver.FindElement(ByAddNewSkillButton);
            AddNewSkillButton.Click();

        }
        public void AddNewSkill(string skill, string level)
        {

            IWebElement SkillTextBox = driver.FindElement(BySkillTextBox);
            SkillTextBox.Click();
            SkillTextBox.SendKeys(skill);
            //choose level 
            var selectSkillLevel = new SelectElement(SkillLeveldropdown);
            selectSkillLevel.SelectByValue(level);

            //Click add
            AddButton.Click();
        }
        public string GetMessage()
        {

            Waitutilities.WaitToBeVisible(driver, "XPath", e_message, 3);
            return message.Text;
        }
      
        public string GetSkill()
        {
            //get last skill record 
            try
            {
                return skill.Text;
            }
            catch (Exception)
            {
                return "locator not found";
            }
        }
        public string GetSkillLevel()
        {
            //Get last skill level record
            return addedSkillLevel.Text;
        }


        public void ClickAnyTab(string tab)
        {
            //Wait for tabs to be visible
            Waitutilities.WaitToBeVisible(driver, "XPath", e_tab, 3);

            //Click on specified tab
            tabOption.Click();
        }
        //to edit the skill


        public void EditSkill(string skill, string level)
        {
            //Wait
             Waitutilities.WaitToBeClickable(driver, "XPath", e_UpdateButton, 5);
          
            //Click edit button
            IWebElement UpdateButton = driver.FindElement(ByUpdateButton);
            UpdateButton.Click();
            
            IWebElement SkillTextBox = driver.FindElement(BySkillTextBox);
            //Edit Skills
            SkillTextBox.Clear();
            SkillTextBox.SendKeys(skill);

            //Edit Skill level
            var selectSkillLevel = new SelectElement(SkillLeveldropdown);
            selectSkillLevel.SelectByValue(level);


        }

        public void UPdateSkill()
        {
            //Click Update
            CompleteUpdateButton.Click();
         
        }


   

        //Click on delete button
        public void DeleteSkill(string skill)
        {
          

            try
        {
            //Wait for Skill loaded
            Waitutilities.WaitToBeVisible(driver, "XPath", e_recordLastSkill, 3);

            //Check if skill is the one to be deleted
            if (deletedSkill.Text == skill)
            {
                //Click Delete button
                DeleteButton.Click();
            }
            else
            {
                Assert.Fail("No matching skill is not found.");
            }
        }
        catch (Exception)
        {
            Assert.Fail("No skill is found.");
        }
    }

}
}
