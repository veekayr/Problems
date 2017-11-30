using System;
using System.Collections.Generic;
using System.Linq;

namespace Sort_and_Arrange
{
    class MainClass
    {
        public static void SortArrange(List<int> arr)
        {
            arr.Sort();

            int curIndex = 0;
            int nextIndex = 0;
            int temp;
            int len = 0;
            if(arr.Count()%2==0)
            {
                len = arr.Count();
            }
            else
            {
                len = arr.Count() - 1;
            }
            for (int i = 0; i < len;) 
            {
                curIndex = i;
                nextIndex = i + 1;

                temp = arr[curIndex];
                arr[curIndex] = arr[nextIndex];
                arr[nextIndex] = temp;

                i = i + 2;
            }
        }
        public static void Main(string[] args)
        {
			Console.WriteLine("Input integers with space separated values and press Enter");
			List<int> arr = new List<int>();
			arr = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToList();

            SortArrange(arr);
			Console.WriteLine("Array values up and down:{0}", String.Join(" ", arr));
        }
    }
}
