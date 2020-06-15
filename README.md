# 2020-Team-Gamma

## ACU-Insights 

ACU-Insights is a customization project that allows system administrators to collect user's data on how effectively Acumatica is used. The user is monitored for active/inactive time on a specific screen as well as elapsed time for completing a transaction. This data is then displayed on a Generic Inquiry (GI), which can be customized to show the data. An administrator or team could create views that show the average time per Order Entry, fastest Order Entry agent, agents with the most edits, etc. Currently it is functioning on the Sales Order and Accounts Receivable screens.

## Installation:
From within Acumatica Customization Projects, Upload and publish the project.

Loading this customization project is a bit non-standard. Do not try to import as a normal .zip, which is the usual way of importing customization projects. Instead:
1) Create a new empty customization project.
2) Then go to Source Control > Open Project From Folder.
3) A pop up will appear where you need to input the path to the folder which is located under the _CustomizationProject Folder. This will load the contents into the empty customization project and you can then publish. 

Also, for this project to work you many need to replace the master pages and the page title file (in Controls folder) manually, as they are not always replaced upon publish. This module functionality currently only works for only a limited number of screens within the Acumatica instance. If you need the functionality in other screens, then additional logic and customization would be required. You the implemented screens there as a guideline. 
