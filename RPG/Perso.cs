using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Perso
    {
        private string _Nom;
        public string Nom
        {
            get { return _Nom; }
            set { _Nom = value; }
        }

        private int _PointsVie;
        public int PointsVie
        {
            get { return _PointsVie; }
            set { _PointsVie = value; }
        }

        private Accessoires _Acces;
        public Accessoires Acces
        {
            get { return _Acces; }
            set { _Acces = value; }
        }
        

        
        public Perso(string nom)
        {
            Nom = nom;
            PointsVie = 10;
        }


        public void ajouterAcces(Accessoires Acc)
        {
            PointsVie = PointsVie + Acc.BonusPointsVie;
        }

        public void avancer()
        {
            Pieces New = new Pieces();
        }

        public void attack()
        {
            PointsVie = PointsVie - 1;
        }

        public void heal()
        {
            PointsVie = PointsVie + 10;
        }

        public void damage()
        {
            PointsVie = PointsVie - 5;
        }
    }
}
