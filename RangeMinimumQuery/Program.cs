using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeMinimumQuery
{
    class Program
    {
        static void NaivePreprocess(int[] arr, int[,] lookup)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                lookup[i, i] = i;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[lookup[i, j - 1]] < arr[j])
                    {
                        lookup[i, j] = lookup[i, j - 1];
                    }
                    else
                    {
                        lookup[i, j] = j;
                    }
                }
            }
        }
        static void NaiveSolution(int[] arr, int[,] query)
        {
            int[,] lookup = new int[arr.Length, arr.Length];
            NaivePreprocess(arr, lookup);

            for (int i = 0; i < query.GetLength(0); i++) 
            {
                Console.WriteLine("Minumum of range [{0},{1}]: {2}", query[i, 0], query[i, 1], arr[lookup[query[i, 0], query[i, 1]]]);
            }
        }
        static void Main(string[] args)
        {
            int[] arr = { 7, 2, 3, 0, 5, 10, 3, 12, 18 };
            int[,] query = { { 0, 4 }, { 4, 7 }, { 7, 8 } };

            NaiveSolution(arr, query);
            Console.Read();
        }
    }
}
