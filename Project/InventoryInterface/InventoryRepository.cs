

namespace Project.InvInterface
{
    public interface IInventoryRepository
    {
        InventoryModel[] Inventories { get; }
        InventoryModel Inventory(int itemId);
    }

    // returns an array of items
    public class InventoryRepository : IInventoryRepository
    {
        public InventoryModel[] Inventories
        {
            get
            {
                return DatabaseAccessor.Instance.Inventory
                                               .Select(t => new InventoryModel(t.ItemId, t.Name, t.Manufacturer, t.PurchaseDate, t.ExpirationDate))
                                               .ToArray();
            }
        }

        // returns one item - one data - which is the First()
        public InventoryModel Inventory(int itemId)
        {
            var Inventory = DatabaseAccessor.Instance.Inventory
                                                   .Where(t => t.ItemId == itemId)
                                                   .Select(t => new InventoryModel(t.ItemId, t.Name, t.Manufacturer, t.PurchaseDate, t.ExpirationDate))
                                                   .First();
            return Inventory;
        }
    }
}