using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeMinimumQuery
{
    class Program
    {
        static void SparseTablePreprocess(int[] arr, int[,] lookup)
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
        static void SparseTable(int[] arr, int[,] query)
        {
            int[,] lookup = new int[arr.Length, arr.Length];
            SparseTablePreprocess(arr, lookup);

            for (int i = 0; i < query.GetLength(0); i++) 
            {
                Console.WriteLine("Minumum of range [{0},{1}]: {2}", query[i, 0], query[i, 1], arr[lookup[query[i, 0], query[i, 1]]]);
            }
        }

        static void SparseTableOptimizedPreprocess(int[] arr, int[,] lookup)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                lookup[i, 0] = i;
            }

            for (int j = 1; (1 << j) <= arr.Length; j++)
            {
                for (int i = 0; (i + (1 << j) - 1) < arr.Length; i++) 
                {
                    if (arr[lookup[i, j - 1]] < arr[lookup[i + (1 << (j - 1)), j - 1]])
                    {
                        lookup[i, j] = lookup[i, j - 1];
                    }
                    else
                    {
                        lookup[i, j] = lookup[i + (1 << (j - 1)), j - 1];
                    }
                }

            }
            
        }
        static int QueryOptimized(int[] arr, int[,] lookup, int left, int right)
        {
            int j = (int)System.Math.Log(right - left + 1, 2);
            if (arr[lookup[left, j]] <= arr[lookup[right - (1 << j) + 1, j]] ) 
            {
                return arr[lookup[left, j]];
            }

            return arr[lookup[right - (1 << j) + 1, j]];
        }
        static void SparseTableOptimized(int[] arr, int[,] query)
        {
            int j = Convert.ToInt32(System.Math.Log(arr.Length, 2));
            int[,] lookup = new int[arr.Length, j + 1];
            SparseTableOptimizedPreprocess(arr, lookup);

            for (int i = 0; i < query.GetLength(0); i++)
            {
                Console.WriteLine("Minumum of range [{0},{1}]: {2}", query[i, 0], query[i, 1], QueryOptimized(arr, lookup, query[i, 0], query[i, 1]));
            }

        }
        static void Main(string[] args)
        {
            int[] arr = { 7, 2, 3, 0, 5, 10, 3, 12, 18 };
            int[,] query = { { 0, 4 }, { 4, 7 }, { 7, 8 } };

            SparseTableOptimized(arr, query);
            Console.Read();
        }
    }
}
