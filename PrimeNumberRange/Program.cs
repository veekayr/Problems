using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumberRange
{
    class Program
    {
        public static void SieveofEratosthenes(int n)
        {
            bool[] primes = new bool[n+1];
            for (int i = 2; i <= n; i++) 
            {
                primes[i] = true;
            }
            for (int p = 2; p * p <= n; p++)
            {
                if(primes[p] == true)
                {
                    for (int i = p * 2; i <= n; i += p)
                    {
                        primes[i] = false;
                    }
                }
            }

            for (int i = 2; i <= n ; i++)
            {
                if(primes[i])
                {
                    Console.WriteLine(i);
                }
            }
        }

        //Remove all even numbers will reduce space to n/2
        public static void SieveofEratosthenesOptimization1(int n)
        {
            bool[] primes = new bool[n / 2];
            for (int i = 3; i < n; i += 2) 
            {
                primes[i/2] = true;
            }
            for (int p = 3; p * p < n; p+=2)
            {
                if (primes[p / 2] == true)
                {
                    for (int i = p * p; i <= n; i += p * 2) 
                    {
                        primes[i / 2] = false;
                    }
                }
            }
            Console.WriteLine("2");
            for (int i = 3; i < n; i += 2) 
            {
                if (primes[i/2])
                {
                    Console.WriteLine(i);
                }
            }
        }

        //Bitwise Seive to reduce memory to n/64
        public static void SieveofEratosthenesBitwise(int n)
        {
            int[] prime = new int[n / 64];

            for (int p = 3; p * p <= n; p += 2) 
            {
                if(!IfnotPrime(prime, p))
                {
                    for (int i = p * p; i <= n; i += p << 1)
                    {
                        MakeComposite(prime, i);
                    }
                }
            }

            for (int i = 3; i < n; i += 2)
            {
                if (!IfnotPrime(prime, i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        public static bool IfnotPrime(int[] prime, int p)
        {
            return Convert.ToBoolean(prime[p / 64] & (1 << ((p >> 1) & 31)));
        }

        public static void MakeComposite(int[] prime, int p)
        {
            prime[p / 64] |= (1 << ((p >> 1) & 31));
        }

        static void Main(string[] args)
        {
            int n = 50;
            SieveofEratosthenesBitwise(n);
            Console.Read();
        }
    }
}
