//https://github.com/mission-peace/interview/blob/master/src/com/interview/dynamic/Knapsack01.java
//https://www.youtube.com/watch?v=8LusJS5-AGo&list=PLrmLmBdmIlpsHaNTPP_jHHDx_os9ItYXr&index=1
//http://www.geeksforgeeks.org/knapsack-problem/

using System;

namespace KnapsackProblem
{
    class MainClass
    {
        public static int Knapsack(int[] value, int[] weight, int totalweight){

            int[,] DP = new int[weight.Length + 1, totalweight + 1];

            for (int i = 0; i <= weight.Length;i++)
            {
                for (int j = 0; j <= totalweight;j++){
                    if(i == 0 || j ==0){
                        DP[i,j] = 0;
                    }
                    else if(j>=weight[i-1]){
                        DP[i, j] = System.Math.Max(value[i - 1] + DP[i - 1, j - weight[i-1]], DP[i - 1, j]);
                    }
                    else{
                        DP[i, j] = DP[i - 1, j];
                    }
                }
            }
            return DP[weight.Length, totalweight];
        }
        public static void Main(string[] args)
        {
            int totalweight = 7;
            int[] value = { 1, 4, 5, 7 };
            int[] weight = { 1, 3, 4, 5 };
            Console.WriteLine(Knapsack(value, weight, totalweight));
        }
    }
}
