# Description
A database management system for a tile shop with front end on Visual C# and back end on SQL Plus.

# Setup
This project was created in Visual Studio 2015 development environment. Just clone the project and open in Visual Studio.
You might have to install the **Oracle Developer Tools for Visual Studio**. Follow the link 
http://www.oracle.com/technetwork/topics/dotnet/whatsnew/vs2012welcome-1835382.html
and download the zip file. It is required to integrate SQL Plus and visual studio.
Use the SQL_tables file to create all the required tables and fill them with dummy values.
All the sql functions and triggers used are also provided.

# Features
1. The project comprises of two modes of operation- View Mode and Edit Mode.
2. Previously saved data is automatically fetched and loaded in drop down menus, in real time, making the interface user friendly
as the typing work reduces. Real time fetching ensures that changes are updated without reloading the whole project.
3. An employee has the authority to modify all the tables except the login and employee table, for which it requires owner authentication.
4. Add, Update and Delete options are avaialble for every table.
5. Previously built orders can be used/modified for serving new or old customers.
