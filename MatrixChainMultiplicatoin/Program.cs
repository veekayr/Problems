//https://www.youtube.com/watch?v=vgLJZMUfnsU
//https://github.com/mission-peace/interview/blob/master/src/com/interview/dynamic/MatrixMultiplicationCost.java
//http://www.geeksforgeeks.org/dynamic-programming-set-8-matrix-chain-multiplication/

using System;

namespace MatrixChainMultiplicatoin
{
    class MainClass
    {
        public static int MatrixMult(int[] arr){
            int j = 0;
            int q;
            int[,] DP = new int[arr.Length + 1, arr.Length + 1];

            for (int L = 2; L <= arr.Length;L++){
                for (int i = 1; i < arr.Length - L + 1;i++){
                    j = i + L - 1;
                    DP[i, j] = System.Int32.MaxValue;
                    for (int k = i; k <= j - 1;k++){
                        q = DP[i, k] + DP[k + 1, j] + arr[i - 1] * arr[k] * arr[j];
                        if (q < DP[i, j])
                        {
                            DP[i, j] = q;
                        }
                    }
                }
            }

            return DP[1, arr.Length - 1];
        }

        public static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4 };

            Console.WriteLine(MatrixMult(arr));
        }
    }
}
