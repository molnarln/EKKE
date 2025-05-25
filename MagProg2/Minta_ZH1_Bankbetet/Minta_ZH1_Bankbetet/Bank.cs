using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minta_ZH1_Bankbetet
{
    internal class Bank
    {
        private List<Bankbetet> bankbetetek;

        public List<Bankbetet> Bankbetetek
        {
            get
            {
                return new List<Bankbetet>(bankbetetek);
            }
        }

        public string BankNeve { get; set; }

        public void BankbetetHozzaadasa(Bankbetet bankbetet)
        {
            if (bankbetetek.Contains(bankbetet))
            {
                throw new Exception("A bankbetét már létezik a DB-ben");
            }
            //nincs klónozás, a feladat nem kérte
            bankbetetek.Add(bankbetet);
        }
        public Bank()
        {
            this.bankbetetek = new List<Bankbetet>();
        }

        public List<Bankbetet> BankbetetekMagasKezdotokevel
        {
            get
            {
                return bankbetetek.Where(_ => _.Kezdotoke > 5000000).ToList();
            }
        }

        public List<BefektetesiJegy> BefektetesiJegyekAdottHozamFelett(double hozam)
        {
            //List<BefektetesiJegy> temp = new List<BefektetesiJegy>();
            //foreach (Bankbetet bb in bankbetetek)
            //{
            //    if (bb is BefektetesiJegy)
            //    {
            //        BefektetesiJegy masik = bb as BefektetesiJegy;
            //        if (masik.MinimumHozam > hozam)
            //        {
            //            temp.Add(masik);
            //        }
            //    }
            //}
            //return temp;

            //vagy:
            return bankbetetek
                            .OfType<BefektetesiJegy>()
                            .Where(bj => bj.MinimumHozam > hozam)
                            .ToList();
        }

        public Bankbetet this[string azonosito]
        {
            get
            {
                return bankbetetek.Where(_ => _.Azonosito == azonosito).FirstOrDefault();
            }
        }
    }
}
