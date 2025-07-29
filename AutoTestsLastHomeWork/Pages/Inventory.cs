using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AutoTestsLastHomeWork.Pages;

public class Inventory
{
    public static IWebElement Sort => DI.Driver.FindElement(By.ClassName("product_sort_container"));
    public static IWebElement PriceAsc => DI.Driver.FindElement(By.CssSelector("option[value = 'lohi']"));
    public static IReadOnlyCollection<IWebElement> InventoryAll => DI.Driver.FindElements(By.CssSelector("div[class='inventory_item']"));
    public static By InventoryItemName = By.ClassName("inventory_item_name");
    public static By InventoryItemPrice = By.ClassName("inventory_item_price");

    public static IWebElement BurgerMenu = DI.Driver.FindElement(By.CssSelector("button[id ='react-burger-menu-btn']"));
    public static By Logout = By.CssSelector("a[id='logout_sidebar_link']");



}
