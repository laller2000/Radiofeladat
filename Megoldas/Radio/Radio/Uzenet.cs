using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radio
{
    class Uzenet
    {
        int nap;
        int radioAmator;
        string szoveg;

        public Uzenet(int nap, int radioAmator, string szoveg)
        {
            this.Nap = nap;
            this.RadioAmator = radioAmator;
            this.Szoveg = szoveg;
        }

        public int Nap { get => nap; set => nap = value; }
        public int RadioAmator { get => radioAmator; set => radioAmator = value; }
        public string Szoveg { get => szoveg; set => szoveg = value; }
    }
}
