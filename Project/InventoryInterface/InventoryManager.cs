

namespace Project.InvInterface
{
    public interface IInventoryManager
    {
        InventoryModel[] Inventories { get; }
        InventoryModel Inventory(int itemId);
    }

    public class InventoryModel
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        public InventoryModel(int itemId, string name, string manufacturer, DateTime purchaseDate, DateTime expirationDate)
        {
            ItemId = itemId;
            Name = name;
            Manufacturer = manufacturer;
            PurchaseDate = purchaseDate;
            ExpirationDate = expirationDate;
        }
    }

    public class InventoryManager : IInventoryManager
    {
        private readonly IInventoryRepository inventoryRepository;

        public InventoryManager(IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }

        public InventoryModel[] Inventories
        {
            get
            {
                return inventoryRepository.Inventories
                                         .Select(t => new InventoryModel(t.ItemId, t.Name, t.Manufacturer, t.PurchaseDate, t.ExpirationDate))
                                         .ToArray();
            }
        }

        public InventoryModel Inventory(int itemId)
        {
            var inventoryModel = inventoryRepository.Inventory(itemId);
            return new InventoryModel(inventoryModel.ItemId, inventoryModel.Name, inventoryModel.Manufacturer, inventoryModel.PurchaseDate, inventoryModel.ExpirationDate);
        }
    }
}