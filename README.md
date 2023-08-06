# InfoTrack UK Application - SEO
### Introduction
The InfoTrack UK Application is a web-based tool designed to help the CEO of InfoTrack UK to see the ranking of Info Track's website on Google or Bing search results for specific keywords. It allow users to enter a keyword and URL then crawls Google/Bing search results to find the rank of InfoTrack's website results.

This app is currently running on .NET Framework 4.8

### Features
1. Enter a keyword and find the rank of InfoTrack's website in Google/Bing search results.
2. View the history of search results and ranks over time.

### Prerequisites
1. Visual Studio (with .NET Framework)
2. SQL Server Express

### Setup
1. Clone the repository or download the ZIP archive.
2. Open the solution in Visual Studio(I used VS 2019).
3. Restore NuGet packages if needed.
4. Open the Web.config file and modify the connection string to point to your SQL Server Express database. Connection String given at the end.
5. Build the solution to ensure all dependencies are resolved.
6. Run the application using Visual Studio's built-in IIS Express or publish it to a web server of your choice.

### Usage
1. Launch the application in a web browser.
2. On the homepage, enter keyword, URL and select search engine then click the "Get Ranks" button.
3. The application will crawl search results for the entered keyword and URL and display the rank of the InfoTrack's website.
4.You can view the history of search results by clicking the hyperlink to see search results history on the screen.

### Key Technologies
1. ASP.NET MVC: A robust framework for building web applications.
2. C#: The programming language that powers the application's logic.
2. Entity Framework: Seamlessly manage data interactions and database operations.
4. Unity Dependency Injection: Maintain clean code by managing component dependencies.
5. HTML/CSS: Crafted for a polished and user-friendly interface.
6. JavaScript (AngularJS): Enhance interactivity and provide a seamless user experience.
7. SQL Server: Store and retrieve search history and relevant data.

### Credits
This project was developed as a demonstration for InfoTrack's Ranking App initiative by Nabeel Ahsan.

### Connection String
Can be found in Web.Config file in connectionStrings tags.

### More
1. Replace 'data source' in connection string to your own SQL server connection name and 'initial catalog' to Database name.
2. SQL scripts to execute can be found in project at path
'~\DbScript\InfoTrackSQLScript.sql'.

### Unit Test

1. with 0 ranks for infotrack uk.
2. tried with gov.uk; Data coming through but struggling with which attribute gives correct position/rank.

<img width="896" alt="image" src="https://github.com/mnabeelahsan/InfoTrackUk_RankerApp/assets/141588155/8f832070-ae17-43d7-b9e9-d2a62cbb7614">
<img width="896" alt="image" src="https://github.com/mnabeelahsan/InfoTrackUk_RankerApp/assets/141588155/82a8c989-887d-47e2-898d-4a9c74e91713">


