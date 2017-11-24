using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearSearch
{
    class Program
    {
        public static int LinearSearch(int[] arr, int ele)
        {
            for(int i = 0;i<arr.Length;i++)
            {
                if(arr[i] == ele)
                {
                    return i;
                }
            }
            return -1;
        }
        static void Main(string[] args)
        {
            int[] arr = { 1, 10 };
            int ele = 10;
            Console.WriteLine("{0} found at index {1}", ele, LinearSearch(arr, ele));
            Console.Read();
        }
    }
}
