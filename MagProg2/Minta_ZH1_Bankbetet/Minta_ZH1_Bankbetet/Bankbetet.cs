using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Minta_ZH1_Bankbetet
{
    internal class Bankbetet
    {
        private string azonosito;
        public string Azonosito
        {
            get { return azonosito; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new Exception("Azonosito nem lehet üres!");
                if (!Regex.IsMatch(value, @"^[A-Z][A-Z\d/]*[^/]$")) throw new Exception("Nem megfelelő azonosito formátum!");

                azonosito = value;
            }
        }

        private int kezdotoke;
        private bool kezdotokeMegadva = false;
        public int Kezdotoke
        {
            get { return kezdotoke; }
            private set
            {
                if (kezdotokeMegadva)
                {
                    throw new Exception("Kezdotoke csak egyszer adható meg");
                }
                if (value < 50000 || value > 100000000) throw new Exception("Csak 50000 és 100000000 közötti érték adható!");
                kezdotoke = value;
                kezdotokeMegadva = true;
            }
        }

        private double kamatlab;
        public double Kamatlab
        {
            get { return kamatlab; }
            private set
            {
                if (value < 0.01 || value > 0.99) throw new Exception("Nem megfelelő érték!");
            }
        }

        private int lekotesIdeje;

        public virtual int GetLekotesIdeje()
        {
            return lekotesIdeje;
        }
        public void SetLekotesIdeje(int evek)
        {
            if (evek < 1 || evek > 20)
            {
                throw new Exception("Nem megfelelő lekötési idő");
            }
            lekotesIdeje = evek;
        }

        public bool HosszuTavuLekotesE { get { return lekotesIdeje > 10; } }

        public Bankbetet(string azonosito, int kezdotoke, double kamatlab, int lekotesIdeje)
        {
            Azonosito = azonosito;
            Kezdotoke = kezdotoke;
            Kamatlab = kamatlab;
            SetLekotesIdeje(lekotesIdeje);
        }

        public Bankbetet(string azonosito, int kezdotoke, double kamatlab) : this(azonosito, kezdotoke, kamatlab, 5)
        {
        }

        public virtual int Hozam(int elteltEvek)
        {
            int hozam = Convert.ToInt32(Kezdotoke * Math.Pow(1 + (Kamatlab / 100), elteltEvek));
            if (elteltEvek >= GetLekotesIdeje())
            {
                return hozam;
            }
            return hozam - (GetLekotesIdeje() * Kezdotoke / 100);
        }
        public override string ToString()
        {
            return $"Azonosito: {Azonosito}, kezdőtőke: {Kezdotoke}, kamatláb: {Kamatlab}, lekötés ideje: {GetLekotesIdeje()}, hosszú távú lekötés-e: {(HosszuTavuLekotesE ? "igen" : "nem")}";
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (!(obj is Bankbetet)) return false;

            Bankbetet masik = obj as Bankbetet;

            if (masik.Azonosito == this.Azonosito)
            {
                return true;
            }
            return false;
        }
    }
}
