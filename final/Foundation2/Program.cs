using System;

class Program
{
    static void Main(string[] args)
    {
        // Create some address and customers
        Address address1 = new Address("123 Main street", "Los Angeles", "CA", "USA");
        Address address2 = new Address("456 Elm street", "Toronto", "ON", "Canada");
        Customer customer1 =new Customer("Joseph Smith", address1);
        Customer customer2 = new Customer("Brigham Young", address2);

        // Create some products
        Product product1 = new Product("Laptop", 1001, 9.99m, 2);
        Product product2 = new Product("Iphone", 1002, 14.50m, 3);
        Product product3 = new Product("Refrigerator", 1003, 7.25m, 1);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product2);
        order2.AddProduct(product3);

        // Display the results
        Console.WriteLine("Order 1: ");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total cost: {order1.TotalCost():F2}");

        Console.WriteLine();

        Console.WriteLine("Order 2: ");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total cost: {order2.TotalCost():F2}");
    }
}