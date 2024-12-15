using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace feladatgy_2._8
{
    internal class Program
    {
        static int minimalisIdokoz = 120;
        static void Main(string[] args)
        {
            Console.WriteLine("Adja meg a vezetéknevét: ");
            string vezeteknevNagybetus = Console.ReadLine();
            string vezeteknev = vezeteknevNagybetus.ToLower();

            Console.WriteLine("Adja meg a keresztnevét: ");
            string keresztnevNagybetus = Console.ReadLine();
            string keresztnev = keresztnevNagybetus.ToLower();

            string email = string.Format("{0}.{1}@uni-eszterhazy.hu", vezeteknev, keresztnev);

            Console.WriteLine("Adja meg a szolgátlató azonosítót: ");
            string szolgaltatoAzonosit = Console.ReadLine();

            if (szolgaltatoAzonosit != "20" && szolgaltatoAzonosit != "30" && szolgaltatoAzonosit != "70")
            {
                Console.WriteLine("Helytelen azonosítót adott meg!");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Adja meg a hívószámot: ");

            string hivoszam = Console.ReadLine();
            if (hivoszam.StartsWith("0"))
            {
                Console.WriteLine("Hívószám nem kezdődhet 0-val!");
                Console.ReadLine();
                return;
            }

            if (hivoszam.Length != 7)
            {
                Console.WriteLine("Hívószám hossza 7 karakter!");
                Console.ReadLine();
                return;
            }

            string telefonszam = string.Format("+{0}{1}", szolgaltatoAzonosit, hivoszam);

            Console.WriteLine("Mikor kapta a 2. oltást? ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Clear();

            int elteltNapok = (int)(DateTime.Now - date).TotalDays;
            if (elteltNapok > minimalisIdokoz)
            {
                Console.WriteLine("Ön bármikor felveheti a 3. oltást.");
            }
            else
            {
                Console.WriteLine("Kedves {0} {1}!\r\nÖn {2}-án kapta meg a második oltását. Ennek megfelelően a 3. oltását\r\nlegkorábban {3} nap múlva veheti föl. Erről e-mailben értesítjük a\r\n{4}\r\ncímen, valamint felvesszük Önnel a kapcsolatot a {5}-es telefonszámon\r\nis!\r\nÜdvözlettel,\r\nMüller Cecília", vezeteknevNagybetus, keresztnevNagybetus, date.ToString("yyyy. MMMM dd."), minimalisIdokoz - elteltNapok, email, telefonszam);
            }

            Console.ReadLine();
        }
    }
}
