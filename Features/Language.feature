Feature:Language Feature

Scenario Outline:1- user is able to add a language and choose a level and save
Given enters valid username '<username>' and password '<password>'  clicks login button 
When user naviagate to language tab and click Add new button
And User adds a language '<language>' with level '<level>' clicks  Add button
Then User should see the language '<language>' '<level>' added to the profile

Examples:
| username               | password     | language |  level     |
| jojojoseph93@gmail.com | 123456789    | English  |  Basic  |



Scenario Outline:2-User is able to edit language and level
Given enters valid username '<username>' and password '<password>'  clicks login button 
When User edits the existing '<language>' level to new '<level>'
And User clicks on Update button to save language changes
Then User should see the '<language>' and '<level>'
Examples:
| username               | password     | language |  level     |
| jojojoseph93@gmail.com | 123456789    | English  |  Fluent |




Scenario Outline:3-User is able to delete language
Given enters valid username '<username>' and password '<password>'  clicks login button 
When User deletes  '<language>'
Then User should not see the  '<language>' in the profile
Examples:
| username               | password     | language |  level     |
| jojojoseph93@gmail.com | 123456789    | English  |  Fluent |

