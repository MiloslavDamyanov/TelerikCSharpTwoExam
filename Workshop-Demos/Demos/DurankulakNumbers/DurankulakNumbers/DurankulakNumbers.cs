using System;
using System.Collections.Generic;

class DurankulakNumbers
{
    static void Main()
    {
        string[] durankulakDigits = GetDurankulakDigits();

        string durankulakNumber = Console.ReadLine();

        List<uint> decimalRepresentations = GetDecimalRepresentations(durankulakDigits, durankulakNumber);

        ulong decimalNumber = GetDecimalNumber(decimalRepresentations);
        Console.WriteLine(decimalNumber);
    }

    static ulong GetDecimalNumber(List<uint> decimalRepresentations)
    {
        ulong result = 0;
        for (int i = 0; i < decimalRepresentations.Count; i++)
        {
            result += decimalRepresentations[decimalRepresentations.Count - i - 1] * (ulong)Math.Pow(168, i);
        }

        return result;
    }

    static List<uint> GetDecimalRepresentations(string[] durankulakDigits, string durankulakNumber)
    {
        List<uint> decimalRepresentations = new List<uint>();
        char buffer = new char();
        foreach (char symbol in durankulakNumber)
        {
            if (symbol >= 'A' && symbol <= 'Z')
            {
                string durankulakDigit = null;
                uint decimalRepresentation = 0;
                if (buffer != default(char))
                {
                    durankulakDigit = string.Format("{0}{1}", buffer, symbol);
                    buffer = default(char);
                }
                else
                {
                    durankulakDigit = symbol.ToString();
                }

                decimalRepresentation = (uint)Array.IndexOf(durankulakDigits, durankulakDigit);
                decimalRepresentations.Add(decimalRepresentation);
            }
            else
            {
                buffer = symbol;
            }
        }

        return decimalRepresentations;
    }

    static string[] GetDurankulakDigits()
    {
        string[] durankulakDigits = new string[168];

        for (int i = 0; i < 168; i++)
        {
            if (i < 26)
            {
                durankulakDigits[i] = ((char)('A' + i)).ToString();
            }
            else if (i < 2 * 26)
            {
                durankulakDigits[i] = "a" + durankulakDigits[i - 26];
            }
            else if (i < 3 * 26)
            {
                durankulakDigits[i] = "b" + durankulakDigits[i - 2 * 26];
            }
            else if (i < 4 * 26)
            {
                durankulakDigits[i] = "c" + durankulakDigits[i - 3 * 26];
            }
            else if (i < 5 * 26)
            {
                durankulakDigits[i] = "d" + durankulakDigits[i - 4 * 26];
            }
            else if (i < 6 * 26)
            {
                durankulakDigits[i] = "e" + durankulakDigits[i - 5 * 26];
            }
            else
            {
                durankulakDigits[i] = "f" + durankulakDigits[i - 6 * 26];
            }
        }

        return durankulakDigits;
    }
}
