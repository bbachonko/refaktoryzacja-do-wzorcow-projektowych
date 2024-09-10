namespace RefactoringToDesignPatterns.CH01_CodeSmells.Solutions
{
    internal class LongParameterList
    {
        public void RegisterProduct(ProductInfo product)
        {
            // Rejestracja produktu
            Console.WriteLine($"Product: {product.ProductName}, Category: {product.Category}, Price: {product.Price:C}, Stock: {product.Stock}, Supplier: {product.SupplierName}, Contact: {product.SupplierContact}");
        }

        public class ProductInfo
        {
            public string ProductName { get; set; }
            public string Category { get; set; }
            public decimal Price { get; set; }
            public int Stock { get; set; }
            public string SupplierName { get; set; }
            public string SupplierContact { get; set; }
        }
    }
}
