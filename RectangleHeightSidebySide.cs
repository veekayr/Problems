using System;
using System.Collections.Generic;
using System.Linq;

namespace RectangleSidebySide
{
    class MainClass
    {
        public static int MaxRectArea(List<int> arr)
        {
            int maxArea = -1;
            int curArea = 0;

            for (int i = 0; i < arr.Count()-1; i++) 
            {
                if (arr[i] == arr[i + 1] ) 
                {
                    if(curArea == 0 )
                    {
                        curArea = arr[i];
                    }
                    curArea += arr[i];
                    maxArea = maxArea < curArea ? curArea : maxArea;
                }
                else
                {
                    curArea = 0;
                }
            }

            return maxArea;
        }
        public static void Main(string[] args)
        {
			Console.WriteLine("Input integers with space separated values and press enter");
			List<int> arr = new List<int>();
			arr = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToList();
			int result = MaxRectArea(arr);
			Console.WriteLine("Max Rectangle area:{0}", result);
        }
    }
}
