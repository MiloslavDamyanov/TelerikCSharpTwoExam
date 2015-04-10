using System;
using System.Collections.Generic;
using System.Text;

class CodeClean
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
        int numberOfLines = int.Parse(Console.ReadLine());
        string[] line = new string[numberOfLines];

        for (int i = 0; i < numberOfLines; i++)
        {
            line[i] = Console.ReadLine();
        }
        List<string> newLines = new List<string>();
        int open = int.MinValue;
        int close = int.MinValue;
        for (int i = 0; i < numberOfLines; i++)
        {
            if (line[i].Contains("//"))
            {
                int indexOfSingleLineComment = line[i].IndexOf("//");
                newLines.Add(AppendToIndex(indexOfSingleLineComment, line[i]).ToString());
            }
            else if (line[i].Contains("/*"))
            {
                int indexOfMultiLineComment = line[i].IndexOf("/*");
                newLines.Add(AppendToIndex(indexOfMultiLineComment, line[i]).ToString());
                int index = i;
                for (int inde   = 0; inde < length; inde++)
                {

                }
 while (!lines[i].Contains("*/"))
                {
                    i++;
                }
            }
            else if (line[i].Contains("*/"))
            {
                int index = line[i].

                close = i;dexOf("*/") + 2;
                newLines.Add(AppenFromIndexToEnd(index, line[i]).ToString());

            }
            else if (line[i] 


!= stri List<int> indexes = new List<int>();
        for (int i = open; i < close; i++)
        {
            indexes.Add(i);
        }
        
                   {
                newLines.Add(line[i]);
            }
        }       

        Console.WriteLine("-------------------");
        foreach (var item in newLines)
        {
            Console.WriteLine(item);
        }
    }
}