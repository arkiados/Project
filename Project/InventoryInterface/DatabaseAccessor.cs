

namespace Project.InvInterface
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