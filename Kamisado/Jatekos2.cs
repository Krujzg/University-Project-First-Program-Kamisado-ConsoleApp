using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kamisado
{
    class Jatekos2
    {
        public static void Jatekos2Babuk()
        {
            // bábuk                 játékos         koordináták
            Minions[7] = new Babuk("NF", "Jatekos2", "7,7");
            Minions[6] = new Babuk("KF", "Jatekos2", "7,6");
            Minions[5] = new Babuk("LF", "Jatekos2", "7,5");
            Minions[4] = new Babuk("RF", "Jatekos2", "7,4");
            Minions[3] = new Babuk("SF", "Jatekos2", "7,3");
            Minions[2] = new Babuk("PF", "Jatekos2", "7,2");
            Minions[1] = new Babuk("ZF", "Jatekos2", "7,1");
            Minions[0] = new Babuk("BF", "Jatekos2", "7,0");


        }
        private static Babuk[] minions = new Babuk[8];// bábuktömb megadása

        public static Babuk[] Minions
        {
            get
            {
                return minions;
            }

            set
            {
                minions = value;
            }
        }
        public static void Jatekos2Mozg(string[] feketelepes)// bábuk mozgása
        {
            
           
            {
                if (feketelepes[0] == "N")// ha a bekért szín == N (narancssárga)
                {
                    string hely = Minions[7].Koordinata;// felveszünk 1 string változot és belerakjuk a bábukoordinatait
                    string[] helyek = hely.Split(',');
                    int x = int.Parse(helyek[0]);
                    int y = int.Parse(helyek[1]);
                    Program.koordinatak[x, y] = "00";
                    Program.koordinatak[int.Parse(feketelepes[1]), int.Parse(feketelepes[2])] = "NF";// ahova lépett a játékos ,ott a narancssárga-- N-- a koordináták tömbben NW vagyis narancssárga Fehérjátékos lesz

                    Minions[7].Koordinata = feketelepes[1] + "," + feketelepes[2];// koordináta változtatás



                }
                else if (feketelepes[0] == "K")
                {
                    string hely = Minions[6].Koordinata;
                    string[] helyek = hely.Split(',');
                    int x = int.Parse(helyek[0]);
                    int y = int.Parse(helyek[1]);
                    Program.koordinatak[x, y] = "00";
                    Program.koordinatak[int.Parse(feketelepes[1]), int.Parse(feketelepes[2])] = "KF";

                    Minions[6].Koordinata = feketelepes[1] + "," + feketelepes[2];
                }

                else if (feketelepes[0] == "L")
                {
                    string hely = Minions[5].Koordinata;
                    string[] helyek = hely.Split(',');
                    int x = int.Parse(helyek[0]);
                    int y = int.Parse(helyek[1]);
                    Program.koordinatak[x, y] = "00";
                    Program.koordinatak[int.Parse(feketelepes[1]), int.Parse(feketelepes[2])] = "LF";

                    Minions[5].Koordinata = feketelepes[1] + "," + feketelepes[2];
                }

                else if (feketelepes[0] == "R")
                {
                    string hely = Minions[4].Koordinata;
                    string[] helyek = hely.Split(',');
                    int x = int.Parse(helyek[0]);
                    int y = int.Parse(helyek[1]);
                    Program.koordinatak[x, y] = "00";
                    Program.koordinatak[int.Parse(feketelepes[1]), int.Parse(feketelepes[2])] = "RF";

                    Minions[4].Koordinata = feketelepes[1] + "," + feketelepes[2];
                }

                else if (feketelepes[0] == "S")
                {
                    string hely = Minions[3].Koordinata;
                    string[] helyek = hely.Split(',');
                    int x = int.Parse(helyek[0]);
                    int y = int.Parse(helyek[1]);
                    Program.koordinatak[x, y] = "00";
                    Program.koordinatak[int.Parse(feketelepes[1]), int.Parse(feketelepes[2])] = "SF";

                    Minions[3].Koordinata = feketelepes[1] + "," + feketelepes[2];
                }
                else if (feketelepes[0] == "P")
                {
                    string hely = Minions[2].Koordinata;
                    string[] helyek = hely.Split(',');
                    int x = int.Parse(helyek[0]);
                    int y = int.Parse(helyek[1]);
                    Program.koordinatak[x, y] = "00";
                    Program.koordinatak[int.Parse(feketelepes[1]), int.Parse(feketelepes[2])] = "PF";

                    Minions[2].Koordinata = feketelepes[1] + "," + feketelepes[2];
                }
                else if (feketelepes[0] == "Z")
                {
                    string hely = Minions[1].Koordinata;
                    string[] helyek = hely.Split(',');
                    int x = int.Parse(helyek[0]);
                    int y = int.Parse(helyek[1]);
                    Program.koordinatak[x, y] = "00";
                    Program.koordinatak[int.Parse(feketelepes[1]), int.Parse(feketelepes[2])] = "ZF";

                    Minions[1].Koordinata = feketelepes[1] + "," + feketelepes[2];
                }
                else if (feketelepes[0] == "B")
                {
                    string hely = Minions[0].Koordinata;
                    string[] helyek = hely.Split(',');
                    int x = int.Parse(helyek[0]);
                    int y = int.Parse(helyek[1]);
                    Program.koordinatak[x, y] = "00";
                    Program.koordinatak[int.Parse(feketelepes[1]), int.Parse(feketelepes[2])] = "BF";

                    Minions[0].Koordinata = feketelepes[1] + "," + feketelepes[2];
                }

            }

            
        }
    }
}
