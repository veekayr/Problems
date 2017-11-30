//https://github.com/mission-peace/interview/blob/master/src/com/interview/dynamic/EggDropping.java
//https://www.youtube.com/watch?v=3hcaVyX00_4&list=PLrmLmBdmIlpsHaNTPP_jHHDx_os9ItYXr&index=13
//http://www.geeksforgeeks.org/dynamic-programming-set-11-egg-dropping-puzzle/

using System;

namespace EggDropping
{
    class MainClass
    {
        public static int EggDrop(int floor, int eggs){
            int[,] DP = new int[eggs + 1, floor + 1];
            int c;
            for (int i = 0; i <= floor; i++)
            {
                DP[1, i] = i;
            }
            for (int i = 2; i <= eggs;i++){
                for (int j = 1; j <= floor;j++){
                    DP[i,j] = System.Int32.MaxValue;
                    for (int k = 1; k <= j;k++){
                        c = 1 + System.Math.Max(DP[i - 1, k - 1], DP[i, j - k]);
                        if( c < DP[i,j] ){
                            DP[i, j] = c;
                        }
                    }
                }
            }
            for (int i = 0; i <= eggs;i++)
            {
                for (int j = 0; j <= floor;j++)
                {
                    Console.Write(DP[i,j]+" ");
                }
                Console.WriteLine();
            }
            return DP[eggs, floor];
        }
        public static void Main(string[] args)
        {
            int eggs = 2;
            int floor = 6;
            Console.WriteLine(EggDrop(floor, eggs));
        }
    }
}
