using OOP_pr_v1;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<IPhone> phones = new List<IPhone>();

        // Read data from file
        using (StreamReader reader = new StreamReader("D:\\phones.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split(',');
                if (data[0] == "MobilePhone")
                {
                    phones.Add(new MobilePhone(data[1], double.Parse(data[2])));
                }
                else if (data[0] == "RadioPhone")
                {
                    phones.Add(new RadioPhone(data[1], bool.Parse(data[2]), double.Parse(data[3])));
                }
            }
        }

        // Sort by price
        phones = phones.OrderBy(phone => phone.GetType().GetProperty("Price").GetValue(phone)).ToList();

        // Display all phones
        Console.WriteLine("All Phones:");
        foreach (IPhone phone in phones)
        {
            phone.Info();
        }

        // Display total sum of all phone prices
        double totalSum = phones.Sum(phone => (double)phone.GetType().GetProperty("Price").GetValue(phone));
        Console.WriteLine($"Total Sum: {totalSum}");

        // Display only radio phones with answering machine
        Console.WriteLine("Radio Phones with Answering Machine:");
        foreach (IPhone phone in phones)
        {
            if (phone is RadioPhone radioPhone && radioPhone.HasAnsweringMachine)
            {
                phone.Info();
            }
        }

        // Write result to file
        using (StreamWriter writer = new StreamWriter("D:\\result.txt"))
        {
            writer.WriteLine("All Phones:");
            foreach (IPhone phone in phones)
            {
                writer.WriteLine(phone.GetType().GetProperty("Name").GetValue(phone));
            }

            writer.WriteLine($"Total Sum: {totalSum}");

            writer.WriteLine("Radio Phones with Answering Machine:");
            foreach (IPhone phone in phones)
            {
                if (phone is RadioPhone radioPhone && radioPhone.HasAnsweringMachine)
                {
                    writer.WriteLine(radioPhone.Name);
                }
            }
        }
    }
}
