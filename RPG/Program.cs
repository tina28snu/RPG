using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Program
    {
        public static Random R = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("==========================");
            Console.WriteLine("===== Welcome to RPG =====");
            Console.WriteLine("==========================");
            Console.WriteLine("Press 1 to Play. Press 2 to Quit");
            int Play;
            int.TryParse(Console.ReadLine(), out Play);
            bool choix = true;
            if (Play == 1)
            {
                choix = true;
            }
            else if (Play == 2)
            {
                choix = false;
            }
            else
            {
                Console.WriteLine("Press 1 to Play. Press 2 to Quit. Any other key will start the game.");
                int.TryParse(Console.ReadLine(), out Play);
            }
                

            while (choix)
            {
                Console.WriteLine("Veuillez choisir un nom pour votre Personnage: ");
                string NOM = Console.ReadLine();

                Perso Pers = new Perso(NOM);


                Accessoires Pacc = new Accessoires();
                Pers.ajouterAcces(Pacc);
                Console.WriteLine("\n" + NOM + " has received a starting accesory which adds " + Pacc.BonusPointsVie + " points to his life force.");
                Console.WriteLine("Status life force: " + Pers.PointsVie + "\n");


                bool newRoom = true;
                while (newRoom)
                {
                    Accessoires Eacc = new Accessoires();
                    Pieces p1 = new Pieces();
                    p1.Enemi = new Enemy("Monster");
                    p1.Enemi.ajouterAcces(Eacc);
                    p1.Access = new Accessoires();
                    Pieces p2 = new Pieces();
                    p2.Access = new Accessoires();
                    Pieces P = new Pieces();


                    Console.WriteLine("===== New Room =====");
                    int ChoixPiece = R.Next(0, 2);
                    if (ChoixPiece == 0) P = p1;
                    else P = p2;

                    if (P == p1)
                    {
                        Console.WriteLine("This room contains an accessory guarded by a monster." + "\n" +  "Status life force Monster: " + P.Enemi.PointsVie);
                        int ProbAttack = R.Next(0, 2);
                        if (ProbAttack == 0)
                        {
                            Console.WriteLine("The monster didn't see you. What do you want to do?" + "\n" + "Press 1 if you want to attack" + "\n" + "Press 2 if you want to try another room (you will loose 2 points life force)");
                            int room;
                            int.TryParse(Console.ReadLine(), out room);
                            if (room == 1)
                            {
                                while (Pers.PointsVie >= 0 && p1.Enemi.PointsVie >= 0)
                                {
                                    Console.WriteLine("\n" + "Status life force Monster: " + P.Enemi.PointsVie + "\n" + "Status life force " + NOM + " : " + Pers.PointsVie);
                                    Console.WriteLine("Your turn. What do you want to do? Press 1 to heal. Press any other key to attack.");
                                    int attackheal;
                                    int.TryParse(Console.ReadLine(), out attackheal);
                                    if (attackheal == 1)
                                    {
                                        Pers.heal();
                                    }
                                    else
                                    {
                                        Pers.attack();
                                        p1.Enemi.damage();
                                    }

                                    Console.WriteLine("\n" + "Status life force Monster: " + P.Enemi.PointsVie + "\n" + "Status life force " + NOM + " : " + Pers.PointsVie);
                                    Console.WriteLine("The monster attacks");
                                    if (p1.Enemi.PointsVie > 0)
                                    {
                                        p1.Enemi.attack();
                                        Pers.damage();
                                    }
                                    
                                }
                                if (Pers.PointsVie <= 0)
                                {
                                    Console.WriteLine("\n" + NOM + " has no points of life force left. You lost. Game over");
                                    choix = false;
                                }
                                else if (p1.Enemi.PointsVie <= 0)
                                {
                                    Pers.ajouterAcces(P.Access);
                                    Console.WriteLine("\n" + NOM + " has defeated the monster and received a new accessory. New status life force: " + Pers.PointsVie);
                                    Console.WriteLine("What do you want to do? Press 1 to Continue. Press 2 to Quit" + "\n");
                                    int continua;
                                    int.TryParse(Console.ReadLine(), out continua);
                                    if (continua == 1)
                                    {
                                        newRoom = true;
                                    }
                                    else if (continua == 2)
                                    {
                                        newRoom = false;
                                        choix = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Press 1 to Continue. Press 2 to Quit.");
                                    }
                                }
                            }
                            else if (room == 2)
                            {
                                Pers.PointsVie = Pers.PointsVie - 2;
                                newRoom = true;
                            }
                            else
                            {
                                Console.WriteLine("Press 1 if you want to attack. Press 2 if you want to try another room (you will loose 2 points life force).");
                            }
                        }
                        else
                        {
                            Console.WriteLine("The monster saw you and attacked.");
                            while (Pers.PointsVie >= 0 && p1.Enemi.PointsVie >= 0)
                            {
                                Console.WriteLine("\n" + "Status life force Monster: " + P.Enemi.PointsVie + "\n" + "Status life force " + NOM + " : " + Pers.PointsVie);
                                Console.WriteLine("The monster attacks");
                                if (p1.Enemi.PointsVie > 0)
                                {
                                    p1.Enemi.attack();
                                    Pers.damage();
                                }


                                Console.WriteLine("\n" + "Status life force Monster: " + P.Enemi.PointsVie + "\n" + "Status life force " + NOM + " : " + Pers.PointsVie);
                                Console.WriteLine("Your turn. What do you want to do? Press 1 to heal. Press any other key to attack.");
                                int attackheal;
                                int.TryParse(Console.ReadLine(), out attackheal);
                                if (attackheal == 1)
                                {
                                    Pers.heal();
                                }
                                else
                                {
                                    Pers.attack();
                                    p1.Enemi.damage();
                                }
                            }
                            if (p1.Enemi.PointsVie <= 0)
                            {
                                Pers.ajouterAcces(P.Access);
                                Console.WriteLine("\n" + NOM + " has defeated the monster and received a new accessory. New status life force: " + Pers.PointsVie);
                                Console.WriteLine("What do you want to do? Press 1 to Continue. Press 2 to Quit");
                                int continua;
                                int.TryParse(Console.ReadLine(), out continua);
                                if (continua == 1)
                                {
                                    newRoom = true;
                                }
                                else if (continua == 2)
                                {
                                    newRoom = false;
                                    choix = false;
                                }
                                else
                                {
                                    Console.WriteLine("Press 1 to Continue. Press 2 to Quit.");
                                }
                            }
                            else if (Pers.PointsVie <= 0)
                            {
                                Console.WriteLine("\n" + NOM + " has no points of life force left. You lost. Game over");
                                choix = false;
                            }
                        }
                    }
                    else if (P == p2)
                    {
                        Pers.ajouterAcces(P.Access);
                        Console.WriteLine("This room contains an unguardeed accessory which gives you " + p2.Access.BonusPointsVie + " life force points." + "\n" + "Status life force " + NOM + " : " + Pers.PointsVie);
                        Console.WriteLine("What do you want to do? Press 1 to continue in a new room. Press 2 to quit.");
                        int continua;
                        int.TryParse(Console.ReadLine(), out continua);
                        if (continua == 1)
                        {
                            newRoom = true;
                        }
                        else if (continua == 2)
                        {
                            choix = false;
                        }
                        else
                        {
                            Console.WriteLine("Press 1 to continue in a new room. Press 2 to quit.");
                        }
                    }
                }
            }
        }


    }
}
