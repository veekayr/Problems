using System;

namespace LongestIncreasingSubsequence
{
    class MainClass
    {
        public static int LIS(int[] arr){
            int[] DP = new int[arr.Length];
            int max = -1;
            for (int i = 0; i < arr.Length;i++){
                DP[i] = 1;
            }

            for (int i = 1; i < arr.Length;i++){
                for (int j = 0; j < i;j++){
                    if(arr[j]<arr[i]){
                        DP[i] = DP[j] + 1;
                        if(DP[i]>max){
                            max = DP[i];
                        }
                    }
                }
            }

            return max;
        }
        public static void Main(string[] args)
        {
            int[] arr1 = { 3, 4, -1, 0, 6, 2, 3 };
            int[] arr2 = { 2, 5, 1, 8, 3 };
            Console.WriteLine(LIS(arr2));
        }
    }
}
