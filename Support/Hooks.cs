using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using TechTalk.SpecFlow;

[Binding]

public class BeforeScenarioHooks

{

    private readonly IObjectContainer _objectContainer;       
    private IWebDriver _driver;


    public BeforeScenarioHooks(IObjectContainer objectContainer)
    {
        _objectContainer = objectContainer;
    }



    /// <summary>

    /// Here we are using the in-built Specflow object container to store a newly created driver instance for the scenario so that it can be injected into the Page Objects.

    /// </summary>
    

    [BeforeScenario("UI")]
    public void CreateBrowserInstance()
    {
        
        _driver = new ChromeDriver(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Driver"));

        _driver.Manage().Window.Maximize();

        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

        _objectContainer.RegisterInstanceAs(_driver);

    }

    [AfterScenario("UI")]
    public void DisposeBrowserInstance()
    {
        _driver.Dispose();
    }



}
