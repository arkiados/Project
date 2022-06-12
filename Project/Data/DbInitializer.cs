using System;
using System.Linq;
using Project.Models;

namespace Project.Data
{
    public class DbInitializer
    {
        public static void Initialize(InventoryContext context)
        {
            context.Database.EnsureCreated();

            // Look for any items.
            if (context.Inventory.Any())
            {
                return;   // DB has been seeded
            }

            var inventoryItems = new InventoryItem []
            {
                new InventoryItem{Name="Peanut Butter",Manufacturer="Jiff",PurchaseDate=DateTime.Parse("2022-03-28"),ExpirationDate=DateTime.Parse("2022-09-15")},
                new InventoryItem{Name="CoCo Lunies",Manufacturer="Walmart",PurchaseDate=DateTime.Parse("2021-05-26"),ExpirationDate=DateTime.Parse("2022-02-21")},
                new InventoryItem{Name="Potatoes",Manufacturer="Idaho",PurchaseDate=DateTime.Parse("2022-05-15"),ExpirationDate=DateTime.Parse("2022-07-23")},
                new InventoryItem{Name="Apple Sauce",Manufacturer="Sauce Kings",PurchaseDate=DateTime.Parse("2021-09-01"),ExpirationDate=DateTime.Parse("2022-05-03")},
                new InventoryItem{Name="Oatmeal",Manufacturer="Quaker",PurchaseDate=DateTime.Parse("2019-08-06"),ExpirationDate=DateTime.Parse("2020-08-09")},
                new InventoryItem{Name="Beef Jerky",Manufacturer="Kirkland",PurchaseDate=DateTime.Parse("2021-06-03"),ExpirationDate=DateTime.Parse("2022-06-12")},
                new InventoryItem{Name="Honey",Manufacturer="Bees",PurchaseDate=DateTime.Parse("2015-09-07"),ExpirationDate=DateTime.Parse("2025-12-07")},
                new InventoryItem{Name="Dill Pickles",Manufacturer="Pickle Town",PurchaseDate=DateTime.Parse("2021-11-11"),ExpirationDate=DateTime.Parse("2022-12-30")},
                new InventoryItem{Name="Jasmine Rice",Manufacturer="South Asian Cuisine",PurchaseDate=DateTime.Parse("2020-07-15"),ExpirationDate=DateTime.Parse("2022-10-24")},
                new InventoryItem{Name="Tomato Soup",Manufacturer="Campbells",PurchaseDate=DateTime.Parse("2021-10-22"),ExpirationDate=DateTime.Parse("2022-08-30")},
            };
            foreach (InventoryItem s in inventoryItems)
            {
                context.Inventory.Add(s);
            }
            
            context.SaveChanges();
        }
    }
}