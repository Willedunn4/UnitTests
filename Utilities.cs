using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace UtilitiesDemo
{
    class Utilities
    {
        public static double Floor(double num)
        {
            return Math.Floor(num);
        }

        public static string JoinNames(string firstName, string lastName)
        {
            return $"{lastName}, {firstName}";
        }

        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        public static bool IsPrime(int num)
        {
            if (num <= 1)
            {
                return false;
            }
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static List<int> NonPrimeDivisors(int num)
        {
            var divisors = new List<int>();
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0 && !IsPrime(i))
                {
                    divisors.Add(i);
                }
            }
            return divisors;
        }

        public static int DivideAndFloor(int num1, int num2)
        {
            return (int)Math.Floor(Math.Max(num1, num2) / (double)Math.Min(num1, num2));
        }

        public static Dictionary<int, int> NonPrimeDivisorsOrdered(int num)
        {
            var divisors = NonPrimeDivisors(num);
            divisors.Sort();
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < divisors.Count; i++)
            {
                dict[2 * i + 1] = divisors[i];
            }
            return dict;
        }
    }
}

