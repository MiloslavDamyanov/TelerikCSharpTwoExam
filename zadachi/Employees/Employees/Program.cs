using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class Program
{
    static Dictionary<string, int> positionAndRank = new Dictionary<string, int>();
    static List<string> title = new List<string>(); // ok
    static List<string> listRank = new List<string>();
    static List<string> strRank = new List<string>();
    static List<int> numRank = new List<int>(); // ok

    static List<string> employees = new List<string>();
    static Dictionary<string, string> names = new Dictionary<string, string>(); // ok
    static List<string> list = new List<string>();
    static List<string> fullName = new List<string>();
    static List<string> output = new List<string>();

    private static void InputTitleRate(int totalNumOfPositions)
    {
        for (int i = 0; i < totalNumOfPositions; i++)
        {
            string jobAndTitle = Console.ReadLine();
            listRank.Add(jobAndTitle);
            jobAndTitle = null;
        }
    }

    private static void ExtractTitle()
    {
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < listRank.Count; i++)
        {
            for (int j = 0; j < listRank[i].Length; j++)
            {
                builder.Append(listRank[i][j]);
                if (listRank[i][j] == '-')
                {
                    break;
                }
            }
            string[] arr = builder.ToString().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            title.Add(arr[0].TrimEnd(' '));
            builder.Clear();
        }
    }

    private static void ExtraRate()
    {
        StringBuilder builder = new StringBuilder();
        int k = 0;
        for (int i = 0; i < listRank.Count; i++)
        {
            for (int j = 0; j < listRank[i].Length; j++)
            {
                if (listRank[i][j] == '-')
                {
                    int indexOfDash = listRank[i].IndexOf('-');
                    for (k = indexOfDash; k < listRank[i].Length; k++)
                    {
                        builder.Append(listRank[i][k]);
                    }

                    j = k;
                }
            }

            strRank.Add(builder.ToString());
            builder.Clear();
        }

        ParseRating();
        for (int i = 0; i < title.Count; i++)
        {
            positionAndRank.Add(title[i], numRank[i]);
        }
    }

    private static void ParseRating()
    {

        StringBuilder temp = new StringBuilder();
        for (int i = 0; i < strRank.Count; i++)
        {
            string[] arr = strRank[i].Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
            numRank.Add(int.Parse(arr[0]));
        }
    }

    private static void InputName()
    {
        string temp = null;
        int count = int.Parse(Console.ReadLine());
        for (int i = 0; i < count; i++)
        {
            temp = Console.ReadLine();
            employees.Add(temp);
        }
    }

    private static void ParseNames()
    {
        StringBuilder builder = new StringBuilder();
        List<string> firstName = new List<string>();
        List<string> lastName = new List<string>();


        for (int i = 0; i < employees.Count; i++)
        {
            for (int j = 0; j < employees[i].Length; j++)
            {
                builder.Append(employees[i][j]);
                if (employees[i][j] == '-')
                {
                    break;
                }
            }

            fullName.Add(builder.ToString().TrimEnd(new char[] { ' ', '-' }).TrimStart(' '));
            builder.Clear();
        }

        for (int i = 0; i < fullName.Count; i++)
        {
            for (int j = 0; j < fullName[i].Length; j++)
            {
                builder.Append(fullName[i][j]);
                if (fullName[i][j] == ' ')
                {
                    break;
                }
            }

            firstName.Add(builder.ToString().TrimEnd(' '));
            builder.Clear();
        }

        int k = 0;
        for (int i = 0; i < fullName.Count; i++)
        {
            for (int j = 0; j < fullName[i].Length; j++)
            {
                if (fullName[i][j] == ' ')
                {
                    int index = fullName[i].IndexOf(' ');
                    for (k = index; k < fullName[i].Length; k++)
                    {
                        builder.Append(fullName[i][k]);
                    }
                    j = k;
                }
            }

            lastName.Add(builder.ToString().TrimStart(' '));
            builder.Clear();
        }

        for (int i = 0; i < firstName.Count; i++)
        {
            names.Add(firstName[i], lastName[i]);
        }
    }

    private static void ParseTitle()
    {
        StringBuilder builder = new StringBuilder();
        int k = 0;
        for (int i = 0; i < employees.Count; i++)
        {
            for (int j = 0; j < employees[i].Length; j++)
            {
                if (employees[i][j] == '-')
                {
                    int index = employees[i].IndexOf('-');
                    for (k = index; k < employees[i].Length; k++)
                    {
                        builder.Append(employees[i][k]);
                    }
                    j = k;
                }
            }

            list.Add(builder.ToString().TrimStart(new char[] { ' ', '-' }));
            builder.Clear();
        }
    }

    public static void SortDictionary()
    {
       
    }


    private static void Main()
    {
        int totalNumOfPositions = int.Parse(Console.ReadLine());
        InputTitleRate(totalNumOfPositions);
        ExtractTitle();
        ExtraRate();
        InputName();
        ParseNames();
        ParseTitle();
        // SortDictionary();
    }
}