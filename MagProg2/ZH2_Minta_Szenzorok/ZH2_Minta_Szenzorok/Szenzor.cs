﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2_Minta_Szenzorok
{
    public abstract class Szenzor : ICloneable
    {
        public Pozicio Pozicio { get; private set; }
        public abstract bool Aktiv { get; }

        public abstract void Adatkuldes();

        protected Szenzor(Pozicio pozicio)
        {
            this.Pozicio = pozicio;
        }

        public abstract object Clone();

        public override string ToString()
        {
            return string.Format("{0} ({1}; {2})",
    Aktiv ? "On" : "Off",
    Pozicio.x, Pozicio.y);
        }
    }
}
