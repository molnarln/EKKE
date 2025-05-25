using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaztartasiGepek
{
    public class GyartoNemTalalhatoException : Exception
    {
        public Gyarto Gyarto { get; set; }
        public GyartoNemTalalhatoException(Gyarto gyarto)
        {
            Gyarto = gyarto;
        }
    }
}
