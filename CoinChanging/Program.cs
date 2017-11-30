//http://www.geeksforgeeks.org/dynamic-programming-set-7-coin-change/
//https://www.youtube.com/watch?v=NJuKJ8sasGk&t=157s
//https://github.com/mission-peace/interview/blob/master/src/com/interview/dynamic/CoinChanging.java

using System;

namespace CoinChanging
{
    class MainClass
    {
        public static int CoinChange(int[] denom, int n){
            int[] DP = new int[n + 1];
            DP[0] = 1;
            for (int i = 0; i < denom.Length;i++){
                for (int j = i; j <= n;j++){
                    if(j>=denom[i]){
                        DP[j] += DP[j - denom[i]];    
                    }
                }
            }
            return DP[n];
        }
        public static void Main(string[] args)
        {
            int n = 5;
            int[] denom = { 1, 2, 3 };
            Console.WriteLine(CoinChange(denom, n));
        }
    }
}
