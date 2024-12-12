using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Created some sample orders with two Nigerian and Ivorian customers
        Order order1 = new Order(new Customer("Ezra Okesola", new Address("57 Ojota roundabout, Lagos St", "Lagos", "LA", "Nigeria")));
        order1.AddProduct(new Product("HP Laptop", "P001", 1000, 1));
        order1.AddProduct(new Product("Wireless Mouse", "P002", 50, 2));

        Order order2 = new Order(new Customer("Awa Diop", new Address("49 Cite La Maman, deuxiemme carrefour de Toit-Rogue", "Abidjan", "AB", "Ivory Coast")));
        order2.AddProduct(new Product("DELL Monitor", "P003", 300, 1));
        order2.AddProduct(new Product("Detachable Keyboard", "P004", 80, 1));

        // Display of order details
        DisplayOrderDetails(order1);
        DisplayOrderDetails(order2);
    }

    static void DisplayOrderDetails(Order order)
    {
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Price: {order.GetTotalPrice()}");
        Console.WriteLine();
    }
}

class Product
{
    private string name;
    private string productId;
    private double price;
    private int quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public double GetTotalCost()
    {
        return price * quantity;
    }

    public string GetName()
    {
        return name;
    }

    public string GetProductId()
    {
        return productId;
    }
}

class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.ToLower() == "usa";
    }

    public bool IsInNigeria()
    {
        return country.ToLower() == "nigeria";
    }

    public string GetFullAddress()
    {
        return $"{street}\n{city}, {state}\n{country}";
    }
}

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    public bool IsInNigeria()
    {
        return address.IsInNigeria();
    }

    public string GetName()
    {
        return name;
    }

    public Address GetAddress()
    {
        return address;
    }
}

class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public string GetTotalPrice()
    {
        double total = 0;
        foreach (var product in products)
        {
            total += product.GetTotalCost();
        }
        total += customer.IsInUSA() ? 5 : 35000;
        if (customer.IsInNigeria())
        {
            return $"₦{total}";
        }
        else
        {
            return $"F.CFA {total}";
        }
    }

    public string GetPackingLabel()
    {
        string label = "";
        foreach (var product in products)
        {
            label += $"{product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"{customer.GetName()}\n{customer.GetAddress().GetFullAddress()}";
    }
}
