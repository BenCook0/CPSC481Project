# CPSC481Project


Running the code:

To run this code, open the solution file in visual studio and run the code through the IDE.

Current Functionality and Future adjustments/additions

Home/logging in page - The main page includes a view interchanging pages taht can be chosen through the circle listed at the bottm of the page. The page also has a button marked with "?" to view how the process regarding logging in would be. To simplify the process, the User just needs to input the following credentials for device ID and password.
Device ID: User1
Password: Pass1
After the user has inputed the following credentials, he/she just nees to proceed by clicking the login button.

Welcome page - After logging in the user will land on the welcome page. The welcome page includes 4 buttons that will send you to the respective tabs or pages that can also be seen at the top bar. Proceed by clicking one of the 4 buttons or any of the tabs at the top.

Recent Data page - The recent data page hardly has any functionality as it is meant to simply display some weekly and daily data. The data will be displayed as average values pulled directly from the bitfit tracker. 

Graphs - Once landed on the graph page, the user is able to view multiple graphical displays of their tracked data. To use the graph page the user can simply click the button with a "?" as it will explain how to use it. If that still is difficult to understand, the user can simply choose either steps of calories from the drop down menu on the right of the page and individually choose a timeframe listed by the checkboxes at the top. When fixed viewing one timeframe, uncheck the box before clicking the next timeframe. The user can also get a more accurate timing display based on the scroll bar at the bottom of the screen. The user can simply click and hold the white bar and drag to a location along the blue bar. Once the user releases the bar, they can view the updated graph.

Goals - The goals page allows the user to click on one of their previous goals to view what timeframe they gave themselves along with their start values, end values, and current values. The goals also have an optional display of percentages and a percentage bar to visualize their progress. if the user wishes to add a new goal, they can simply just click the add new goal button at the bottom and a pop up page then comes up. Once in the popup page, the user can create the goal by adding a goal name (cant repeat a name), a start date and end date (start date must be after current date and end date after start date), a metric (steps, calories), start and end values (can be any numbers), and optional checkboxes. Once everything is filled out, the user simply clicks set new goal and the goal will be added. Once finished the user simply clicks cancel as he is done with the page and will then be sent back to the goals page to view all previous goals. (besides optional checkboxes, all fields must have an input)

Settings - This settings page has no functionality but displays some user data

Log out button - Takes the user back to the home/logging in page. 

Overall considerations:

There are still several bugs and design problems with this setup. However these are primarily minute details such as better handling of whitespace, sizing etc. (the recent data page for example has way too much white space between the daily and weekly sections). The only major design problem that we still have to address on a macro level is the mechanism for viewing workouts on the recent data page. The current hand-drawn prototypes have this information displayed directly on the page, whereas the online version has a stubbed-in textbox/button that may allow users to view a popup. This will be modified and changed by the final project based on feedback from users, as well as our instructions/classmates.
