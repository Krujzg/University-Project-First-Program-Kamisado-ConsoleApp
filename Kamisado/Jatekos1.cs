using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kamisado
{
    class Jatekos1
    {

        public static void Jatekos1Babuk()
        {
            // bábuk                 játékos         koordináták
            Minions[0] = new Babuk("NW", "Jatekos1", "0,0");
            Minions[1] = new Babuk("KW", "Jatekos1", "0,1");
            Minions[2] = new Babuk("LW", "Jatekos1", "0,2");
            Minions[3] = new Babuk("RW", "Jatekos1", "0,3");
            Minions[4] = new Babuk("SW", "Jatekos1", "0,4");
            Minions[5] = new Babuk("PW", "Jatekos1", "0,5");
            Minions[6] = new Babuk("ZW", "Jatekos1", "0,6");
            Minions[7] = new Babuk("BW", "Jatekos1", "0,7");
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
        public static void Jatekos1Mozg(string[] feherlepes)// bábuk mozgása
        {
            

            
                if (feherlepes[0] == "N")// ha a bekért szín == N (narancssárga)
                {

                    string hely = Minions[0].Koordinata;// felveszünk 1 string változot és belerakjuk a bábukoordinatait
                    string[] helyek = hely.Split(',');
                    int x = int.Parse(helyek[0]);
                    int y = int.Parse(helyek[1]);
                    Program.koordinatak[x, y] = "00"; // üres hely
                    Program.koordinatak[int.Parse(feherlepes[1]), int.Parse(feherlepes[2])] = "NW";// ahova lépett a játékos ,ott a narancssárga-- N-- a koordináták tömbben NW vagyis narancssárga Fehérjátékos lesz

                    Minions[0].Koordinata = feherlepes[1] + "," + feherlepes[2];// koordináta változtatás

                    



                }
                else if (feherlepes[0] == "K")
                {
                    string hely = Minions[1].Koordinata;
                    string[] helyek = hely.Split(',');
                    int x = int.Parse(helyek[0]);
                    int y = int.Parse(helyek[1]);
                    Program.koordinatak[x, y] = "00";
                    Program.koordinatak[int.Parse(feherlepes[1]), int.Parse(feherlepes[2])] = "KW";

                    Minions[1].Koordinata = feherlepes[1] + "," + feherlepes[2];
                }

                else if (feherlepes[0] == "L")
                {
                    string hely = Minions[2].Koordinata;
                    string[] helyek = hely.Split(',');
                    int x = int.Parse(helyek[0]);
                    int y = int.Parse(helyek[1]);
                    Program.koordinatak[x, y] = "00";
                    Program.koordinatak[int.Parse(feherlepes[1]), int.Parse(feherlepes[2])] = "LW";

                    Minions[2].Koordinata = feherlepes[1] + "," + feherlepes[2];
                }

                else if (feherlepes[0] == "R")
                {
                    string hely = Minions[3].Koordinata;
                    string[] helyek = hely.Split(',');
                    int x = int.Parse(helyek[0]);
                    int y = int.Parse(helyek[1]);
                    Program.koordinatak[x, y] = "00";
                    Program.koordinatak[int.Parse(feherlepes[1]), int.Parse(feherlepes[2])] = "RW";

                    Minions[3].Koordinata = feherlepes[1] + "," + feherlepes[2];
                }

                else if (feherlepes[0] == "S")
                {
                    string hely = Minions[4].Koordinata;
                    string[] helyek = hely.Split(',');
                    int x = int.Parse(helyek[0]);
                    int y = int.Parse(helyek[1]);
                    Program.koordinatak[x, y] = "00";
                    Program.koordinatak[int.Parse(feherlepes[1]), int.Parse(feherlepes[2])] = "SW";

                    Minions[4].Koordinata = feherlepes[1] + "," + feherlepes[2];
                }
                else if (feherlepes[0] == "P")
                {
                    string hely = Minions[5].Koordinata;
                    string[] helyek = hely.Split(',');
                    int x = int.Parse(helyek[0]);
                    int y = int.Parse(helyek[1]);
                    Program.koordinatak[x, y] = "00";
                    Program.koordinatak[int.Parse(feherlepes[1]), int.Parse(feherlepes[2])] = "PW";

                    Minions[5].Koordinata = feherlepes[1] + "," + feherlepes[2];
                }
                else if (feherlepes[0] == "Z")
                {
                    string hely = Minions[6].Koordinata;
                    string[] helyek = hely.Split(',');
                    int x = int.Parse(helyek[0]);
                    int y = int.Parse(helyek[1]);
                    Program.koordinatak[x, y] = "00";
                    Program.koordinatak[int.Parse(feherlepes[1]), int.Parse(feherlepes[2])] = "ZW";

                    Minions[6].Koordinata = feherlepes[1] + "," + feherlepes[2];
                }
                else if (feherlepes[0] == "B")
                {
                    string hely = Minions[7].Koordinata;
                    string[] helyek = hely.Split(',');
                    int x = int.Parse(helyek[0]);
                    int y = int.Parse(helyek[1]);
                    Program.koordinatak[x, y] = "00";
                    Program.koordinatak[int.Parse(feherlepes[1]), int.Parse(feherlepes[2])] = "BW";

                    Minions[7].Koordinata = feherlepes[1] + "," + feherlepes[2];
                }
            }
            
               
                
            }
        

            

        }



    

