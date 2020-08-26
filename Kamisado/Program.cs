using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kamisado
{
    class Program
    {
        
        public static string[] feherlepes =new string [3]; // a fehér játékos lépése(betű,x-koordináta , y koordinata)
        public static string[] feketelepes = new string[3];// a fekete játékos lépése(betű,x-koordináta , y koordinata)
        public static string lepes; // a felhasználótól bekért lépés
        public static int lepesszam = 0; //lépést számlál (lényege: ha először lépünk akkor még bekell írni a kívánt bábu színét
        public static string menupont;  // menüpontválogatás az program.cs elején
        public static string[,] koordinatak = new string[Palya.Sorokszama(), Palya.Oszlopokszama()];// lényege: hogy itt tároljuk el a bábukat
        public static bool helyeskoordinata = false;// megvizsgálja hogy üres koordinatara lépett e a felhasználó

        static bool Lepes_helyessegenek_eldontese_feher(string[,]koordinatak,string betu,string x , string y)
        {
            bool igaz_e = false;
            bool egyenes_lepes = false;
            bool atlos_lepes = false;
            for (int a = 0; a < koordinatak.GetLength(0); a++)
            {
                for (int b = 0; b < koordinatak.GetLength(1); b++)// egyenes lépés vizsgálat
                {
                    if (koordinatak[a, b] == betu + "W")
                    {
                        if (x == Convert.ToString(b) && (int.Parse(y) > a))// x csak nem változhat egyenes lépéskor y pedig csak 1 iránybaváltozhat
                        {
                            egyenes_lepes = true;
                        }
                        else
                        {
                            egyenes_lepes = false;
                        }
                       
                    }

                }
            }
            if (egyenes_lepes == false)// ha nem egyenesen lép vizsgálja az átlós lépést
            {
                for (int a = 0; a < koordinatak.GetLength(0); a++)
                {
                    for (int b = 0; b < koordinatak.GetLength(1); b++)//átlós lépés vizsgálat
                    {
                        if (koordinatak[a, b] == betu + "W")
                        {
                            int elso = Math.Abs(int.Parse(x) - b);
                            int masodik = Math.Abs(int.Parse(y) - a);

                            if ((elso == masodik) &&( int.Parse(x) < b || int.Parse(x) > b )&&(int.Parse(y)>a))//  elso és masodik abszolut értékben egyenlő akkor átlós lépésről beszélünk // x az két irányban változhat // y pedig 1 irányban változhat
                            {
                                atlos_lepes = true;
                            }
                            else
                            {
                               atlos_lepes = false;
                            }
                        }

                    }
                }
            }
            if (egyenes_lepes==true||atlos_lepes==true)// ha 1ik lépés igaz akkor jó
            {
                igaz_e = true;
            }
            else
            {
                igaz_e = false;
            }

            return igaz_e;
        }// eldönti hogy a fehér játékos milyen irányba léphet
        static bool Lepes_helyessegenek_eldontese_fekete(string[,] koordinatak, string betu, string x, string y)
        {
            bool igaz_e = false;
            bool egyenes_lepes = false;
            bool atlos_lepes = false;
            for (int a = 0; a < koordinatak.GetLength(0); a++)
            {
                for (int b = 0; b < koordinatak.GetLength(1); b++)// egyenes lépés vizsgálat
                {
                    if (koordinatak[a, b] == betu + "F")
                    {
                        if (x == Convert.ToString(b) && (int.Parse(y) < a))
                        {
                            egyenes_lepes = true;
                        }
                        else
                        {
                            egyenes_lepes = false;
                        }
                        
                    }
                    
                }
            }
            if (egyenes_lepes == false)
            {
                for (int a = 0; a < koordinatak.GetLength(0); a++)
                {
                    for (int b = 0; b < koordinatak.GetLength(1); b++)//átlós lépés vizsgálat
                    {
                        if (koordinatak[a, b] == betu + "F")
                        {
                            int elso = Math.Abs(int.Parse(x) - b);
                            int masodik = Math.Abs(int.Parse(y) - a);

                            if ((elso == masodik) && (int.Parse(x) < b || int.Parse(x) > b) && (int.Parse(y) < a))//  elso és masodik abszolut értékben egyenlő akkor átlós lépésről beszélünk // x az két irányban változhat // y pedig 1 irányban változhat
                            {
                                atlos_lepes = true;
                            }
                            else
                            {
                                atlos_lepes = false;
                            }
                        }

                    }
                }
            }
            if (egyenes_lepes == true || atlos_lepes == true)
            {
                igaz_e = true;
            }
            else
            {
                igaz_e = false;
            }

            return igaz_e;
        }// eldönti hogy a fekete játékos milyen irányba léphet
        static bool Jatekeldontese_fekete(string[,]koordinatak)
        {
            bool jatekvege = false;
            if (koordinatak[0, 0].Contains('F'))
            {
                jatekvege = true;
            }
            else if (koordinatak[0, 1].Contains('F'))
            {
                jatekvege = true;
            }
            else if (koordinatak[0, 2].Contains('F'))
            {
                jatekvege = true;
            }
            else if (koordinatak[0, 3].Contains('F'))
            {
                jatekvege = true;
            }
            else if (koordinatak[0, 4].Contains('F'))
            {
                jatekvege = true;
            }
            else if (koordinatak[0, 5].Contains('F'))
            {
                jatekvege = true;
            }
            else if (koordinatak[0, 6].Contains('F'))
            {
                jatekvege = true;
            }
            else if (koordinatak[0, 7].Contains('F'))
            {
                jatekvege = true;
            }
            return jatekvege;
        }// eldönti ,hogy a fekete játékos nyert-e
        static bool Jatekeldontese_feher(string[,] koordinatak)
        {
            bool jatekvege = false;
            
            if (koordinatak[7, 7].Contains('W'))
            {
                jatekvege = true;
            }
            else if (koordinatak[7, 6].Contains('W'))
            {
                jatekvege = true;
            }
            else if (koordinatak[7, 5].Contains('W'))
            {
                jatekvege = true;
            }
            else if (koordinatak[7, 4].Contains('W'))
            {
                jatekvege = true;
            }
            else if (koordinatak[7, 3].Contains('W'))
            {
                jatekvege = true;
            }
            else if (koordinatak[7, 2].Contains('W'))
            {
                jatekvege = true;
            }
            else if (koordinatak[7, 1].Contains('W'))
            {
                jatekvege = true;
            }
            else if (koordinatak[7, 0].Contains('W'))
            {
                jatekvege = true;
            }
            return jatekvege;
        }// eldönti ,hogy a fekete játékos nyert-e

        static void babukhelye(string[,] koordinatak)
        {
            for (int i = 0; i < koordinatak.GetLength(0); i++)
            {
                for (int j = 0; j < koordinatak.GetLength(1); j++)
                {
                        koordinatak[i, j] = "00";
                }
            }
            Jatekos1.Jatekos1Babuk();
            for (int i = 0; i < Jatekos1.Minions.Length; i++)
            {
                string hely = Jatekos1.Minions[i].Koordinata;
                string[] helyek = hely.Split(',');
                int x = int.Parse(helyek[0]);
                int y = int.Parse(helyek[1]);
                koordinatak[x, y] = Jatekos1.Minions[i].Nev;
            }
            
            Jatekos2.Jatekos2Babuk();
            for (int i = 0; i < Jatekos2.Minions.Length; i++)
            {
                string hely = Jatekos2.Minions[i].Koordinata;
                string[] helyek = hely.Split(',');
                int x = int.Parse(helyek[0]);
                int y = int.Parse(helyek[1]);
                koordinatak[x, y] = Jatekos2.Minions[i].Nev;

            }

        }// meghatározza a bábuk helyét
       
        static void Main(string[] args)
        {
            Console.Title = "Kamisado - Made by Krujz Gergely (P71JVI)";// cím
            do
            {
                //MENÜ eleje
                Console.WriteLine("Kérlek üsd be a megfelelő számot!");
                Console.WriteLine("1 - A JÁTÉK KEZDETE (ONLY MULTIPLAYER!!)");
                Console.WriteLine("2 - A JÁTÉKSZABÁLYZAT");
                Console.WriteLine("3 - KILÉPÉS");
                menupont = Console.ReadLine();
                Console.Clear();
                switch (menupont)
                {
                    case "1":
                        Console.WriteLine("JÓ JÁTÉKOT KÍVÁNUNK!");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "2":
                        Console.WriteLine("A JÁTÉK SZABÁLYAI:\n- Játékosok száma: 2\n- Ajánlott életkor: 10 éves kortól\n- A játék hossza: nem korlátozott\n \n");
                        
                        Console.WriteLine("A JÁTÉK TARTALMA:\n- 8 különböző színű mezőből álló 64 mezős játéktábla.");
                        Console.WriteLine("- Mindegyik játékosnak 8-8 különböző színű bástyája van.\n- Az a játékos győz, akinek sikerül az egyik bástyáját az ellenfél oldalának kezdősorába eljuttatni. \n- A nehézség annyi, hogy a játékos kizárólag azzal a bástyájával lépphet (csak előrefelé vagy átlósan előrefelé), amilyen színű mezőre lépett az ellenfél az előző lépésesekor. \n- A Kamisado páya színkiosztása a következő (színek: narancs (N), kék (K), lila (L), rózsaszín (R), sárga (S), piros (P), zöd (Z), barna (B)). \n- Minden játékos a saját oldalán az első sorban kezd, úgy, hogy a bástyák az azonos színu˝ mezőkre vannak letéve.");                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3":
                        Console.WriteLine("Viszlát!!");
                        
                        break;
                    default:
                        Console.WriteLine("Hiba történt ,írd be újra");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
                
            } while (!(menupont=="1" || menupont=="3"));
            //MENÜ vége

            
            babukhelye(koordinatak);//betölti a bábukat a kezdőhelyükre 
            Palya.Palyavizsgalat(); //megvizsgálya hogy a pályánk megfelelő - e, 
            Palya.Palyafeltolt();//feltölti a pályát
            
            int db = 1;// eldönti hogy ki következik
            bool helyeslepes = false; // megnézi hogy a felhasználó jól ütötte e be a kívánt adatokat

            if (menupont !="3")// ha a menüpont 3 akkor kilép
            {
                do
                {
                    db++;

                    if (db % 2 == 0)// eldönti hogy ki következik
                    {
                        do
                        {
                            Console.Clear();
                            Palya.Palyakiir();// kirajzolja a pályát
                            lepesszam++;
                            
                            do
                            {
                                Console.Clear();
                                Palya.Palyakiir();

                                if (lepesszam == 1)
                                {
                                        Console.WriteLine("A fehér játékos lép erre a mezőre:(BETŰ)--val/vel lépsz (x;y)-KOORDINÁTÁRA VESSZŐVEL ELVÁLASZTVA ! ");
                                        lepes = Console.ReadLine();
                                        string[] seged_feher = lepes.Split(',','.'); // segít szétválasztani a bekért adatokat
                                    
                                        feherlepes[0] = seged_feher[0];
                                        feherlepes[0] = feherlepes[0].ToUpper();
                                        feherlepes[2] = seged_feher[1];
                                        feherlepes[1] = seged_feher[2];

                                    Lepes_helyessegenek_eldontese_feher(koordinatak, feherlepes[0], feherlepes[2], feherlepes[1]);
                                        
                                    }
                                else // ha a lépésszám nem 1 akkor megmutatja a rendszer hogy melyik bábuval fogsz lépni
                                {
                                    Console.WriteLine("Ilyenkor már ne üsd be a kívánt betüt, mert a gép eldönti helyetted ,hogy melyikkel kell lépned");
                                    Console.WriteLine();
                                    Console.WriteLine("A fehér játékos lép erre a mezőre: {0}-val/vel lépsz (x;y)-KOORDINÁTÁRA VESSZŐVEL ELVÁLASZTVA !", feherlepes[0]);
                                   
                                    lepes = Console.ReadLine();
                                    string[] feherseged = lepes.Split(',');


                                    feherlepes[2] = feherseged[0];
                                    feherlepes[1] = feherseged[1];
                                    Lepes_helyessegenek_eldontese_feher(koordinatak, feherlepes[0], feherlepes[2], feherlepes[1]);
                                }


                                if ((feherlepes[0] == "N" || feherlepes[0] == "K" || feherlepes[0] == "L" || feherlepes[0] == "R" || feherlepes[0] == "S" || feherlepes[0] == "P" || feherlepes[0] == "Z" || feherlepes[0] == "B"))
                                {
                                    if (int.Parse(feherlepes[1]) == 0 || int.Parse(feherlepes[1]) == 1 || int.Parse(feherlepes[1]) == 2 || int.Parse(feherlepes[1]) == 3 || int.Parse(feherlepes[1]) == 4 || int.Parse(feherlepes[1]) == 5 || int.Parse(feherlepes[1]) == 6 || int.Parse(feherlepes[1]) == 7)
                                    {
                                        if (int.Parse(feherlepes[2]) == 0 || int.Parse(feherlepes[2]) == 1 || int.Parse(feherlepes[2]) == 2 || int.Parse(feherlepes[2]) == 3 || int.Parse(feherlepes[2]) == 4 || int.Parse(feherlepes[2]) == 5 || int.Parse(feherlepes[2]) == 6 || int.Parse(feherlepes[2]) == 7)
                                        {
                                            helyeslepes = true; 
                                        }
                                    }
                                }
                                if (koordinatak[int.Parse(feherlepes[1]), int.Parse(feherlepes[2])] != "00")
                                {
                                    helyeskoordinata = false;
                                }
                                else if (koordinatak[int.Parse(feherlepes[1]), int.Parse(feherlepes[2])] == "00")// megnézi hogy üres-e a koordináta amire lépni szeretnénk
                                {
                                    helyeskoordinata = true;
                                }


                                if (helyeslepes == false || Lepes_helyessegenek_eldontese_feher(koordinatak, feherlepes[0], feherlepes[2], feherlepes[1]) == false || helyeskoordinata==false)
                                {
                                    Console.WriteLine("Hiba csúszott a lépésbe próbáld újra!!"); // ha hiba van kiírja és újratölt
                                    Console.ReadLine();
                                }

                            } while (helyeslepes == false || Lepes_helyessegenek_eldontese_feher(koordinatak, feherlepes[0], feherlepes[2], feherlepes[1]) == false || helyeskoordinata == false);



                        } while (helyeslepes == false);

                        Jatekos1.Jatekos1Mozg(feherlepes); // bábu mozgatás



                        switch (Palya.map[int.Parse(feherlepes[1]), int.Parse(feherlepes[2])])// megkeresi azt hogy hova lépett az előző felhasználó ,és  amilyen színre lépett olyan bábuval kell elmozdulnia a másiknak.
                        {
                            case "N":
                                for (int a = 0; a < Palya.map.GetLength(0); a++)
                                {
                                    for (int b = 0; b < Palya.map.GetLength(1); b++)
                                    {


                                        if (koordinatak[a, b] != "00")// ha nem üres a koordináta
                                        {
                                            if (Palya.map[a, b] == "N")// ha a pálya ezen koordinátái megeggyeznek a narancssárgával
                                            {
                                                feketelepes[0] = Palya.map[a, b];// akkor az ellenfél játékosa a narancssárga bábuval lép el
                                            }

                                        }
                                    }
                                }

                                break;
                            case "K":
                                for (int a = 0; a < Palya.map.GetLength(0); a++)
                                {
                                    for (int b = 0; b < Palya.map.GetLength(1); b++)
                                    {

                                        if (koordinatak[a, b] != "00")
                                        {
                                            if (Palya.map[a, b] == "K")
                                            {
                                                feketelepes[0] = Palya.map[a, b];
                                            }

                                        }
                                        
                                    }
                                }
                                break;
                            case "L":
                                for (int a = 0; a < Palya.map.GetLength(0); a++)
                                {
                                    for (int b = 0; b < Palya.map.GetLength(1); b++)
                                    {
                                        if (koordinatak[a, b] != "00")
                                        {
                                            if (Palya.map[a, b] == "L")
                                            {
                                                feketelepes[0] = Palya.map[a, b];
                                            }

                                        }
                                    }
                                }
                                break;
                            case "R":
                                for (int a = 0; a < Palya.map.GetLength(0); a++)
                                {
                                    for (int b = 0; b < Palya.map.GetLength(1); b++)
                                    {
                                        if (koordinatak[a, b] != "00")
                                        {
                                            if (Palya.map[a, b] == "R")
                                            {
                                                feketelepes[0] = Palya.map[a, b];
                                            }

                                        }
                                    }
                                }
                                break;
                            case "S":
                                for (int a = 0; a < Palya.map.GetLength(0); a++)
                                {
                                    for (int b = 0; b < Palya.map.GetLength(1); b++)
                                    {
                                        if (koordinatak[a, b] != "00")
                                        {
                                            if (Palya.map[a, b] == "S")
                                            {
                                                feketelepes[0] = Palya.map[a, b];
                                            }

                                        }

                                    }
                                }
                                break;
                            case "P":
                                for (int a = 0; a < Palya.map.GetLength(0); a++)
                                {
                                    for (int b = 0; b < Palya.map.GetLength(1); b++)
                                    {
                                        if (koordinatak[a, b] != "00")
                                        {
                                            if (Palya.map[a, b] == "P")
                                            {
                                                feketelepes[0] = Palya.map[a, b];
                                            }

                                        }
                                    }
                                }
                                break;
                            case "Z":
                                for (int a = 0; a < Palya.map.GetLength(0); a++)
                                {
                                    for (int b = 0; b < Palya.map.GetLength(1); b++)
                                    {
                                        if (koordinatak[a, b] != "00")
                                        {
                                            if (Palya.map[a, b] == "Z")
                                            {
                                                feketelepes[0] = Palya.map[a, b];
                                            }

                                        }

                                    }
                                }
                                break;
                            case "B":
                                for (int a = 0; a < Palya.map.GetLength(0); a++)
                                {
                                    for (int b = 0; b < Palya.map.GetLength(1); b++)
                                    {
                                        if (koordinatak[a, b] != "00")
                                        {
                                            if (Palya.map[a, b] == "B")
                                            {
                                                feketelepes[0] = Palya.map[a, b];
                                            }

                                        }
                                    }

                                }

                                break;
                        }


                    }
                    else
                    {
                        do
                        {
                            
                            do
                            {
                                helyeskoordinata = false;// alapértékre állít
                                helyeslepes = false;// alapértékre állít
                                Console.Clear();
                                Palya.Palyakiir();
                                Console.WriteLine("Ilyenkor már ne üsd be a kívánt betüt, mert a gép eldönti helyetted ,hogy melyikkel kell lépned");
                                Console.WriteLine();
                                Console.WriteLine("A fekete játékos lép erre a mezőre: {0}-val/vel lépsz (x;y)-KOORDINÁTÁRA  VESSZŐVEL ELVÁLASZTVA !", feketelepes[0]);
                                
                                lepes = Console.ReadLine(); // bekérés
                                string[] seged_fekete = lepes.Split(',','.');//  szétválogatás
                                
                                feketelepes[2] = seged_fekete[0];
                                feketelepes[1] = seged_fekete[1];
                                Lepes_helyessegenek_eldontese_fekete(koordinatak, feketelepes[0], feketelepes[2], feketelepes[1]);// milyen irányban léphetünk?

                                if ((feketelepes[0] == "N" || feketelepes[0] == "K" || feketelepes[0] == "L" || feketelepes[0] == "R" || feketelepes[0] == "S" || feketelepes[0] == "P" || feketelepes[0] == "Z" || feketelepes[0] == "B"))
                                {
                                    if (int.Parse(feketelepes[1]) == 0 || int.Parse(feketelepes[1]) == 1 || int.Parse(feketelepes[1]) == 2 || int.Parse(feketelepes[1]) == 3 || int.Parse(feketelepes[1]) == 4 || int.Parse(feketelepes[1]) == 5 || int.Parse(feketelepes[1]) == 6 || int.Parse(feketelepes[1]) == 7)
                                    {
                                        if (int.Parse(feketelepes[2]) == 0 || int.Parse(feketelepes[2]) == 1 || int.Parse(feketelepes[2]) == 2 || int.Parse(feketelepes[2]) == 3 || int.Parse(feketelepes[2]) == 4 || int.Parse(feketelepes[2]) == 5 || int.Parse(feketelepes[2]) == 6 || int.Parse(feketelepes[2]) == 7)
                                        {
                                            helyeslepes = true;
                                        }
                                    }
                                }

                                if (koordinatak[int.Parse(feketelepes[1]), int.Parse(feketelepes[2])] != "00")
                                {
                                    helyeskoordinata = false;
                                }
                                else if (koordinatak[int.Parse(feketelepes[1]), int.Parse(feketelepes[2])] == "00")
                                {
                                    helyeskoordinata = true;
                                }

                                if (helyeslepes == false || helyeskoordinata==false || Lepes_helyessegenek_eldontese_fekete(koordinatak, feketelepes[0], feketelepes[2], feketelepes[1]) == false)
                                {
                                    Console.WriteLine("Hiba csúszott a lépésbe próbáld újra!!");
                                    Console.ReadLine();
                                }

                            } while (helyeslepes == false|| Lepes_helyessegenek_eldontese_fekete(koordinatak, feketelepes[0], feketelepes[2], feketelepes[1])==false || helyeskoordinata== false);
                            
                            lepesszam++;
                            
                        } while (helyeslepes == false);
                        Jatekos2.Jatekos2Mozg(feketelepes);
                        switch (Palya.map[int.Parse(feketelepes[1]), int.Parse(feketelepes[2])])
                        {
                            case "N":
                                for (int a = 0; a < Palya.map.GetLength(0); a++)
                                {
                                    for (int b = 0; b < Palya.map.GetLength(1); b++)
                                    {
                                        if (koordinatak[a, b] != "00")
                                        {
                                            if (Palya.map[a, b] == "N")
                                            {
                                                feherlepes[0] = Palya.map[a, b];
                                            }

                                        }
                                    }
                                }

                                break;
                            case "K":
                                for (int a = 0; a < Palya.map.GetLength(0); a++)
                                {
                                    for (int b = 0; b < Palya.map.GetLength(1); b++)
                                    {
                                        if (koordinatak[a, b] != "00")
                                        {
                                            if (Palya.map[a, b] == "K")
                                            {
                                                feherlepes[0] = Palya.map[a, b];
                                            }

                                        }
                                    }
                                }
                                break;
                            case "L":
                                for (int a = 0; a < Palya.map.GetLength(0); a++)
                                {
                                    for (int b = 0; b < Palya.map.GetLength(1); b++)
                                    {
                                        if (koordinatak[a, b] != "00")
                                        {
                                            if (Palya.map[a, b] == "L")
                                            {
                                                feherlepes[0] = Palya.map[a, b];
                                            }

                                        }
                                    }
                                }
                                break;
                            case "R":
                                for (int a = 0; a < Palya.map.GetLength(0); a++)
                                {
                                    for (int b = 0; b < Palya.map.GetLength(1); b++)
                                    {
                                        if (koordinatak[a, b] != "00")
                                        {
                                            if (Palya.map[a, b] == "R")
                                            {
                                                feherlepes[0] = Palya.map[a, b];
                                            }

                                        }
                                    }
                                }
                                break;
                            case "S":
                                for (int a = 0; a < Palya.map.GetLength(0); a++)
                                {
                                    for (int b = 0; b < Palya.map.GetLength(1); b++)
                                    {
                                        if (koordinatak[a, b] != "00")
                                        {
                                            if (Palya.map[a, b] == "S")
                                            {
                                                feherlepes[0] = Palya.map[a, b];
                                            }

                                        }

                                    }
                                }
                                break;
                            case "P":
                                for (int a = 0; a < Palya.map.GetLength(0); a++)
                                {
                                    for (int b = 0; b < Palya.map.GetLength(1); b++)
                                    {
                                        if (koordinatak[a, b] != "00")
                                        {
                                            if (Palya.map[a, b] == "P")
                                            {
                                                feherlepes[0] = Palya.map[a, b];
                                            }

                                        }
                                    }
                                }
                                break;
                            case "Z":
                                for (int a = 0; a < Palya.map.GetLength(0); a++)
                                {
                                    for (int b = 0; b < Palya.map.GetLength(1); b++)
                                    {
                                        if (koordinatak[a, b] != "00")
                                        {
                                            if (Palya.map[a, b] == "Z")
                                            {
                                                feherlepes[0] = Palya.map[a, b];
                                            }

                                        }

                                    }
                                }
                                break;
                            case "B":
                                for (int a = 0; a < Palya.map.GetLength(0); a++)
                                {
                                    for (int b = 0; b < Palya.map.GetLength(1); b++)
                                    {
                                        if (koordinatak[a, b] != "00")
                                        {
                                            if (Palya.map[a, b] == "B")
                                            {
                                                feherlepes[0] = Palya.map[a, b];
                                            }

                                        }
                                    }

                                }

                                break;
                        }

                    }


                }
                while (Jatekeldontese_feher(koordinatak) == false && Jatekeldontese_fekete(koordinatak)==false);

                if (Jatekeldontese_feher(koordinatak) == true)// ha a feher győzött 
                {
                    Console.Clear();
                    Palya.Palyakiir();
                    Console.WriteLine("A GYŐZTES A FEHÉR JÁTÉKOS !! ");
                    Console.ReadKey();
                }
                else if (Jatekeldontese_fekete(koordinatak) == true)// ha a feher győzött 
                {
                    Console.Clear();
                    Palya.Palyakiir();
                    Console.WriteLine("A GYŐZTES A FEKETE JÁTÉKOS !! ");
                    Console.ReadKey();
                }

                Console.Clear();
                Console.WriteLine("KÖSZÖNJÜK,HOGY MINKET VÁLASZTOTT!!");
                Console.ReadKey();
            }
            else if (menupont=="3")// 3. menüpont kilépés
            {
                Console.ReadKey();
            }
            
        }
    }
}
