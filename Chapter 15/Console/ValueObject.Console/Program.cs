
Publisher publisher = new();
Address address1 = new("Rahnama", "Nakisa", "Kavoosifar", "Shahid beheshti");
Address address2 = new("Rahnama", "Nakisa", "Kavoosifar", "Shahid beheshti");

if (address1 == address2)
{
    Console.WriteLine("Same publishers");
    publisher.Addresses.Add(address1);
}
else
{
    Console.WriteLine("Different publishers");
    publisher.Addresses.AddRange(new List<Address> { address1, address2 });
}

Console.ReadLine();