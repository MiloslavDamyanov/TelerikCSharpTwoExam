using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Rank { get; set; }
    public string Position { get; set; }
}

class Program
{
    static void Main()
    {
        Dictionary<string, int> posAndRank = new Dictionary<string, int>();
        int numberOfPos = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfPos; i++)
        {
            string line = Console.ReadLine();
            string[] rawInput = line.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
            if (!posAndRank.ContainsKey(rawInput[0]))
            {
                posAndRank.Add(rawInput[0], int.Parse(rawInput[1]));
            }
        }

        int numOfWorkers = int.Parse(Console.ReadLine());
        List<Employee> AllWorkers = new List<Employee>();
        for (int i = 0; i < numOfWorkers; i++)
        {
            string line = Console.ReadLine();
            string[] rawInput = line.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
            // rawInput[0] - FullName
            // rawInput[1] - position
            string[] splitName = rawInput[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            // splitName[0] - firstName
            // splitName[1] - secondName

            Employee currrentEmp = new Employee();
            currrentEmp.FirstName = splitName[0];
            currrentEmp.LastName = splitName[1];
            currrentEmp.Position = rawInput[1];
            currrentEmp.Rank = posAndRank[currrentEmp.Position];
            AllWorkers.Add(currrentEmp);
        }
        // Sorting Dictionary
        var sortedWorkers = AllWorkers
            .OrderByDescending(em => em.Rank)
            .ThenBy(em => em.LastName)
            .ThenBy(em => em.FirstName);

        foreach (var worker in sortedWorkers)
        {
            Console.WriteLine("{0} {1}", worker.FirstName, worker.LastName);
        }

    }
}