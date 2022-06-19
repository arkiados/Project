using System.Linq;

namespace Project.Models
{
    public interface IInventoryRepository
    {
        InventoryModel[] Inventories { get; }
        InventoryModel Inventory(int ItemId);
    }

    // returns an array of items
    public class InventoryRepository : IInventoryRepository
    {
        public InventoryModel[] Inventories
        {
            get
            {
                return DatabaseAccessor.Instance.Inventory
                                               .Select(t => new InventoryModel
                                               {
                                                   ItemId = t.ItemId,
                                                   Name = t.Name,
                                                   Manufacturer = t.Manufacturer,
                                                   PurchaseDate = t.PurchaseDate,
                                                   ExpirationDate = t.ExpirationDate
                                               })
                                               .ToArray();
            }
        }

        // returns one item - one data - which is the First()
        public InventoryModel Inventory(int ItemId)
        {
            var Inventory = DatabaseAccessor.Instance.Inventory
                                                   .Where(t => t.ItemId == ItemId)
                                                   .Select(t => new InventoryModel
                                                   {
                                                       ItemId = t.ItemId,
                                                       Name = t.Name,
                                                       Manufacturer = t.Manufacturer,
                                                       PurchaseDate = t.PurchaseDate,
                                                       ExpirationDate = t.ExpirationDate
                                                   })
                                                   .First();
            return Inventory;
        }
    }
}