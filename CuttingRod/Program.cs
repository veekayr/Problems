//https://github.com/mission-peace/interview/blob/master/src/com/interview/dynamic/CuttingRod.java
//http://www.geeksforgeeks.org/dynamic-programming-set-13-cutting-a-rod/
//https://www.youtube.com/watch?v=IRwVmTmN6go

using System;

namespace CuttingRod
{
    class MainClass
    {
        public static int CuttingRod(int[] weight, int totalLength){

            int[] CR = new int[totalLength + 1];

            for (int i = 1; i <= weight.Length;i++)
            {
                for (int j = i; j <=totalLength;j++){

                    CR[j] = System.Math.Max(CR[j], CR[j - i] + weight[i - 1]);
                }
            }

            return CR[totalLength];
        }
        public static void Main(string[] args)
        {
            int[] weight = { 2, 5, 7, 8 };
            Console.WriteLine(CuttingRod(weight, 5));
        }
    }
}
