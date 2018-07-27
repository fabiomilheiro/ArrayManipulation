using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace ArrayManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            // https://www.hackerrank.com/challenges/crush/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=arrays
            Console.WriteLine("Array manipulation problem");

            var testDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..", "input07.txt");
            var testData = File.ReadAllText(testDataPath).Split('\n');
            
            var nm = testData[0].Split(' ');

            var n = Convert.ToInt32(nm[0]);

            var m = Convert.ToInt32(nm[1]);

            var queries = new int[m][];

            for (var i = 0; i < m; i++)
            {
                queries[i] = Array.ConvertAll(testData[i + 1].Split(' '), Convert.ToInt32);
            }

            var stopwatch = Stopwatch.StartNew();
            var result = ArrayManipulation(n, queries);
            stopwatch.Stop();

            Console.WriteLine($"Calculated the result in {stopwatch.Elapsed}.");
            Console.WriteLine($"The max number is {result}...");
            
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }


        private static long ArrayManipulation(int n, int[][] queries)
        {
            var elements = new long[n];
            var iteration = 1;

            foreach (var query in queries)
            {
                var operation = new Operation
                {
                    StartIndex = query[0] - 1,
                    EndIndex = query[1] - 1,
                    ValueToAdd = query[2]
                };

                elements[operation.StartIndex] += operation.ValueToAdd;

                if (operation.EndIndex < elements.Length - 1)
                {
                    elements[operation.EndIndex + 1] -= operation.ValueToAdd;
                }
                
                WriteElements(elements, iteration++);
            }

            long max = 0, temporaryMax = 0;

            for (var index = 0; index < elements.Length; index++)
            {
                temporaryMax += elements[index];

                if (temporaryMax > max)
                {
                    max = temporaryMax;
                }
            }

            return max;
        }

        private static void WriteElements(long[] elements, int iteration)
        {
            //Console.WriteLine($"Interation {iteration}:");
            //Console.WriteLine($"[{string.Join(", ", elements)}]");
        }
    }
}
