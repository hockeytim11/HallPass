![](TardyLoggerLogo.png)

Tardy Logger is an application designed for tracking and printing student tardy passes. At the moment, it is branded for Farrell B. Howell, but could easily be used for other schools.

# Features:
![image](https://user-images.githubusercontent.com/1467409/165199711-2addd964-bbdd-4b71-b83c-37656eabc63c.png)

## Student search
Accross the top of the page are search filters. They can be used to narrow the student list on the left of the screen.

### Student ID
This does a partial text match on the Student ID field. 123 will match 123,1234,51234, etc.

### Student Name
This support both first and last name searches in one box. The search pattern is Last,First

```
S,J would match "Smith, John"
,D would match "Guy, Dave"
```

Grade and Homeroom are both drop downs populated by the available data. They also have an -ALL- Option to remove the filter.

## Pass Type
Morning and Passing period changes the text on the pass for the various types.

## Pass Logs
The right hand side of the screen show a log of printed passes. This log is only a quick view to see what has been printed this session. The log will reset at each application launch.

The full log is stored in a google sheet. Each log entry is appended to the google sheet in addition to the app log.

# Printing
This application is designed to work with a Pomono PL330 thermal printer. It formats the text to fit in the 80mm width paper. While it was designed with that printer in mind, it likely works with other printers.
## Choosing a printer
The first time you click print each time the application is launched, you are presented with a windows print dialog. The printer you choose here will be saved until next launch and reused for each pass print.

## images
This application has the schools logo, but you can easily replace the HEADER.png and FOOTER.png files with custom images. Be aware that positioning is hard coded at the moment, so try to keep the dimensions the same for best results.

# Configuration
There is not much to configure, except the google sheets document ID and Sheet Names for the student data source and the pass logs.

## exe config
To configure the sheet, edit the TardyLogger.exe.config file. This application config uses JSON and allows for you to specify the sheet your google account has permissions to.

To get your sheed id, create a sheet in google sheets and edit the sheet. The URL in your browser bar will have the ID:

[https://docs.google.com/spreadsheets/d/**1o9dOdC6L3vVN09nvH4gRcXo-uP44XtE15UMeiCRkHG4**/edit#gid=767994701]()

The Sheet names need to match what you name then at the bottom of the sheet
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

The Students sheet needs to have 5 columns [Student ID	Last Name	First Name	Grade	Homeroom Teacher]. THe first row is ignored to allow for custom headers, so start your data on line2

| Student ID | Last Name | First Name | Grade | Homeroom Teacher |
|------------|-----------|------------|-------|------------------|
| 123456 | Student | Test | 1 | Teacher, Homeroom |
| 456789 | lastName | Person | 2 | Panther, Pink |
| 654321 | Bar | Foo | 3 | Tiger, Tony |

## Log sheet
The logging sheet will simply append any printed records to the first empty row in column A. Feel free to add/delete/edit rows, it shouldn't mess up the logging function. 
