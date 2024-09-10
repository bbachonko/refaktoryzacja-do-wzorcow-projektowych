namespace RefactoringToDesignPatterns.CH01_CodeSmells.Solutions
{
    public class OrderService
    {
        public void CreateOrder(Customer customer)
        {
            Console.WriteLine($"Order created for customer {customer.Name}.");
            SaveOrder();
        }

        private void SaveOrder()
        {
            Console.WriteLine("Order saved.");
        }
    }

    public class Customer
    {
        public string Name { get; set; }
    }
}

// Przykład użycia
// var customer = new Customer { Name = "Jane Doe" };
// var orderService = new OrderService();
// orderService.CreateOrder(customer);