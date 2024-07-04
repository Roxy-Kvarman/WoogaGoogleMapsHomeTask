# Test automation project - WoogaGoogleMapsHomeTask

This is a C# project for test automation based on Wooga company requirements and implemented as home testing task.

## Concepts Included

* Local and in pipeline tests run
* Test configuration for local run with config .json file
* Test configuration for pipeline run with environment variables
* Tests parameterization with test data .json file
* Multiple browsers support
* Positive and negative scenarios
* Dependency injection
* Page Object Model design pattern
* Drivers factory
* Commonly used utility classes
* Reporting
* Logging
* Code documentation
* CI integration

## Tools

* Nunit
* Selenium Webdriver
* Selenium Wait helpers
* Extent reports
* GitHub actions
* Newtonsoft Json
* WebDriver Manager

## Requirements

In order to utilise this project you need to have the following installed locally:

* .NET 8.0
* Microsoft.NET.Test.Sdk 17.10.0
* Nunit 4.1.0
* Nunit3TestAdapter 4.5.0
* NunitAnalyzers 4.2.0
* Selenium.WebDriver 4.22.0
* Selenium.Support 4.22.0
* WebDriverManager 2.17.4
* DotNetSeleniumExtras.WaitHelpers 3.11.0
* ExtentReports 5.0.4
* Newtonsoft.Json 13.0.3
* System.Drawing.Common 8.0.6
* Microsoft.Extensions.DependencyInjection 8.0.0
* Microsoft.Extensions.DependencyInjection.Abstractions 8.0.1

## Project schema

The project contains the following logical modules:
* Configuration
* DependencyInjection
* DriversFactory
* Pages
* Reports
* Tests
* TestsData
* Utilities

## Project main features
### External test configuration
The project implements external test configuration when config.json file contains configuration settings,<br/>
such as browser name, for example.

### Multiple browsers support
The project supports the following browsers by implementing Drivers factory desing pattern: 
* Crome
* Firefox
* Edge
  
Browsers are installed in the time of execution with the help of WebDriverManager.
 
### Page object model and tests isolation
The project implements POM design pattern. It treats application pages as single objects and separates tests from POM classes.<br/>
Tests are isolated from each other and don't have any shared dependencies.

### Tests parameterization
The project uses tests parameterization.<br/> 
File testData.json contains test data for positive and negative scenarios.<br/>
Retrieved data targets only dedicated tests.<br/>

### Utilities
Utilities contains extensions generic methods for selenium that allow to facilitate common actions.

### Reporting
Reporting implementation operates as report generator and logger.<br/>
With the help of Dependency Injection the singleton of Reporter instance is created<br/> 
allowing to gather all tests results in single report .html file.<br/>
Tests results can be found in /Reports/TestResults project directory.<br/>
This file can be opened in browser to review tests results.<br/>
The screenshot is taken in case of test failure.<br/> 
The image can be opened from report .html file by clicking on image icon.<br/>

## Configuration for local tests run
Tests can run locally from the project TestsExplorer or from terminal with command "dotnet test --no-build --verbosity normal".<br/>
Browser type should be defined in config.json file like this:<br/>
{<br/>
  "browser": "chrome"<br/>
}<br/>
When running tests locally, browser is opened in UI mode in order to see the tests execution.<br/>
Tests results can be found in project directory /Reports/TestsResults.<br/>
To see the results - the directory should be opened in file explorer and then the html report can be opened in browser.<br/>
### Important!
For the purposes of the home testing task - 1 test always fails in order to demonstrate passed and failed tests in the report<br/> 
and also to show screeshot taking.

## CI Integration
CI integration is implemented with the help of github actions.<br/>
Created workflow can be found in the repository in section "Actions".<br/>
The workflow is manually triggered. To start the workflow - you need to click "Run workflow" button<br/>
and select browser from a drop down list. By default "chrome" browser is selected.<br/>
When running in pipeline - browser type is arrived from environment variable to the project.<br/>
Browser runs in a headless mode and specific resolution.<br/>
File main.jml manages pipeline tests run and can be found in the project solution directory.<br/>
Tests results are generated as .trx file and populated with the help of "dorny/test-reporter" github action.<br/>
### Important!
For the purposes of the home testing task - 1 test always fails in order to demonstrate passed and failed tests in the report.<br/>
It means that the step "Run tests" will be marked as failed (red).<br/>
### GitHub Actions issue with pupulating tests results in currently running workflow
It's important to mention that github actions has issue with population tests results in the same workflow.<br/>
As it occurs, tests results publishing feature supports only workflows triggered by new commits.<br/>
It means that for manually triggered workflows - <br/>
tests results can be published unexpectedly in older workflows and not in the current one that has just run.<br/>
It is a known issue and for now it's not prioritized by GitHub development team.<br/>
For more information about the issue  -  [Click here](https://github.com/dorny/test-reporter/issues/67)<br/>
Concerning this - the best way to look into the workflow tests results - <br/>
it is to open the workflow job -> step "Upload tests results" -> section "Creating tests report".<br/>
And then click on link "Check run HTML". Tests results will be opened in a new browser tab of github actions.<br/>

