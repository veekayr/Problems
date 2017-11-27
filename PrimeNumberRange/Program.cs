using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumberRange
{
    class Program
    {
        public static void SieveofEratosthenes(int n, List<int> primes)
        {
            for (int i = 0; i < n; i++)
            {
                primes.Add(i);
            }
        }
        static void Main(string[] args)
        {
            int n = 50;
            List<int> primes = new List<int>();
            SieveofEratosthenes(n, primes);
            Console.WriteLine(String.Join(",", primes));
            Console.Read();
        }
    }
}
