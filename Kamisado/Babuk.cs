using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kamisado
{
    class Babuk
    {

        string nev;
        string koordinata;
        string tipus;

        public string Tipus
        {
            get
            {
                return tipus;
            }

            
        }

        public string Koordinata
        {
            get
            {
                return koordinata;
            }

            set
            {
                koordinata = value;
            }
        }

        public string Nev
        {
            get
            {
                return nev;
            }

            
        }

        public Babuk(string nev, string tipus, string koordinata)
        {
            this.nev = nev;
            this.tipus = tipus;
            this.koordinata = koordinata;
        }
        
    }
}
