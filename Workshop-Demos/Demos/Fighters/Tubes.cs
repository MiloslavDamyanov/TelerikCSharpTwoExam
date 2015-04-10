namespace Fighters
{
    using System;

    public class Tubes
    {
        public static void Main()
        {
            long tubes = int.Parse(Console.ReadLine()); // initial tubes

            long friends = int.Parse(Console.ReadLine()); // fighters

            long[] tubesSizes = new long[tubes];

            long maxTube = 0;

            for (int i = 0; i < tubes; i++)
            {
                tubesSizes[i] = long.Parse(Console.ReadLine());

                if (maxTube < tubesSizes[i])
                {
                    maxTube = tubesSizes[i];
                }
            }

            long left = 1;
            long right = maxTube;
            long middle = (left + right) / 2;

            long finalResult = -1;

            while (left <= right)
            {
                long eventual = 0;

                for (int j = 0; j < tubesSizes.Length; j++)
                {
                    eventual += tubesSizes[j] / middle;
                }

                if (eventual < friends)
                {
                    right = middle - 1;
                }
                else if (eventual >= friends)
                {
                    left = middle + 1;
                    finalResult = middle;
                }

                middle = (left + right) / 2;
            }

            Console.WriteLine(finalResult);

            // SLOW!!! 25/100
            //for (long i = maxTube; i >= 1; i--)
            //{
            //    long eventual = 0;
            //
            //    for (int j = 0; j < tubesSizes.Length; j++)
            //    {
            //        eventual += tubesSizes[j] / i;
            //    }
            //
            //    if (eventual >= friends)
            //    {
            //        Console.WriteLine(i);
            //        break;
            //    }
            //}
        }
    }
}
