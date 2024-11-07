using System;
using System.Collections.Generic;
using System.Linq;

namespace Beugro_feladatok
{
    class Program
    {
        static void Main(string[] args)
        {
            var intList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            var inputNumber = 3;
            var inputNumber2 = 9;

            Console.WriteLine("The number is inside the list: {0}", IsInList(intList, inputNumber));
            Console.WriteLine("The number is inside the list: {0}", IsInList(intList, inputNumber2));

            Parosak(intList.ToArray());

            Console.WriteLine(CalculateSum(intList.ToArray()));

            var intList2 = new List<int>() { -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7 };
            Console.WriteLine(NumberOfItemsInInterval(intList2, 2));

            Console.WriteLine("NumberOfElements: " + CountArray(intList2.ToArray()));

            Console.WriteLine("Nagyobb, mint: " + HanyNagyobb(intList2, -1));

            WriteCharacterOnConsole(Karakterek.ZERO);
            WriteCharacterOnConsole(Karakterek.HASH);
            WriteCharacterOnConsole(Karakterek.ASTERISK);

            Console.WriteLine(String.Join(',', CreateArrayWithRandomNumbers(-2131, 123, 5)));
            HettelOszthato(intList2);
            //var eredmeny = 0;
            Console.WriteLine(OszthatokEgymassal(4, 2, out int eredmeny) + " " + eredmeny);
            Console.WriteLine(OszthatokEgymassal(4, 3, out eredmeny) + " " + eredmeny);

            var lebegoPontosArray = new float[] { 21f, 3.342f, 42.2342f, 3234.432234f, -1234f, 21342f };

            Console.WriteLine(LebegoPontosOsszeg(lebegoPontosArray, 22));



        }


        //1.Írj egy függvényt, mely egy egész számokat tartalmazó listát kap paraméterként és egy x számot! A függvény adjon vissza igazat, ha az x megtalálható az elemek között, egyébként pedig hamisat!
        public static bool IsInList(List<int> inputList, int inputNumber)
        {
            //if (inputList.Contains(inputNumber)) return true;
            //return false;
            foreach (var item in inputList)
            {
                if (item == inputNumber) return true;
            }
            return false;
        }

        //2.Eljárás 1 paraméteres int tömbbel.Ki kell íratni belőle az elemeket, amik pozitív párosak.

        private static void Parosak(int[] inputArray)
        {
            Console.WriteLine("A lista páros számai:");
            //foreach (var item in inputArray)
            //{
            //    if (item % 2 == 0) Console.Write(item + ", ");
            //}

            var temp = new List<int>();

            foreach (var item in inputArray)
            {
                if (item % 2 == 0) temp.Add(item);
            }
            //for (int i = 0; i < temp.Count - 1; i++)
            //{
            //    Console.Write(temp[i] + ", ");
            //}
            //Console.Write(temp[temp.Count - 1]);

            Console.WriteLine(String.Join(',', temp));
        }

        //3. Függvény, ami 1 paramétert vár, egy int tömböt. Ki kell számolni a tömb elemek összegét és visszaadni a kapott összeget.
        private static int CalculateSum(int[] inputArray)
        {
            int sum = 0;
            foreach (var item in inputArray)
            {
                sum += item;
            }
            return sum;
        }

        //4.Függvény 2 paraméterrel: 1 lista egész számokkal és 1 db egész szám (x). Megszámlálni a listában: hány olyan szám van, ami -x és +x intervallumon van. Ezek darabszámát adja vissza.
        private static int NumberOfItemsInInterval(List<int> inputList, int input)
        {
            int returnValue = 0;

            foreach (var item in inputList)
            {
                if (item > -input && item < input) returnValue++;
            }
            return returnValue;
        }

        //5.Írj egy metódust, ami paraméterként egy egészeket tartalmazó tömböt kap, és azt adja vissza, hogy hány eleme van a tömbnek!

        private static int CountArray(int[] inputArray)
        {
            return inputArray.Length;
        }

        //6.Írj egy metódust, aminek a paraméterei egy egészekből álló lista és egy szám. A metódus adja meg, hogy a listában található számok közül hány nagyobb, mint a paraméterként kapott szám.

        private static int HanyNagyobb(List<int> inputList, int inputNumber)
        {
            int returnValue = 0;

            foreach (var item in inputList)
            {
                if (item > inputNumber) returnValue++;
            }
            return returnValue;
        }

        //7.Írj egy metódust, ami egy olyan enum típust vár paraméterként, aminek az értékei a következők lehetnek: ZERO, ASTERISK, HASH. A paraméter értékétől függően írjon ki a konzolra ötöt a megfelelő karakterből.
        private static void WriteCharacterOnConsole(Karakterek chartype)
        {
            switch (chartype)
            {
                case Karakterek.ZERO:
                    Console.WriteLine(String.Join("", Enumerable.Repeat((char)Karakterek.ZERO, 5).ToArray()));
                    break;
                case Karakterek.ASTERISK:
                    Console.WriteLine(String.Join("", Enumerable.Repeat((char)Karakterek.ASTERISK, 5).ToArray()));
                    break;
                case Karakterek.HASH:
                    Console.WriteLine(String.Join("", Enumerable.Repeat((char)Karakterek.HASH, 5).ToArray()));
                    break;
                default:
                    break;
            }
        }

        //8.Írj egy metódust, ami az x, y, és n egész számokat kéri paraméternek.A metódus hozzon létre egy n hosszúságú tömböt, amit töltsön fel x és y közötti random számokkal.A végén adja vissza a tömböt.

        private static int[] CreateArrayWithRandomNumbers(int lowerEnd, int upperEnd, int size)
        {
            var returnArray = new int[size];
            var random = new Random();

            for (int i = 0; i < returnArray.Length; i++)
            {
                returnArray[i] = random.Next(lowerEnd, upperEnd);
            }
            return returnArray;
        }

        //Írj egy metódust, ami kap egy egészelemű listát, és kiírja azokat az elemeit, amik oszthatóak 7-tel.
        private static void HettelOszthato(List<int> inputList)
        {
            Console.WriteLine("A lista 7-tel osztható számai:");
            //foreach (var item in inputArray)
            //{
            //    if (item % 2 == 0) Console.Write(item + ", ");
            //}

            var temp = new List<int>();

            foreach (var item in inputList)
            {
                if (item % 7 == 0) temp.Add(item);
            }
            //for (int i = 0; i < temp.Count - 1; i++)
            //{
            //    Console.Write(temp[i] + ", ");
            //}
            //Console.Write(temp[temp.Count - 1]);

            Console.WriteLine(String.Join(',', temp));
        }

        //10.(Írj egy metódust, aminek két egész paramétere (n, m) van. Ha n osztható m-el, a metódus adjon vissza igaz logikai értéket, és egy harmadik, referencia típusú paraméterbe írja ki az osztás eredményét. Ha n nem osztható m-el, hamis logikai értéket adjon vissza. – out)

        private static bool OszthatokEgymassal(int n, int m, out int eredmeny)
        {
            eredmeny = 0;
            if (n % m == 0)
            {
                eredmeny = n / m;
                return true;
            }
            return false;
        }

        //11.Írj egy függvényt, amely bekér egy lebegőpontos számokat tartalmazó tömböt és egy x számot. És visszaadja a tömbben található, x-nél kisebb számok összegét.

        private static float LebegoPontosOsszeg(float[] inputArray, int inputNumber)
        {
            var returnValue = 0f;

            foreach (var item in inputArray)
            {
                if (item < inputNumber) returnValue += item;
            }
            return returnValue;
        }
    }
}
public enum Karakterek
{
    ZERO = '0',
    ASTERISK = '*',
    HASH = '#'
}