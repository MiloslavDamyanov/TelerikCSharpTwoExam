using System;
using System.Collections.Generic;

class NineGagNumbers
{
    static string ConvertStringToNumber(string digit)
    {
        string result = "NO";
        switch (digit)
        {

            case "-!": result = "0"; break;
            case "**": result = "1"; break;
            case "!!!": result = "2"; break;
            case "&&": result = "3"; break;
            case "&-": result = "4"; break;
            case "!-": result = "5"; break;
            case "*!!!": result = "6"; break;
            case "&*!": result = "7"; break;
            case "!!**!-": result = "8"; break;
            default:
                break;
        }

        return result;
    }

    static ulong PowerOfNine(int power)
    {
        ulong result = 1;

        for (int i = 0; i < power; i++)
        {
            result *= 9;
        }

        return result;
    }

    static void Main()
    {
        string input = Console.ReadLine();
        string partialInput = string.Empty;
        string nineSystemNumber = null;
        for (int i = 0; i < input.Length; i++)
        {
            partialInput += input[i];
            string currentDigit = ConvertStringToNumber(partialInput);
            if (currentDigit != "NO")
            {
                nineSystemNumber += currentDigit;
                partialInput = null;
            }
        }
        ulong result = 0;
        for (int i = 0; i < nineSystemNumber.Length; i++)
        {
            ulong digit = ulong.Parse(nineSystemNumber[i].ToString());
            result += digit * PowerOfNine(nineSystemNumber.Length - i - 1);
        }
        Console.WriteLine(result);
    }
}