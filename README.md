# HudlLoginTest Project

# SpecFlow Selenium Framework 
### Uses:  
+ SpecFlow (BDD)
+ Selenium (WebDriver)
+ Chrome browser v. 108.0.x
+ NUnit 3.x 
+ Gherkin (documentation generator for features and scenarios)
+ .Net 6
+ C# language
+ utilises Page Object Model pattern

#How to run in Visual Studio
1. Install Visual Studio 2022 (Should install .Net 6 automatically)
2. Install NuGet (package manager). http://docs.nuget.org/consume/package-manager-dialog#managing-packages-for-the-solution
3. Connect to github project and clone project locally 
4. The following should be installed automatically when project is cloned:
   NuGet (Project > Manage NuGet packages) to install Specflow, Nunit and Selenium:
  * NUnit 
  * NUnit.Runners 
  * NUnitTestAdaptor
  * SpecFlow
  * Specflow.NUnit
  * Selenuium http://nugetmusthaves.com/Tag/selenium
  * Selenium support package   
 5. Download chrome 
  * Check the chrome browser is version 108x
 6. Run test via Test Explorer
   
#Run from Command Line Prompt
1. Connect to github project and clone project locally 
2. Navigate to the Project folder on your local machine 
3. Inside the folder ...\HudlLoginTest\HudlLoginTest open CMD
4. Write the following "dotnet test"

# Notes:
+ The Hooks class contains code which runs before and after scenarios (and can be expanded to use other annotations)
+ The reason for using C# and not Python is due to extended experience in setting up frameworks in C#
