using System;

namespace InterleavedStrings
{
    class MainClass
    {
        public static bool IsInterleaved(string a, string b, string c)
        {
            bool[,] IL = new bool[a.Length + 1, b.Length + 1];

            //If length doesnot match then return false
            if(c.Length != a.Length+b.Length)
            {
                return false;
            }

            for (int i = 0; i <= a.Length; i++)
            {
                for (int j = 0; j <= b.Length; j++)
                {
                    int l = i + j - 1;

                    //First row,column set to true
                    if (i == 0 && j == 0)
                    {
                        IL[i, j] = true;
                    }

                    //For first row, if value match then set value from previous column
                    //[i,j-1] means same row previous column 
                    else if (i == 0)
                    {
                        if (b[j - 1] == c[l])
                        {
                            IL[i, j] = IL[i, j - 1];
                        }
                    }

                    //For first column, if value match then set value from previous row
                    //[i-1,j] means previous row same column
                    else if (j == 0)
                    {
                        if (a[i - 1] == c[l])
                        {
                            IL[i, j] = IL[i - 1, j];
                        }
                    }

                    //For other rows and columns if value match then set value from previous row/column
                    else
                    {
                        IL[i, j] = (b[j - 1] == c[l] ? IL[i, j - 1] : false || a[i - 1] == c[l] ? IL[i - 1, j] : false);
                    }

                }

            }

            return IL[a.Length, b.Length];
        }
        
        public static void Main(string[] args)
        {
            string s1 = "aab";
            string s2 = "axy";
            string s3 = "aaxabyc";
            Console.WriteLine(IsInterleaved(s1, s2, s3));
            Console.ReadLine();
        }
    }
}
