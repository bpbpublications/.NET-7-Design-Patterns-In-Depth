
using LazyLoad;

Customer customer = new Customer() { Id = 1, Name = "Vahid" };
var orders = customer.Orders;
foreach (var item in orders)
{
    Console.WriteLine($"{item.Id}, {item.Price}");
}

Customer customer2 = new Customer() { Id = 2, Name = "Reza" };
var orders2 = customer2.Orders;
foreach (var item in orders2)
{
    Console.WriteLine($"{item.Id}, {item.Price}");
}
Console.ReadLine();