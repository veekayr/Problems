//https://www.youtube.com/watch?v=NnD96abizww&list=PLrmLmBdmIlpsHaNTPP_jHHDx_os9ItYXr&index=2
//https://github.com/mission-peace/interview/blob/master/src/com/interview/dynamic/LongestCommonSubsequence.java
//http://www.geeksforgeeks.org/longest-common-subsequence/

using System;

namespace LongestCommonSubsequence
{
    class MainClass
    {
        public static int LCS(string str1, string str2){
            int[,] DP = new int[str2.Length + 1, str1.Length + 1];

            for (int i = 1; i <= str2.Length;i++){
                for (int j = 1; j <= str1.Length;j++){
                    if(str2[i-1] ==  str1[j-1]){
                        DP[i, j] = System.Math.Max(DP[i - 1, j], DP[i, j - 1]);
                    }
                    else{
                        DP[i, j] = 1 + DP[i - 1, j - 1];
                    }
                }
            }

            return DP[str2.Length, str1.Length];
        }
        public static void Main(string[] args)
        {
            string str1 = "abcdaf";
            string str2 = "acbcf";
            Console.WriteLine(LCS(str1, str2));
        }
    }
}
