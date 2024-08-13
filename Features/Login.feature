Feature:Log in Feature


Scenario: 1- user is able to login to the system and view his profile
Given user enters valid username '<username>' and password '<password>'  clicks login button 
Then User should be redirected to the home page and User should see his name on the topright 
Examples:
| username               | password  |
| jojojoseph93@gmail.com | 123456789 |

  

