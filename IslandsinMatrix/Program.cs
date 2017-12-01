using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsinMatrix
{
    class Program
    {
        static int CountIslands(int[,] matrix)
        {
            int count = 0;
            int[,] visited = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < visited.GetLength(0); i++)
            {
                for (int j = 0; j < visited.GetLength(1); j++)
                {
                    visited[i, j] = 0;
                }
            }
            int row, col = 0;
            for (row = 0; row < matrix.GetLength(0); row++)
            {
                for (col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 1 && visited[row, col] == 0) 
                    {
                        DFS(matrix, row, col, visited);
                        ++count; 
                    }
                }
            }

            return count;
        }
        static void DFS(int[,]matrix, int row, int col, int[,] visited)
        {
            visited[row, col] = 1;
            int[] rowNbr = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] colNbr = { -1, 0, 1, -1, 1, -1, 0, 1 };
            for (int i = 0; i < 8; i++)
            {
                if (IsSafe(matrix, row + rowNbr[i], col + colNbr[i], visited))
                {
                    DFS(matrix, row + rowNbr[i], col + colNbr[i], visited);
                }
            }
        }
        static bool IsSafe(int[,] matrix, int row, int col, int[,] visited)
        {
            return (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1) && matrix[row, col] == 1 && visited[row, col] == 0);
        }
        static void Main(string[] args)
        {
            int[,] matrix = { { 1, 1, 0, 0, 0},
                            {0, 1, 0, 0, 1 },
                            {1, 0, 0, 1, 1 },
                            {0, 0, 0, 0, 0 },
                            {1, 0, 1, 0, 1 }};

            Console.WriteLine("Number of Islands in matrix:{0}", CountIslands(matrix));

            Console.Read();
        }
    }
}
