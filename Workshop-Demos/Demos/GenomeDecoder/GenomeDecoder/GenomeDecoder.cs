using System;
using System.Text;

class GenomeDecoder
{
    static void Main()
    {
        string inputFormat = Console.ReadLine();
        string[] format = inputFormat.Split(' ');
        int lettersPerLine = int.Parse(format[0]);
        int lettersPerSubsequence = int.Parse(format[1]);

        string encodedGenome = Console.ReadLine();
        StringBuilder decodedGenome = DecodeGenome(encodedGenome);

        PrintFormattedOutput(decodedGenome, lettersPerLine, lettersPerSubsequence);
    }

    static void PrintFormattedOutput(StringBuilder decodedGenome, int lettersPerLine, int lettersPerSubsequence)
    {
        int outputLines = (int)Math.Ceiling(
            (double)decodedGenome.Length / (double)lettersPerLine);
        int maxLineNumberDigits = outputLines.ToString().Length;
        StringBuilder currentFormattedLine = new StringBuilder();
        int currentIndexInDecodedGenome = 0;
        for (int line = 1; line <= outputLines; line++)
        {
            string leadingIntervals = new string(' ', maxLineNumberDigits - line.ToString().Length);
            currentFormattedLine.Append(leadingIntervals);
            currentFormattedLine.Append(line);
            
            currentIndexInDecodedGenome = (line - 1) * lettersPerLine;
            for (int i = currentIndexInDecodedGenome; i < line * lettersPerLine; i++)
            {
                if (Math.Abs(currentIndexInDecodedGenome - i) % lettersPerSubsequence == 0)
                {
                    currentFormattedLine.Append(' ');
                }

                if (i >= decodedGenome.Length)
                {
                    break;
                }

                currentFormattedLine.Append(decodedGenome[i]);
            }

            Console.WriteLine(currentFormattedLine);
            currentFormattedLine.Clear();
        }
    }

    static StringBuilder DecodeGenome(string encodedGenome)
    {
        StringBuilder decodedGenome = new StringBuilder();

        StringBuilder repeatTimesString = new StringBuilder();
        foreach (char symbol in encodedGenome)
        {
            if (symbol == 'A' || symbol == 'C' || symbol == 'G' || symbol == 'T')
            {
                int repeatTimes = 1;
                if (repeatTimesString.Length != 0)
                {
                    repeatTimes = int.Parse(repeatTimesString.ToString());
                    repeatTimesString.Clear();
                }

                string genomeSubsequence = new string(symbol, repeatTimes);
                decodedGenome.Append(genomeSubsequence);
            }
            else
            {
                repeatTimesString.Append(symbol);
            }
        }

        return decodedGenome;
    }
}
