using System;
using System.Text;
using System.Collections.Generic;

class GenomDecoder
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] splitedInputd = input.Split(' ');
        int length = int.Parse(splitedInputd[0]);
        int lengthCount = int.Parse(splitedInputd[1]);

        string code = Console.ReadLine();

        int count = 1;
        string strNumber = null;
        StringBuilder builder = new StringBuilder();

        for (int i = 0; i < code.Length; i++)
        {
            if (char.IsDigit(code[i]))
            {
                strNumber += code[i];
            }
            else if (char.IsLetter(code[i]))
            {
                if (strNumber == null)
                {
                    count = 1;
                }
                else if (strNumber != null)
                {
                    count = int.Parse(strNumber);
                }
                strNumber = null;
                builder.Append(new string(code[i], count));
            }
        }
        
        List<string> list = new List<string>();
        StringBuilder tempBuilder = new StringBuilder();
       
    }
}