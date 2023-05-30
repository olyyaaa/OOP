using OOP_pr_v1;
using System;

class MobilePhone : IPhone
{
    public string Name { get; set; }
    public double Price { get; set; }

    public MobilePhone(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public void Info()
    {
        Console.WriteLine($"Mobile Phone: {Name}, Price: {Price}");
    }
}
