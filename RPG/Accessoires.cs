using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Accessoires
    {
        public static Random R = new Random();
        Perso P;

        private int _BonusPointsVie;
        public int BonusPointsVie
        {
            get { return _BonusPointsVie; }
            set { _BonusPointsVie = value; }
        }



        public Accessoires()
        {
            _BonusPointsVie = R.Next(1, 11);
        }

        public void UseAccessoires()
        {
            P.PointsVie = P.PointsVie + BonusPointsVie;
        }
        
    }
}
