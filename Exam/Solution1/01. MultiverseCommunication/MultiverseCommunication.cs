using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

class Program
{
    static List<BigInteger> ConvertToDigit(string[] codeArr, string inputCode)
    {
        StringBuilder builder = new StringBuilder();
        List<BigInteger> indexes = new List<BigInteger>();
        for (int i = 0; i < inputCode.Length; i++)
        {
            builder.Append(inputCode[i]);
            for (int index = 0; index < codeArr.Length; index++)
            {
                if (builder.ToString().Trim() == codeArr[index].Trim())
                {
                    if (indexes.Count < 9)
                    {
                        indexes.Add(index);
                        
                    }

                    builder.Clear();
                    break;                    
                }

            }

        }
        return indexes;
    }

    static BigInteger GetDecimalNumber(List<BigInteger> indexes)
    {
        BigInteger result = 0;

        for (int i = 0; i < indexes.Count; i++)
        {
            result += (ulong)(indexes[indexes.Count - i - 1] * (int)Math.Pow(13, i));
        }

        return result;
    }

    static void Main()
    {
        string[] codeArr = { "CHU", "TEL", "OFT", "IVA", "EMY", "VNB", "POQ", "ERI", "CAD", "K-A", "IIA", "YLO", "PLA" };
        string inputCode = Console.ReadLine().ToUpper();
        List<BigInteger> indexes = ConvertToDigit(codeArr, inputCode);

        var result = GetDecimalNumber(indexes);
        Console.WriteLine(result);
    }


}