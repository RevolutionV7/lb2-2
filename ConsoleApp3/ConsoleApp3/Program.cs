using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        List<string> products = File.ReadAllLines("C:/1/11.txt").ToList();

        var groupedProducts = products.GroupBy(p => GetCategory(p));

        foreach (var group in groupedProducts)
        {
            Console.WriteLine("Category: " + group.Key);
            foreach (var product in group)
            {
                Console.WriteLine("- " + product);
            }
            Console.WriteLine();
        }
    }
    static string GetCategory(string productName)
    {
        if (productName.ToLower().Contains("молочнi"))
        {
            return "Молочнi";
        }
        else if (productName.ToLower().Contains("м'яснi"))
        {
            return "М'яснi";
        }
        else if (productName.ToLower().Contains("овоч"))
        {
            return "Овочi та фрукти";
        }
        else
        {
            return "Інші";
        }
    }
}
