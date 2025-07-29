using Allure.NUnit;

namespace AutoTestsLastHomeWork.Tests.UITests;

[AllureNUnit]
public class BaseTests
{
    public BaseTests()
    {
    }

    [SetUp]
    public void Setup()
    {
    }

    [TearDown]
    public void TearDown()
    {
        DI.Driver.Navigate().GoToUrl("https://www.saucedemo.com/");
    }

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        DI.Driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        DI.Driver.Manage().Window.Maximize();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        DI.Driver.Close();
    }
}