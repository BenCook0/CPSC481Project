# CPSC481Project


Running the code:

To run this code, open the solution file in visual studio and run the code through the IDE.

Current Functionality and Future adjustments/additions

Home/logging in page - Allows for click the black "?" to toggle a popup. This popup currently has stubbed in text and will be used as a template for all other information popup. Also allows the user to click login to navigate to the main welcome page. The device ID and device password boxes currently have no functionality but this will be implemented later

Welcome page - Currently has buttons, these will likely be implemented later to open specific tabs

Recent Data page - Currently has stubbed in data for daily and weekly. Also has blue boxes stubbed in for where the icons will go. These icons will either be created by us, or taken digitally from somewhere else. Furthermore, the "Workouts" section has been stubbed in for a textbox. We are still figuring out the best way to display an individual's workouts (popup, scrollable menu etc).

Graphs - Currently the graphs page just has a simple picture of a graph. This will later display actual data and will be adjustable based on the toggleable boxes. Furthermore, the "?" popup has no functionality but will later have behavior similar to the "?" on the home/loggin in page.

Goals - The goals page currently hasa few goals stubbed in temporarily. Eventually users will be able to view a list of all their goals, delete existing goals, or add goals through the set new goal popup.

Set New Goal Popup - Opened by clicking the set new goal popup. NOTE: currently CANNOT BE CLOSED without just pressing the log out button and then logging back in. The way we are coding this section is different to the information popups as it has more functionality to be implemented and will require more complex interaction design. To close this popup just press Log Out and then log back in.

Settings - This settings page was just stubbed in as we feel it is necessary to include in the final project. These buttons are unlikely to be given any functionality even for our final submission.

Log out button - Takes the user back to the home/logging in page. NOTE: there is currently a bug that causes some spacing/size issues to occur when navigating back to the login page

Overall considerations:

There are still several bugs and design problems with this setup. However these are primarily minute details such as better handling of whitespace, sizing etc. (the recent data page for example has way too much white space between the daily and weekly sections). The only major design problem that we still have to address on a macro level is the mechanism for viewing workouts on the recent data page. The current hand-drawn prototypes have this information displayed directly on the page, whereas the online version has a stubbed-in textbox/button that may allow users to view a popup. This will be modified and changed by the final project based on feedback from users, as well as our instructions/classmates.
