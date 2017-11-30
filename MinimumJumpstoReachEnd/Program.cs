using System;

namespace MinimumJumpstoReachEnd
{
    class MainClass
    {
        public static int MinimumJumps(int[] arr)
        {
            int i, j;
            int[] jumps = new int[arr.Length];
            int[] steps = new int[arr.Length];
            jumps[0] = 0;
            steps[0] = -1;
            for (int k = 1; k < arr.Length;k++)
            {
                jumps[k] = Int32.MaxValue;
            }
            for (i = 1; i < arr.Length; i++) 
            {
                for (j = 0; j < i; j++) 
                {
                    if (arr[j] +j >= i && jumps[i] > jumps[j] + 1 )
                    {
                        steps[i] = j;
                        jumps[i] = jumps[j] + 1;
                    }
                }
            }
            int index = arr.Length-1;
            int[] stepsWrite = new int[jumps[arr.Length - 1] + 1];
            for (int k = 0; k <= jumps[arr.Length - 1]; k++)
            {
                stepsWrite[k] = index;
                index = steps[index];
            }
            Array.Reverse(stepsWrite);
            Console.WriteLine(string.Join("-->", stepsWrite));


            return jumps[arr.Length - 1];
        }

        public static void Main(string[] args)
        {
            int[] arr = { 2, 3, 1, 1, 2, 4, 4, 0, 1, 1 };

            Console.WriteLine(MinimumJumps(arr));
        }
    }
}
