using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

class Zerg
{
    static void Main()
    {
        string[] encryptedMessage = { "Rawr", "Rrrr", "Hsst", "Ssst", "Grrr", "Rarr", "Mrrr", "Psst", "Uaah", "Uaha", "Zzzz", "Bauu", "Djav", "Myau", "Gruh" };
        List<int> indexes = new List<int>();
        string message = Console.ReadLine();
        StringBuilder sb = new StringBuilder();
        for (int index = 0; index < message.Length; index++)
        {
            sb.Append(message[index]);
            for (int indexOfMessage = 0; indexOfMessage < encryptedMessage.Length; indexOfMessage++)
            {
                if (sb.ToString() == encryptedMessage[indexOfMessage])
                {
                    if (indexes.Count < 9)
                    {
                        indexes.Add(indexOfMessage);
                        sb.Clear();
                        break;
                    }                   
                }
            }
        }

        BigInteger result = 0;
        indexes.Reverse();
        for (int i = 0; i < indexes.Count; i++)
        {
            result += indexes[i] * (BigInteger)Math.Pow(15, i);
        }

        Console.WriteLine(result);
    }
}