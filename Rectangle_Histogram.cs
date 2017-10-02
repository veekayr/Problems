using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
namespace EPAMTests
{
    class MainClass
    {
        public static int MaxRectArea(List<int> arr)
        {
            int maxArea = -1;
            int tempArea = 0;
            int stackTopValue = 0;
			int i = 0;

            //Create empty stack
            Stack st = new Stack();

            //Loop to every element and calculate max area
            for (i = 0; i < arr.Count;)
            {
                if (st.Count == 0 || arr[Convert.ToInt32(st.Peek())] == arr[i]) 
                {
                    st.Pop();
                    st.Push(i++);
                }
                else
                {
                    stackTopValue = Convert.ToInt32(st.Peek());
                    st.Pop();

                    //Calculate Current Area
                    tempArea = arr[stackTopValue] * (st.Count == 0 ? i : (i - Convert.ToInt32(st.Peek()) - 1));

                    //Get Maximum Area
                    maxArea = (maxArea < tempArea) ? tempArea : maxArea;
                }
            }

            //If stack is not empty pop top value
            while (st.Count != 0) 
            {
                stackTopValue = Convert.ToInt32(st.Peek());
				st.Pop();

                //Calculate Current Area
                tempArea = arr[stackTopValue] * (st.Count == 0 ? i : (i - Convert.ToInt32(st.Peek()) - 1));

                //Get Maximum area 
                maxArea = maxArea < tempArea ? tempArea : maxArea;
            }
            return maxArea;
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Input integers with space separated values");
            List<int> arr = new List<int>();
            arr = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToList();
            int result = MaxRectArea(arr);
            Console.WriteLine("Max Rectangle area:{0}", result);
        }
    }
}
