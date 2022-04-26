![](TardyLoggerLogo.png)

Tardy Logger is an application designed for both logging student tardies and printing tardy passes. Although it is branded for Farrell B. Howell ECE-8 School it  could easily be used for other schools but simply updating the header/footer image files.

# Features:
![image](https://user-images.githubusercontent.com/1467409/165199711-2addd964-bbdd-4b71-b83c-37656eabc63c.png)

## Student Search
Accross the top of the page are search filters. They can be used to narrow the student list on the left of the screen.

### Student ID
Seaches the 6-digit district-assigned Student ID number. The field uses a partial text match on the Student ID field from the data set. (123 will match 123,1234,51234, etc.)

### Student Name
Searches the student name with the ability to search for first and/or last name in the search field. Search pattern is LAST,FIRST.
The search is case insensitive and will match any part of the name.

```
S,J would match "Smith, John"
,D would match "Guy, Dave" and "Last, asdf"
Smith,John would match "Smithson,Johnathan" and "Jones-Smith,John"
```

Grade and Homeroom are drop down filters populated by the available data. They also have an '-ALL-' option to clear the filter.

## Pass Type
The school uses this applications for both Morning Tardy Passes, as well as Passing Period Tardy Passes. The pass type option is both logged in the Google Sheet and also printed on the physical pass.

## Pass Logs
The right hand side of the screen show a temporary log of printed passes during the current session which resets at each application launch.
The complete log is stored in a Google Sheet. Each log entry is appended to the Google Sheet in addition to the app log.

# Printing
This application is designed to print a physical tardy/hall pass using the Polono PL330 Receipt Printer and formatted to fit the default 80mm width thermal paper. While it was designed with that printer in mind, it likely works with other printers.

## Choosing a printer
When you click to PRINT/LOG the first entry (when application is launched) you are presented with a windows print dialog and must select the thermal receipt printer you are using. The printer you choose is saved until you relaunch the application. The current printer is reused for each physical pass printed during the current session.

## Images
This application uses custom PNG files for the header and footer on the physical passes that are printed. Simply replace the HEADER.png and FOOTER.png files with your own custom images. Be aware that positioning is hard coded at the moment, so try to keep the dimensions the same for best results. Dimensions for the header and footer images are 2:1 (width:height).

# Configuration
There is not much to configure, except the Google Sheet ID and the Sheet Names for student data source and the pass log.

## exe config
To configure the sheet, edit the TardyLogger.exe.config file. This application config uses JSON and allows you to specify Google Sheets to which your account has access.
To get your sheed id, create a sheet in google sheets and edit the sheet. The URL in your browser bar will have the ID:

A spreadsheet ID can be extracted from its URL. For example, the spreadsheet ID in the URL https://docs.google.com/spreadsheets/d/abc1234567/edit#gid=0 is "abc1234567".

The Sheet Name must match what you name then at the bottom of the sheet:
![image](https://user-images.githubusercontent.com/1467409/165202224-a92ade4c-9d26-452a-9aa3-bd0eaa95d1d0.png)


```
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <appSettings>
    <add key="sheet" value="[Sheet ID]" />
    <add key="log" value="[Log Sheet Name]" />
    <add key="students" value="[Student Data]" />
    <add key="ClientSettingsProvider.ServiceUri" value="" />
  </appSettings>
</configuration>
```

## Students sheet

The Students sheet needs to have 5 columns [Student ID	Last Name	First Name	Grade	Homeroom Teacher]. The first row is ignored to allow for custom headers, so start your data on line2

| Student ID | Last Name | First Name | Grade | Homeroom Teacher |
|------------|-----------|------------|-------|------------------|
| 123456 | Student | Test | 1 | Teacher, Homeroom |
| 456789 | lastName | Person | 2 | Panther, Pink |
| 654321 | Bar | Foo | 3 | Tiger, Tony |

## Log Sheet
The Google Sheet will simply append any printed records to the first empty row in column A. Feel free to add/delete/edit rows, it shouldn't mess up the logging function. 
