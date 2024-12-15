using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeladatGy_4._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 100; i < 1000; i++)
            {
                int current = i;

                int firstDigit = current % 10; current /= 10;
                int secondDigit = current % 10; current /= 10;
                int thirdDigit = current % 10; current /= 10;

                if ((firstDigit * firstDigit * firstDigit + secondDigit * secondDigit * secondDigit + thirdDigit * thirdDigit * thirdDigit) == i)
                {
                    Console.WriteLine(i);
                }
            }
            Console.ReadLine();
        }
    }
}
