using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WielkieKino.Lib
{
    public class Bilet
    {
        public Seans Seans { get; private set; }
        public double Cena { get; private set; }
        public int Rzad { get; private set; }
        public int Miejsce { get; private set; }

        public Bilet(Seans seans, double cena, int rzad, int miejsce)
        {
            Seans = seans;
            Cena = cena;
            Rzad = rzad;
            Miejsce = miejsce;
        }
    }
}
