using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static List<string> words = new List<string>();
    static List<int> newIndexOfWords = new List<int>();
    static List<string> reorderedWords = new List<string>();
    static void Input(int numOfWords)
    {
        for (int i = 0; i < numOfWords; i++)
        {
            string word = Console.ReadLine();
            words.Add(word);
        }
    }

    static void Reorder()
    {
        int n = words.Count;
        int index = 0;
        for (int i = 0; i < words.Count; i++)
        {
            int len = words[i].Length;
            if (i == words.Count - 2)
            {
                index = len % n;
                newIndexOfWords.Add(index);
            }
            else
            {
                index = len % (n + 1);
                newIndexOfWords.Add(index);
            }
        }

        for (int i = 0; i < words.Count; i++)
        {
            reorderedWords.Add(words[newIndexOfWords[i]]);
        }
    }

    static void Print()
    {
        StringBuilder builder = new StringBuilder();
        string[,] matrix = new string[reorderedWords.Count, reorderedWords.Count];

        for (int i = 0; i < reorderedWords.Count; i++)
        {
            for (int k = 0; k < reorderedWords[i].Length; k++)
            {
                builder.Append(reorderedWords[i][k].ToString());
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = builder.ToString();
                    }
                }
            }
        }

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.WriteLine(matrix[row, col]);
            }
        }


    } //!!!
    static void Main()
    {
        int numOfWords = int.Parse(Console.ReadLine());
        Input(numOfWords);
        Reorder();
        Print();
    }
}