using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_320_4212_Schergen
{
    internal class Geheimagent
    {
        public string Name { get; init; }
        private int _schaden = 3;
        private int _hitpoints = 20;
        
        public bool IstAusserGefecht => _hitpoints <= 0;
        
        /*
         public bool IstAusserGefecht
        {
            get { return _hitpoints > 0 ? false : true ; }
        }
        */

        public int Schaden { get { return _schaden; } }

        public Geheimagent(string name)
        {
            Name = name;
        }

        public void KassiereSchaden(int kassierterSchaden)
        {
            _hitpoints -= kassierterSchaden;
        }

        public int TeileSchadenAus()
        {
            return _schaden;
        }

        public void ReduziereSchaden(int reduktion)
        {
            _schaden -= reduktion;
            if(_schaden < 0)
            {
                _schaden = 0;
            }
        }
    }
}