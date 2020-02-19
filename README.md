# Notepad 95
Online notepad.
* Link to working web app: http://notepad95.hostingasp.pl/

![Alt text](screenshots/s1.PNG?raw=true "screenshots/s1.PNG")   
I created it because wanted to try Blazor and web development. It has basic functionality.

## How does it work?
* It's very similar to shrib.com
* When you enter site it generates random page for you.
* You can edit and save it. Everyone can also view it and edit it.
* You can create custom links by entering custom file name after address: http://notepad95.hostingasp.pl/myfile

## Architecture
It's created with DotNet Core 3.1
* Blazor WASM for frontend
* ASP.NET Core Web Application for backend
* SQLite for database
* Hosted on webio

## Api
* You can use this link to force update any file: http://notepad95.hostingasp.pl/force

## Contribute
I don't plan to develop this application, but you are more than welcome to contribute! I think it's great way of learning on many levels, you can learn:
* Blazor
* ASP.NET Core Web API
* C#
* GIT, contributing to GitHub
* Reading and improving someone else's code

## Contribution ideas
1. Improve UI.
1. Autosave after 5 seconds of user inactivity instead of Save button.
1. Optional feature: protect notepad file with password. For example you can protect it from viewing&editing or only editing.
1. View only mode
1. Renaming note
1. Prevent too frequent server calls / DOS attacks.
1. Create all files list
1. ???
