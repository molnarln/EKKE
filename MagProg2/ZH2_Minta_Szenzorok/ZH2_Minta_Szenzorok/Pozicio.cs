using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2_Minta_Szenzorok
{
    public class Pozicio : ICloneable
    {
        public Pozicio(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int x { get; set; }
        public int y { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
