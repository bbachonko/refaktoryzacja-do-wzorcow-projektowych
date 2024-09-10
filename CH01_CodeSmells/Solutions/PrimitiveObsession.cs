namespace RefactoringToDesignPatterns.CH01_CodeSmells.Solutions
{
    public class ProductDetails
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public class ProductManager
    {
        public void RegisterProduct(ProductDetails details)
        {
            Console.WriteLine(
                $"Product: {details.Name}, Category: {details.Category}, Price: {details.Price}, Quantity: {details.Quantity}");
        }
    }
}