Created by NeWaGe
Website: newagesoldier.com

How To Use
==========
This program uses the web browser control from visual studios.

It will use internet explorer settings. If you have viruses or malware
on your PC, this program may not function correctly. Be sure you have
a working copy of Internet Explorer.

For Windows XP users, be sure you accept all cookies on Internet Explorer.

Step 1) Open accounts.txt with notepad and type in your windows live 
account email/password credentials. One account per line.

Step 2) You can change words.txt with notepad or leave them the 
way it is currently. It's completely up to you.

Step 3) Start bingRewards.exe and press the start button and let it run.


How It Works
============
Using the seperate web browser will let you minimize the program
and let it run in its own window while still processing the pages.
The program first goes to login.live.com/logout, the site
automatically goes to msn.com and the program changes it back to
login.live.com/login and types in the credentials and presses the
login button for you using the GetAttribute/SetAttribute functions.

Once the web browser arrives at the rewards/dashboard page it will
trigger the startTimer function and continue once the startspeed
time is finished. The searchTimer function triggers and changes the
web browser URL to query bing and the function will continue to
trigger until the desktopsearches/mobilesearches limit is met.
Each change and timer is triggered when the document is completely
loaded in the web browser as to not interrupt the searches.


Settings Descriptions
=====================
startspeed 	-> After logging in, when does the searching start? In milliseconds.
searchspeedmin 	-> Search randimization in milliseconds. Lowest number.
searchspeedmax 	-> Search randimization in milliseconds. Highest number.
autostart 	-> Start searching when the program starts executing. 0=off 1=on.
hidebrowser 	-> Hides the browser window. Can be useful if you hear clicking noises.
mobilesearches 	-> How many times show this program do searches on Bing mobile?
desktopsearches -> How many times show this program do searches on Bing desktop?
autoclose 	-> After all accounts are done searching and the program finishes, should it close after 30 seconds? 0=off 1=on.
startminimized 	-> Start program minimized. Useful if program is setup on task scheduler.
searchtype 	-> Bing search types. image,video,map,news,explore or normal.

