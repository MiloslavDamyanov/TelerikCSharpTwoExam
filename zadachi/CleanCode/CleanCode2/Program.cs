using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static StringBuilder AppendToIndex(int index, string line)
    {
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < index; i++)
        {
            builder.Append(line[i]);
        }

        return builder;
    }

    static StringBuilder AppenFromIndexToEnd(int index, string line)
    {
        StringBuilder builder = new StringBuilder();
        for (int i = index; i < line.Length; i++)
        {
            builder.Append(line[i]);
        }

        return builder;
    }
    static void Main()
    {
        StringBuilder builder = new StringBuilder();
        List<string> lines = new List<string>();
        List<string> newLines = new List<string>();
        int numberOfLines = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfLines; i++)
        {
            lines.Add(Console.ReadLine());
        }

        for (int i = 0; i < lines.Count; i++)
        {
            if (lines[i].Contains("//"))
            {
                int index = lines[i].IndexOf("//");
                newLines.Add(AppendToIndex(index, lines[i]).ToString());
            }
            else if (lines[i].Contains("/*"))
            {
                int index = lines[i].IndexOf("/*");
                newLines.Add(AppendToIndex(index, lines[i]).ToString());
                while (!lines[i].Contains("*/"))
                {
                    i++;
                }
                i--;
            }
            else if (lines[i].Contains("*/"))
            {
                int index = lines[i].IndexOf("*/") + 2;
                newLines.Add(AppenFromIndexToEnd(index, lines[i]).ToString());
            }
            else if (lines[i] != string.Empty)
            {
                newLines.Add(lines[i]);
            }
        }
       // Console.WriteLine("\n\n");
        foreach (var item in newLines)
        {
            Console.WriteLine(item);
        }
    }
}