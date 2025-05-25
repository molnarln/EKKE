using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaztartasiGepek
{
    public interface IMosogep
    {
        int MaxToltotomeg { get; }
        int MaxFordulat { get; }
        double VizFelhasznalas(MosogepProgram mosogepProgram, double tomeg);

    }
}
