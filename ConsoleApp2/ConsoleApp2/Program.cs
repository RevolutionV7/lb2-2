using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Worker
{
    public string Name { get; set; }
    public int Sal { get; set; }

    public Worker(string name, int sal)
    {
        Name = name;
        Sal = sal;

    }

}

class Program
{
    static void Main()
    {
        string filePath = @"C:\1\22.txt";

        var workers = ReadWorkersFromFile(filePath);
        var workersBySal = workers.Where(s => s.Sal > 0).OrderByDescending(s => s.Sal);

        Console.WriteLine("Сортування зарплати за спаданням : ");
        foreach (var worker in workersBySal)
        {
            Console.WriteLine($"{worker.Name} - {worker.Sal}");
        }

        Console.WriteLine();
    }

    static List<Worker> ReadWorkersFromFile(string filePath)
    {
        var workers = new List<Worker>();

        using (var reader = new StreamReader(filePath))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                var name = values[0];
                var sal = int.Parse(values[1]);

                workers.Add(new Worker(name, sal));
            }

        }

        return workers;
    }
}