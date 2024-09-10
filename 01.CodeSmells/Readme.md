#### Długi kod metody (Long Method)

Masz metodę GenerateInvoice, która wykonuje kilka czynności naraz: walidację zamówienia, obliczenia, generowanie pliku faktury i wysyłanie powiadomienia. Twoim zadaniem jest refaktoryzacja tej metody, aby uczynić ją bardziej modularną i czytelną.

```csharp
public void GenerateInvoice(Order order)
{
    // Walidacja zamówienia
    if (order == null || order.Items.Count == 0)
    {
        throw new ArgumentException("Invalid order");
    }

    // Obliczenia
    decimal total = 0;
    foreach (var item in order.Items)
    {
        total += item.Price * item.Quantity;
    }
    decimal tax = total * 0.15m;
    decimal finalTotal = total + tax;

    // Generowanie pliku faktury
    var fileName = $"Invoice_{order.OrderId}_{DateTime.Now:yyyyMMdd}.pdf";
    using (var fileStream = new FileStream(fileName, FileMode.Create))
    {
        // Logika generowania PDF...
    }

    // Wysyłanie powiadomienia
    Console.WriteLine($"Invoice for Order {order.OrderId} generated successfully.");
}
```

Kroki do wykonania:

Wyodrębnij logikę walidacji zamówienia do nowej metody ValidateOrder.
Wyodrębnij logikę obliczeń do nowej metody CalculateTotal.
Wyodrębnij logikę generowania pliku faktury do nowej metody CreateInvoiceFile.
Wyodrębnij logikę wysyłania powiadomień do nowej metody SendNotification.

```csharp
public void GenerateInvoice(Order order)
{
    ValidateOrder(order);
    decimal finalTotal = CalculateTotal(order);
    CreateInvoiceFile(order, finalTotal);
    SendNotification(order);
}

private void ValidateOrder(Order order)
{
    if (order == null || order.Items.Count == 0)
    {
        throw new ArgumentException("Invalid order");
    }
}

private decimal CalculateTotal(Order order)
{
    decimal total = 0;
    foreach (var item in order.Items)
    {
        total += item.Price * item.Quantity;
    }
    decimal tax = total * 0.15m;
    return total + tax;
}

private void CreateInvoiceFile(Order order, decimal finalTotal)
{
    var fileName = $"Invoice_{order.OrderId}_{DateTime.Now:yyyyMMdd}.pdf";
    using (var fileStream = new FileStream(fileName, FileMode.Create))
    {
        // Logika generowania PDF...
    }
}

private void SendNotification(Order order)
{
    Console.WriteLine($"Invoice for Order {order.OrderId} generated successfully.");
}
```

Przeprowadź refaktoryzację, używając narzędzia ReSharper (Ctrl+R, M), aby wyodrębnić każdą część logiki do oddzielnych metod.

#### Długa lista parametrów (Long Parameter List)      


Masz metodę RegisterProduct, która przyjmuje wiele parametrów związanych z produktem. Twoim zadaniem jest zastąpienie długiej listy parametrów jednym obiektem ProductInfo.


```csharp
public void RegisterProduct(string productName, string category, decimal price, int stock, string supplierName, string supplierContact)
{
    // Rejestracja produktu
    Console.WriteLine($"Product: {productName}, Category: {category}, Price: {price:C}, Stock: {stock}, Supplier: {supplierName}, Contact: {supplierContact}");
}
```

Kroki do wykonania:

Utwórz nową klasę ProductInfo, która będzie grupować wszystkie parametry związane z produktem.
Zastąp listę parametrów w metodzie RegisterProduct jednym obiektem ProductInfo.
Zaktualizuj logikę metody tak, aby korzystała z nowego obiektu.

```csharp
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
```

Skorzystaj z narzędzia ReSharper (Ctrl+R, O) lub użyj wbudowanych narzędzi w Visual Studio, aby wyodrębnić obiekt parametru.

#### Opętanie typami prostymi (Primitive Obsession)

Masz metodę AddCustomer, która używa wielu typów prostych do reprezentowania danych klienta. Twoim zadaniem jest utworzenie bardziej znaczącego typu, który reprezentuje klienta.

```csharp   

public void AddCustomer(string name, string email, string phone, string address)
{
    // Logika dodawania klienta
    Console.WriteLine($"Adding customer: {name}, Email: {email}, Phone: {phone}, Address: {address}");
}
```

Kroki do wykonania:

Utwórz nową klasę Customer, która będzie grupować dane związane z klientem.
Zastąp typy proste w metodzie AddCustomer jednym obiektem Customer.
Zaktualizuj logikę metody tak, aby korzystała z nowego obiektu.

```csharp

public void AddCustomer(Customer customer)
{
    // Logika dodawania klienta
    Console.WriteLine($"Adding customer: {customer.Name}, Email: {customer.Email}, Phone: {customer.Phone}, Address: {customer.Address}");
}

public class Customer
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
}
```

Wskazówki:

Skorzystaj z narzędzia ReSharper (Ctrl+R, O) lub innych narzędzi refaktoryzacyjnych, aby utworzyć nowy obiekt i uprościć kod.


#### Shotgun Surgery

Masz metodę CalculateShippingCost, która zawiera logikę dla różnych regionów wysyłki. Twoim zadaniem jest zastąpienie rozproszonej logiki wzorcem strategii.

```csharp
public void CalculateShippingCost(Order order)
{
    if (order.Region == "North")
    {
        // Koszt wysyłki dla regionu North
        order.ShippingCost = order.Weight * 1.2m;
    }
    else if (order.Region == "South")
    {
        // Koszt wysyłki dla regionu South
        order.ShippingCost = order.Weight * 1.1m;
    }
    else if (order.Region == "East")
    {
        // Koszt wysyłki dla regionu East
        order.ShippingCost = order.Weight * 1.3m;
    }
    else if (order.Region == "West")
    {
        // Koszt wysyłki dla regionu West
        order.ShippingCost = order.Weight * 1.5m;
    }
    Console.WriteLine($"Shipping cost for {order.Region} region: {order.ShippingCost:C}");
}
```

Kroki do wykonania:

Utwórz interfejs IShippingCalculator dla różnych regionów, który będzie miał metodę Calculate.
Utwórz oddzielne klasy implementujące IShippingCalculator dla każdego regionu (NorthShipping, SouthShipping, EastShipping, WestShipping).
Przenieś logikę kosztu wysyłki do odpowiednich klas.
Zmodyfikuj metodę CalculateShippingCost, aby używała wzorca strategii.

```csharp
Kroki do wykonania:

Utwórz interfejs IShippingCalculator dla różnych regionów, który będzie miał metodę Calculate.
Utwórz oddzielne klasy implementujące IShippingCalculator dla każdego regionu (NorthShipping, SouthShipping, EastShipping, WestShipping).
Przenieś logikę kosztu wysyłki do odpowiednich klas.
Zmodyfikuj metodę CalculateShippingCost, aby używała wzorca strategii.

public interface IShippingCalculator
{
    decimal Calculate(decimal weight);
}

public class NorthShipping : IShippingCalculator
{
    public decimal Calculate(decimal weight)
    {
        return weight * 1.2m;
    }
}

public class SouthShipping : IShippingCalculator
{
    public decimal Calculate(decimal weight)
    {
        return weight * 1.1m;
    }
}

public class EastShipping : IShippingCalculator
{
    public decimal Calculate(decimal weight)
    {
        return weight * 1.3m;
    }
}

public class WestShipping : IShippingCalculator
{
    public decimal Calculate(decimal weight)
    {
        return weight * 1.5m;
    }
}

public void CalculateShippingCost(IShippingCalculator shippingCalculator, Order order)
{
    order.ShippingCost = shippingCalculator.Calculate(order.Weight);
    Console.WriteLine($"Shipping cost: {order.ShippingCost:C}");
}
```

Wskazówki:

Skorzystaj z narzędzi refaktoryzacyjnych ReSharper lub Visual Studio, aby wyodrębnić interfejsy i klasy.

#### Duplikacja kodu (Duplicated Code)

Masz metody LogError i LogWarning, które zawierają zduplikowaną logikę formatowania komunikatów logów. Twoim zadaniem jest usunięcie zduplikowanego kodu poprzez wyodrębnienie wspólnej logiki do nowej metody FormatLogMessage.

```csharp
public void LogError(string message, DateTime timestamp)
{
    string formattedTimestamp = timestamp.ToString("yyyy-MM-dd HH:mm:ss");
    string formattedMessage = $"ERROR: [{formattedTimestamp}] {message}";
    Console.WriteLine(formattedMessage);
}

public void LogWarning(string message, DateTime timestamp)
{
    string formattedTimestamp = timestamp.ToString("yyyy-MM-dd HH:mm:ss");
    string formattedMessage = $"WARNING: [{formattedTimestamp}] {message}";
    Console.WriteLine(formattedMessage);
}
```

Kroki do wykonania:

Wyodrębnij zduplikowaną logikę formatowania komunikatów do oddzielnej metody FormatLogMessage.
Zamień zduplikowany kod w metodach LogError i LogWarning na wywołanie nowej metody FormatLogMessage.
Zaktualizuj metody, aby były bardziej czytelne i łatwiejsze w utrzymaniu.

```csharp
public void LogError(string message, DateTime timestamp)
{
    string formattedMessage = FormatLogMessage("ERROR", message, timestamp);
    Console.WriteLine(formattedMessage);
}

public void LogWarning(string message, DateTime timestamp)
{
    string formattedMessage = FormatLogMessage("WARNING", message, timestamp);
    Console.WriteLine(formattedMessage);
}

private string FormatLogMessage(string level, string message, DateTime timestamp)
{
    string formattedTimestamp = timestamp.ToString("yyyy-MM-dd HH:mm:ss");
    return $"{level}: [{formattedTimestamp}] {message}";
}
```

#### Speculative Generality (Spekulacyjna ogólność)

Masz klasę FutureProofHandler, która zawiera wiele metod zaprojektowanych z myślą o potencjalnych przyszłych wymaganiach, ale żadna z tych metod nie jest używana. Twoim zadaniem jest uproszczenie tej klasy, usuwając zbędną ogólność.

```csharp
public class FutureProofHandler
{
    public void HandleRequest(object request)
    {
        // Ogólna logika przetwarzania, która nigdy nie jest używana
    }

    public void HandleHttpRequest(HttpRequest request)
    {
        Console.WriteLine($"Handling HTTP request: {request.Url}");
    }

    public void HandleFileRequest(FileRequest request)
    {
        Console.WriteLine($"Handling file request: {request.FileName}");
    }
}
```

Kroki do wykonania:

Usuń nieużywane metody (HandleRequest) oraz niepotrzebne abstrakcje.
Zachowaj tylko metody, które są faktycznie wykorzystywane (HandleHttpRequest, HandleFileRequest).
Przykładowy docelowy kod wynikowy:

```csharp
public class RequestHandler
{
    public void HandleHttpRequest(HttpRequest request)
    {
        Console.WriteLine($"Handling HTTP request: {request.Url}");
    }

    public void HandleFileRequest(FileRequest request)
    {
        Console.WriteLine($"Handling file request: {request.FileName}");
    }
}
```

#### Lazy Class (Klasa leniwa)

Masz klasę UserUtils, która zawiera tylko jedną metodę IsUserAdmin, sprawdzającą, czy użytkownik jest administratorem. Twoim zadaniem jest przeniesienie tej logiki do klasy User i usunięcie zbędnej klasy UserUtils.

Kod do refaktoryzacji:

```csharp
public class UserUtils
{
    public bool IsUserAdmin(User user)
    {
        return user.Role == "Admin";
    }
}
```
Kroki do wykonania:

Przenieś metodę IsUserAdmin do klasy User.
Usuń klasę UserUtils, ponieważ nie jest już potrzebna.
Zaktualizuj wszelkie odwołania do UserUtils.IsUserAdmin w kodzie.
Przykładowy docelowy kod wynikowy:

<details>
```csharp
public class User
{
    public string Role { get; set; }

    public bool IsAdmin()
    {
        return Role == "Admin";
    }
}
```
</details>

#### Middle Man (Pośrednik)

Masz klasę OrderService, która jest jedynie pośrednikiem do klasy OrderRepository. Twoim zadaniem jest usunięcie klasy pośrednika i bezpośrednie użycie OrderRepository.

Kod do refaktoryzacji:

```csharp
public class OrderService
{
    private readonly OrderRepository _repository = new OrderRepository();

    public Order GetOrderById(int id)
    {
        return _repository.GetOrderById(id);
    }

    public void SaveOrder(Order order)
    {
        _repository.SaveOrder(order);
    }
}
```

Kroki do wykonania:

Usuń klasę OrderService.
Zamień wszystkie odwołania do OrderService na bezpośrednie odwołania do OrderRepository.

Przykładowy docelowy kod wynikowy:
<details>
```csharp
// Bezpośrednie użycie OrderRepository
var repository = new OrderRepository();
Order order = repository.GetOrderById(1);
repository.SaveOrder(new Order());
```
<details>

#### Message Chains (Łańcuchy wiadomości)

Masz kod, który wywołuje łańcuch metod z Library.GetBook().GetAuthor().GetName(). Twoim zadaniem jest wprowadzenie nowej metody GetAuthorName w klasie Library, aby zredukować łańcuch wiadomości.

Kod do refaktoryzacji:

```csharp
public class Car
{
    public Engine GetEngine()
    {
        return new Engine();
    }
}

public class Engine
{
    public Cylinder GetCylinder()
    {
        return new Cylinder();
    }
}

public class Cylinder
{
    public string GetSize()
    {
        return "2.0L";
    }
}

// Przykład wywołania
Car car = new Car();
string cylinderSize = car.GetEngine().GetCylinder().GetSize();

```

Kroki do wykonania:

Wprowadź metodę GetCylinderSize w klasie Car.
Przenieś wywołanie zagnieżdżone do nowej metody w klasie Car.
Zaktualizuj wywołania metod, aby używały nowej metody.
Przykładowy docelowy kod wynikowy:

```csharp
public class Car
{
    public string GetCylinderSize()
    {
        Engine engine = new Engine();
        return engine.GetCylinder().GetSize();
    }
}

// Przykład wywołania
Car car = new Car();
string cylinderSize = car.GetCylinderSize();
```

#### Refused Bequest (Odrzucony spadek)

Masz klasę Manager dziedziczącą po Employee, ale Manager nie używa wszystkich metod odziedziczonych po Employee. Twoim zadaniem jest usunięcie niepotrzebnego dziedziczenia i wprowadzenie bardziej odpowiedniego rozwiązania.

Kod do refaktoryzacji:

```csharp
public class Employee
{
    public string Name { get; set; }
    public string Position { get; set; }
    public void Work() { /* Implementacja */ }
    public void AttendMeeting() { /* Implementacja */ }
}

public class Manager : Employee
{
    public void ManageTeam() { /* Implementacja */ }
}
```

Kroki do wykonania:

Usuń dziedziczenie w klasie Manager.
Utwórz interfejs IEmployee zawierający metody Work, AttendMeeting.
Wprowadź interfejs IEmployee do klasy Manager i przenieś do niej tylko te metody, które są używane.

Przykładowy docelowy kod wynikowy:

```csharp
public interface IEmployee
{
    void Work();
    void AttendMeeting();
}

// Klasa Employee implementuje IEmployee i dodaje wspólne właściwości
public class Employee : IEmployee
{
    public string Name { get; set; }
    public string Position { get; set; }

    public void Work() { /* Implementacja */ }
    public void AttendMeeting() { /* Implementacja */ }
}

// Klasa Manager dziedziczy po Employee, ponieważ jest specjalnym typem pracownika
public class Manager : Employee
{
    public void ManageTeam() { /* Implementacja */ }
}
```