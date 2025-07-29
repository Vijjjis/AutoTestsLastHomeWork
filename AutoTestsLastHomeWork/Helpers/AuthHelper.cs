using AutoTestsLastHomeWork.Pages;
using OpenQA.Selenium;

namespace AutoTestsLastHomeWork.Helpers;

public class AuthHelper : BaseHelper
{
    public AuthHelper(IWebDriver driver) : base(driver)
    {
    }
    public void Authorization(string login, string password)
    {
        DI.AllureReportHelper.RunStep($"Авторизация на сайте под Login = {login} and password = {password}", () =>
        {
            StartPage.Login.SendKeys(login);
            StartPage.Password.SendKeys(password);
            StartPage.Submit.SendKeys(Keys.Enter);
        });
    }
    public void Logout()
    {
        DI.AllureReportHelper.RunStep($"Выход", () =>
        {
            Inventory.BurgerMenu.Click();
            DI.BaseHelper.WaitElementUntilClickable(Inventory.Logout);
            DI.Driver.FindElement(Inventory.Logout).Click();
        });
    }
}
