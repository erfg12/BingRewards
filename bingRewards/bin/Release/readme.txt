Created by the New Age Soldier
Website: newagesoldier.com

How To Use
==========
It will use internet explorer (or Microsoft Edge) settings. If you have viruses or malware
on your PC, this program may not function correctly.

- Windows XP requires .net framework v4 and Enable All Cookies in IE.
  - http://www.microsoft.com/en-us/download/details.aspx?id=17851
  
- Windows 10 requires Always allow session cookies
  - Control Panel > Internet Options > Privacy (tab) > Advanced (button)

Step 1) Open accounts.txt with notepad and type in your windows live 
accounts email/password credentials. One account per line. 
If you intend on using a proxy, then you can use email/password/proxy/port

Step 2) You can change words.txt with notepad or leave them the 
way it is currently. It's completely up to you.

Step 3) Adjust your settings in the File > Settings menu.

Step 4) Start bingRewards.exe and press the start button and let it run.


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


