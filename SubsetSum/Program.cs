using System;

namespace SubsetSum
{
    class MainClass
    {
        public static bool SubsetSum(int[] arr, int sum){
            bool[,] DP = new bool[arr.Length + 1, sum + 1];
            for (int i = 0; i < arr.Length;i++){
                DP[i,0] = true;
            }
            for (int i = 1; i < sum;i++){
                DP[0, i] = false;
            }

            for (int i = 1; i <= arr.Length;i++){
                for (int j = 1; j <= sum;j++){
                    if(arr[i-1]>j)
                    {
                        DP[i, j] = DP[i - 1, j];
                    }
                    else if (arr[i-1]<=j){
                        DP[i, j] = DP[i - 1, j] || DP[i - 1, j - arr[i - 1]];
                    }
                }
            }
            return DP[arr.Length, sum];
        }
        public static void Main(string[] args)
        {
            int[] arr = { 2, 3, 7, 8, 10 };
            int sum = 11;
            Console.WriteLine(SubsetSum(arr,sum));
        }
    }
}
