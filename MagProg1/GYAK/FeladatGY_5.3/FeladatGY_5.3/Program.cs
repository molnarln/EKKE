using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeladatGY_5._3
{
    internal class Program
    {
        static int[] cimletek = new int[] { 500, 1000, 2000, 5000, 10000, 20000 };
        static int[] kifogyottCimletek = new int[] { 20000 };

        static void Main(string[] args)
        {
            Console.WriteLine("Adja meg a felvenni kívánt összeget: ");

            int osszeg = int.Parse(Console.ReadLine());
            int eredetiOsszeg = osszeg;
            
            for (int i = cimletek.Length - 1; i >= 0; i--)
            {
                // Ha az első címletre van találat, akkor azt bontsa fel!
                if (eredetiOsszeg == cimletek[i])
                {
                    continue;
                }
            
                while (osszeg >= cimletek[i])
                {
                    bool cimletHianyzik = false;
                    for (int j = 0; j < kifogyottCimletek.Length; j++)
                    {
                        if (cimletek[i] == kifogyottCimletek[j])
                        {
                            cimletHianyzik = true;
                            break;
                        }
                    }
                    if (cimletHianyzik)
                    {
                        break;
                    }
                    Console.WriteLine("Kiadva: {0}", cimletek[i]);
                    osszeg -= cimletek[i];
                }
            }

            Console.ReadLine();
        }
    }
}
