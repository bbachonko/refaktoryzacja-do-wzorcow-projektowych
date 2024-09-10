namespace RefactoringToDesignPatterns.CH01_CodeSmells.Solutions
{
    public class OrderProcessor
    {
        public void ProcessOrders()
        {
            Console.WriteLine("Processing orders.");
        }
    }

    public class InventoryManager
    {
        public void ManageInventory()
        {
            Console.WriteLine("Managing inventory.");
        }
    }

    public class DeliveryCoordinator
    {
        public void CoordinateDeliveries()
        {
            Console.WriteLine("Coordinating deliveries.");
        }
    }

    public class ReturnHandler
    {
        public void HandleReturns()
        {
            Console.WriteLine("Handling returns.");
        }
    }

    public class WarehouseManager
    {
        private readonly OrderProcessor _orderProcessor = new OrderProcessor();
        private readonly InventoryManager _inventoryManager = new InventoryManager();
        private readonly DeliveryCoordinator _deliveryCoordinator = new DeliveryCoordinator();
        private readonly ReturnHandler _returnHandler = new ReturnHandler();

        // Metody do wywoływania odpowiednich funkcji menedżerów, jeśli potrzebne
    }
}