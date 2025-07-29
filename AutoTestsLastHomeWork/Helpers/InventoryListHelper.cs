using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoTestsLastHomeWork.Pages;
using Microsoft.VisualBasic;
using OpenQA.Selenium;

namespace AutoTestsLastHomeWork.Helpers;

public class InventoryListHelper
{
    public List<Product> ListInventory()
    {
        List<Product> products = new List<Product>();
        var inventoryItems = Inventory.InventoryAll;

        foreach (var item in inventoryItems)
        {
            string name = item.FindElement(Inventory.InventoryItemName).Text;
            string priceText = item.FindElement(Inventory.InventoryItemPrice).Text;

            //преобразуем цену в decimal извлечением значения через регулярку
            string numericPart = Regex.Match(priceText, @"\d+\.?\d*").Value;
            decimal price = decimal.Parse(numericPart, CultureInfo.InvariantCulture);

            products.Add(new Product { Name = name, Price = price });
        }
        return products;
    }
}
public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}
//Это переопределение equal для корректного сравнения листов, посмотрел у синего друга
public class ProductEqualityComparer : IEqualityComparer<Product>
{
    public bool Equals(Product x, Product y)
    {
        if (x == null || y == null) return false;
        return x.Name == y.Name && x.Price == y.Price;
    }

    public int GetHashCode(Product obj)
    {
        return HashCode.Combine(obj.Name, obj.Price);
    }
}
