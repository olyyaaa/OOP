using OOP_pr_v1;
using System;

class RadioPhone : IPhone
{
    public string Name { get; set; }
    public bool HasAnsweringMachine { get; set; }
    public double Price { get; set; }

    public RadioPhone(string name, bool hasAnsweringMachine, double price)
    {
        Name = name;
        HasAnsweringMachine = hasAnsweringMachine;
        Price = price;
    }

    public void Info()
    {
        Console.WriteLine($"Radio Phone: {Name}, Has Answering Machine: {HasAnsweringMachine}, Price: {Price}");
    }
}
