using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringToDesignPatterns.CH01_CodeSmells.CodeSmellTasks
{
    internal class LongParameterList
    {
        internal void RegisterProduct(Product product)
        {
            // Rejestracja produktu
            Console.WriteLine($"Product: {product.Name}, Category: {product.Category}, Price: {product.Price}, Stock: {product.Stock}, Supplier: {product.SupplierName}, Contact: {product.SupplierContact}");
        }
    }

    internal class Product
    {
        internal required string Name { get; set; }
        internal required string Category { get; set; }
        internal decimal Price { get; set; }
        internal int Stock { get; set; }
        internal required string SupplierName { get; set; }
        internal required string SupplierContact { get; set; }
    }
}
