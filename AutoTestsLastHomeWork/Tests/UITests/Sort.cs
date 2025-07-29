using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoTestsLastHomeWork.Helpers;
using AutoTestsLastHomeWork.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutoTestsLastHomeWork.Tests.UITests;

public class Sort : BaseTests
{
    [Test]
    public void SortByPriceLow()
    {
        DI.AuthHelper.Authorization("standard_user", "secret_sauce");
        var listPrice = DI.InventoryListHelper.ListInventory();
        DI.AllureReportHelper.RunStep($"Состав списка товаров с сайта в стандартной сортировке", () =>
        {
            foreach (var item in listPrice)
            {
                DI.AllureReportHelper.MessageInNewStep($"{item.Name} {item.Price}");
            }
        });

        DI.AllureReportHelper.RunStep($"Задаем сортировку по увеличению цены на сайте", () =>  
        {
            Inventory.Sort.Click();
            Inventory.PriceAsc.Click();
        });
        var listPriceAsc = DI.InventoryListHelper.ListInventory();
        DI.AllureReportHelper.RunStep($"Состав отсортированного списка товаров с сайта", () =>
        {
            foreach (var item in listPriceAsc)
                DI.AllureReportHelper.MessageInNewStep($"{item.Name} {item.Price}");
        });
        DI.AllureReportHelper.RunStep($"Сравниваем сортировку вручную и с сайта", () =>
        {
            var sortedlistPrice = listPrice.OrderBy(p => p.Price).ToList();
            foreach (var item in sortedlistPrice)
                foreach(var item2 in listPriceAsc)
                    if (item.Name == item2.Name && item.Price == item2.Price)
                        DI.AllureReportHelper.MessageInNewStep($"Значения совпадают: {item.Name} {item.Price}");
        });
        DI.AuthHelper.Logout();
    }
}
