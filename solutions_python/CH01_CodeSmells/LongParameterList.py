from dataclasses import dataclass

__all__ = ["LongParameterList"]

@dataclass
class Product:
    Name: str
    Category: str
    Price: float
    Stock: int
    SupplierName: str
    SupplierContact: str


class LongParameterList:
    @staticmethod
    def register_product(product: Product):
        print(
            f"Product: {product.Name}, Category: {product.Category}, Price: {product.Price}, 
            Stock: {product.Stock}, Supplier: {product.SupplierName}, Contact: {product.SupplierContact}"
        )