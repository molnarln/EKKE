using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feladatgy_3._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int counter = 0;
            while (counter < 1000)
            {

                // a) Egész szám a[0; 100) intervaluumból.
                Console.WriteLine(rnd.Next(0, 101));

                //b) Páros egész a(−23; 55] intervallumból.
                Console.WriteLine(rnd.Next(-11, 22) * 2);

                //c) Páratlan egész a(24; ∞) intervallumból.
                Console.WriteLine((rnd.Next(12, int.MaxValue / 2) * 2) - 1);
                //d) 10 - zel osztható egész a[333, 4444] intervallumból.
                Console.WriteLine(rnd.Next(34, 444) * 10);
                //e) Valós szám a[−30, 4; 75,347) intervallumból.
                Console.WriteLine(rnd.NextDouble() * (75.347 - (-30.4)) - 30.4);
                //f) Valós szám a[10; 20) ∪ [30; 40) intervallumból.
                Console.WriteLine("f){0}",rnd.Next(1, 3) == 1 ? rnd.Next(10, 20) : rnd.Next(30, 40));

            }

            Console.ReadLine();
        }
    }
}
