

namespace Project.Models
{
    public class DatabaseAccessor
    {
        static DatabaseAccessor()
        {
            Instance = new InventoryContext();
        }

        public static InventoryContext Instance { get; private set; }
    }
}