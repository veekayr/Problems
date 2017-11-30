using System;
using System.Collections.Generic;
using System.Linq;

namespace RotatebyKUnit
{
    class MainClass
    {
        public static List<int> RotateKUnit(List<int> arr, int k)
        {
            //Revers array
            arr.Reverse();
            List<int> temp1 = new List<int>();
            List<int> temp2 = new List<int>();

            //Reverse first k elements
            temp1 = arr.GetRange(0, k);
            temp1.Reverse();

            //Revers n-k elements
            temp2 = arr.GetRange(k, arr.Count() - k);
            temp2.Reverse();

            temp1.AddRange(temp2);

            return temp1;
        }
        
        public static void Main(string[] args)
        {
			Console.WriteLine("Input integers with space separated values and press Enter");
			List<int> arr = new List<int>();
			arr = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToList();

			Console.WriteLine("Enter number of rotations and press Enter");
			int k = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine(String.Join(" ", RotateKUnit(arr, k)));
        }
    }
}
