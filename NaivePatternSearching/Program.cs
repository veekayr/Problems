using System;

namespace NaivePatternSearching
{
    class MainClass
    {
        public static void KMPAlgorithm(string text, string pattern){

            int n = text.Length;
            int m = pattern.Length;

            int[] lps = LPS(pattern);
            int i = 0, j = 0;
            while(i<n){
                if(pattern[j] == text[i]){
                    i++;
                    j++;
                }
                if(j == m){
                    Console.WriteLine("Pattern found at index:{0}", i - j);
                    j = lps[j - 1];
                }
                else if (i<n && pattern[j]!=text[i]){
                    if(j!=0){
                        j = lps[j - 1];
                    }
                    else{
                        i++;
                    }
                    
                }

            }
        }
        public static int[] LPS(string pattern){

            int len = 0, i = 1;
            int[] lps = new int[pattern.Length];
            while(len <pattern.Length){
                if(pattern[len] ==  pattern[i]){
                    len++;
                    lps[i] = len;
                    i++;
                }
                else{
                    if(len != 0){
                        len = lps[len - 1];
                    }
                    else{
                        lps[i] = 0;
                        i++;
                    }
                }
            }
            return lps;
        }
        public static void PatternSearch(string text, string pattern){

            for (int i = 0; i <= text.Length - pattern.Length;i++){
                int j;
                for (j = 0; j < pattern.Length;j++){
                    if(text[i+j]!=pattern[j]){
                        break;
                    }
                }
                if(j == pattern.Length){
                    Console.WriteLine("Pattern found at index:{0}", i);
                }
            }
            
        }
        public static void Main(string[] args)
        {
            string text = "AABAACAADAABAAABAA";
            string pattern = "AABA";
            PatternSearch(text, pattern);

        }
    }
}
