using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AutoTestsLastHomeWork.Pages;

public class StartPage
{
    public static IWebElement Login = DI.Driver.FindElement(By.CssSelector("input[id='user-name']"));
    public static IWebElement Password = DI.Driver.FindElement(By.CssSelector("input[id='password']"));
    public static IWebElement Submit = DI.Driver.FindElement(By.CssSelector("input[id='login-button']"));


}
