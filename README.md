BingRewards
===========

Developed in VS .net 2017 using C# with AutoIt and EO.WebBrowser.

## OVERVIEW

This program will search Bing’s site automatically! It utilizes the web browser functions of visual studio, HTML DOM element objects and header modifications to log in, log out and search pages. You can use as many Bing accounts as you want, and search as fast as you want. This software has lots of customization settings including maximum searches, the speed of starting and searching, automatic starting option, automatic closing upon completion option and to add your own custom words to its selection of words to query.

## FEATURES

* Works on Windows XP, Vista, 7, 8, 8.1 and 10
* Can minimize and let it work in the background.
* Different search types (images, videos, news, maps, and explore)
* Adjustable Randomized Search Speeds
* Custom Query Quantities
* Automatically start, minimize and close upon completion (closing takes 30 seconds after completion)
* Dictionary file of searchable words
* Uses customized WebBrowser class separate from your computers web browser!
* Unlimited Bing accounts.
* Can use Proxies.
* Microsoft Edge user-agent spoofing.
* Random search times, and deleting login cookies to keep your accounts safe.
* 100% free to use & Open source!

## HOW TO USE

Modify accounts.txt to your Windows Live accounts.
You can also change words.txt to whatever random words you want generated to search by.
Use the File > Settings menu in the program to change search values.

## IMPORTANT INFORMATION

Windows XP requires .net framework v4 and Enable All Cookies
To automate this process use the Windows Task Scheduler located in
Control Panel > Administrative Tools > Task Scheduler

Select the Action tab > Create Basic Task option to create a task that can execute every day.

## HOW IT WORKS

This program uses the Visual Studios .net browser module to search the bing website. It then uses the DOM elements to click buttons and type in text boxes. Since every aspect of this program is self contained, we can use other options like hiding the browser window, minimizing the program and adjusting search speeds. Since this program is very simple in what it does I have released the source code.
