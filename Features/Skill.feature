Feature:Skill Feature


Scenario Outline:1- user is able to add a Skill and choose a level and save
Given Given enters valid username '<username>' and password '<password>'  clicks login button 
And user naviagate to skill tab and click Add new button
When User navigates to Skill tab and User adds a  '<skill>' with  '<level>' and clicks on Add button 
Then User should see the '<skill>' and '<level>'added to the profile

Examples:
| username               | password     | skill|  level     |
| jojojoseph93@gmail.com | 123456789    | SQL  |  Intermediate  |


Scenario Outline:2-User is able to edit skill and level
Given enters valid username '<username>' and password '<password>'  clicks login button 
And User navigates to Skill tab
When User edits the '<skill>' level to new'<level>' 
And User clicks on Update button to save changes
Then User should see the '<skill>' and '<level>'
Examples:
| username               | password     | skill | level |
| jojojoseph93@gmail.com | 123456789    | SQL    | Beginner |
                   



Scenario Outline:3-User is able to delete skill
Given enters valid username '<username>' and password '<password>'  clicks login button 
And User navigates to Skill tab
When User deletes skill '<skill>'
Then User should not see the  '<skill>' in the profile
Examples:
| username               | password  | skill | 
| jojojoseph93@gmail.com | 123456789 | SQL   | 
