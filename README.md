# Task Tracker

Simple task tracker in command line. To build app you have to use .net version 8.0 or later.
Download project and run command **dotnet publish** in root folder to build application. The application itself is going to be created in _TaskTracker/bin/release/net8.0/publish_ folder. Then you can run app by **TaskTracker.exe \<args\>**

Task Tracker Help

| Actions                 | Arguments                                   |
| ----------------------- | ------------------------------------------- |
| Add task                | add "\<task description\>"                  |
| Update task description | update \<id\> "\<new descripton\>"          |
| Delete task             | delete \<id\>                               |
| Update task status      | mark-\<in-progress \| todo \| done\> \<id\> |
| List all tasks          | list                                        |
| List tasks by status    | list \<todo \| in-progress \| done\>        |
