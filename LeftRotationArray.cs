using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace LeftRotationArray
{
	class MainClass
	{
        static void leftRotation(List<int> arr, int k, int[] result)
		{
			int new_index = 0;
            for (int i = 0; i < arr.Count(); i++)
			{
                //Change index for new array based on rotation value
                new_index = arr.Count() - k + i;
                if (new_index >= arr.Count()) 
				{
                    new_index = -k + i;
				}
                result[new_index] = arr[i];
			}
		}

		public static void Main(String[] args)
		{
            Console.WriteLine("Input integers with space separated values");
			List<int> arr = new List<int>();
			arr = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToList();

            Console.WriteLine("Enter number of rotations");
            int k = Convert.ToInt32(Console.ReadLine());

            int[] result = new int[arr.Count()];
			leftRotation(arr, k, result);
			Console.WriteLine(String.Join(" ", result));
		}
	}
}
