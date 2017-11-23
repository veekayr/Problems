//http://www.geeksforgeeks.org/dynamic-programming-set-5-edit-distance/
//https://www.youtube.com/watch?v=We3YDTzNXEk

using System;

namespace MinimumDistance
{
    class MainClass
    {
        public static int MinimumDistance(string str1, string str2)
        {
            int[,] md = new int[str1.Length + 1, str2.Length + 2];

            if (str1.Length == 0){
                return str2.Length;
            }

            if(str2.Length == 0){
                return str1.Length;
            }

            for (int i = 0; i <= str1.Length;i++){
                for (int j = 0; j <= str2.Length;j++){
                    if(i == 0){
                        md[i, j] = j;
                    }
                    else if(j ==0){
                        md[i, j] = i;
                    }
                    else if(str1[i-1]==str2[j-1]){
                        md[i,j] = md[i - 1,j - 1];
                    }
                    else{
                        md[i, j] = 1 + System.Math.Min(md[i, j - 1], System.Math.Min(md[i - 1, j], md[i - 1, j - 1]));
                    }
                }
            }

            return md[str1.Length, str2.Length];
        }
        public static void Main(string[] args)
        {
            string str1 = "abcdef";
            string str2 = "azced";
            Console.WriteLine(MinimumDistance(str1, str2));
        }
    }
}
