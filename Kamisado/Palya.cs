using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kamisado
{
    class Palya
    {
        static StreamReader sr = new StreamReader("szoveg.txt"); // szövegbeolvasás

        public static int Sorokszama()// sorok számának a megszámolása
        {
            int dbsor = 0;
            sr = new StreamReader("szoveg.txt");

            while (!sr.EndOfStream)
            {
                sr.ReadLine();
                dbsor++;

            }
            sr.Close();

            return dbsor;
        }

        public static int Oszlopokszama()// oszlopszám megszámolása
        {
            sr = new StreamReader("szoveg.txt");
            int sumkar = 0;
            while (!sr.EndOfStream)
            {
                if (sr.Read() != ' ')
                {
                    sumkar++;
                }
            }
            sumkar = sumkar - ((Sorokszama() - 1) * 2);

            sr.Close();
            return sumkar / Sorokszama();
        }

        public static string[,] map = new string[Sorokszama(), Oszlopokszama()];// pálya tömb létrehozása 

        public static string[,] Map
        {
            get
            {
                return map;
            }

            //set
            //{
            //    map = value;
            //}
        }

        public static bool Palyavizsgalat()// megvizsgálja hogy a pálya nem hibás e
        {



            if (Oszlopokszama() * Sorokszama() != 64)
            {
                Console.WriteLine("Hibás a fájl tartalma!!!");
                return false;
            }
            else return true;

        }

        public static void Palyafeltolt()// betöltjük a fálj tartalmát a pályába
        {
            if (Palyavizsgalat())
            {
                sr = new StreamReader("szoveg.txt");

                int i = 0;
                while (!sr.EndOfStream)
                {
                    string sor = sr.ReadLine();

                    string[] oszlop = sor.Split(' ');
                    for (int j = 0; j < oszlop.Length; j++)
                    {
                        map[i, j] = oszlop[j];

                    }

                    i++;

                }
                sr.Close();
            }


        }

        public static void Palyakiir()// kiiratjuk a pályát
        {
            for (int i = 0; i < Oszlopokszama(); i++)
            {
                Console.Write("    " + i + "   ");
            }
            Console.WriteLine();
            for (int i = 0; i < Sorokszama(); i++)
            {
                for (int k = 0; k < 3; k++)// szükséges a vonalak kirajzolásához
                {
                    for (int j = 0; j < Oszlopokszama(); j++)
                    {

                        if (map[i, j] == "N")// ha narancssárga ezen a helyen (map[i,j])akkor a háttér dark.yellow 
                        {
                            if (k != 1)
                            {
                                Console.Write("|");
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                                Console.Write("\t");
                                Console.ResetColor();
                            }
                            else
                            {
                                string babu = Program.koordinatak[i, j];
                                if (babu[1] == 'W')
                                {
                                    Console.Write("|");//elválasztóvonal
                                    Console.BackgroundColor = ConsoleColor.DarkYellow;// háttérszín
                                    Console.ForegroundColor = ConsoleColor.White;// fehér játékos
                                    string ertek = Program.koordinatak[i, j].TrimEnd('W'); // a fehér bábu a kirajzolásnál elveszti a W-t
                                    Console.Write("   " + ertek + "   ");
                                    Console.ResetColor();
                                }
                                else if (babu[1]=='F')
                                {
                                    Console.Write("|");
                                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    string ertek = Program.koordinatak[i, j].TrimEnd('F');// a fekete bábu a kirajzolásnál elveszti a F-t
                                    Console.Write("   " + ertek + "   ");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.Write("|");
                                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("\t");
                                    Console.ResetColor();
                                }
                            }
                        }
                        if (map[i, j] == "K")
                        {
                            if (k != 1)
                            {
                                Console.Write("|");
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.Write("\t");
                                Console.ResetColor();
                            }
                            else
                            {
                                string babu = Program.koordinatak[i, j];
                                if (babu[1] == 'W')
                                {
                                    Console.Write("|");
                                    Console.BackgroundColor = ConsoleColor.Blue;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    string ertek = Program.koordinatak[i, j].TrimEnd('W');
                                    Console.Write("   " + ertek + "   ");
                                    Console.ResetColor();
                                }
                                else if (babu[1] == 'F')
                                {
                                    Console.Write("|");
                                    Console.BackgroundColor = ConsoleColor.Blue;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    string ertek = Program.koordinatak[i, j].TrimEnd('F');
                                    Console.Write("   " + ertek + "   ");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.Write("|");
                                    Console.BackgroundColor = ConsoleColor.Blue;
                                    Console.Write("\t");
                                    Console.ResetColor();
                                }
                            }
                        }
                        if (map[i, j] == "L")
                        {
                            if (k != 1)
                            {
                                Console.Write("|");
                                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                                Console.Write("\t");
                                Console.ResetColor();
                            }
                            else
                            {
                                string babu = Program.koordinatak[i, j];
                                if (babu[1] == 'W')
                                {
                                    Console.Write("|");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                                    string ertek = Program.koordinatak[i, j].TrimEnd('W');
                                    Console.Write("   " +ertek + "   ");
                                    Console.ResetColor();
                                }
                                else if (babu[1] == 'F')
                                {
                                    Console.Write("|");
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                                    string ertek = Program.koordinatak[i, j].TrimEnd('F');
                                    Console.Write("   " + ertek + "   ");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.Write("|");
                                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                                    Console.Write("\t");
                                    Console.ResetColor();
                                }
                            }
                        }
                        if (map[i, j] == "R")
                        {
                            if (k != 1)
                            {
                                Console.Write("|");
                                Console.BackgroundColor = ConsoleColor.Magenta;
                                Console.Write("\t");
                                Console.ResetColor();
                            }
                            else
                            {
                                string babu = Program.koordinatak[i, j];
                                if (babu[1] == 'W')
                                {
                                    Console.Write("|");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.BackgroundColor = ConsoleColor.Magenta;
                                    string ertek = Program.koordinatak[i, j].TrimEnd('W');
                                    Console.Write("   " + ertek + "   ");
                                    Console.ResetColor();
                                }
                                else if (babu[1] == 'F')
                                {
                                    Console.Write("|");
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.BackgroundColor = ConsoleColor.Magenta;
                                    string ertek = Program.koordinatak[i, j].TrimEnd('F');
                                    Console.Write("   " + ertek + "   ");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.Write("|");
                                    Console.BackgroundColor = ConsoleColor.Magenta;
                                    Console.Write("\t");
                                    Console.ResetColor();
                                }
                            }
                        }
                        if (map[i, j] == "S")
                        {
                            if (k != 1)
                            {
                                Console.Write("|");
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                Console.Write("\t");
                                Console.ResetColor();
                            }
                            else
                            {
                                string babu = Program.koordinatak[i, j];
                                if (babu[1] == 'W')
                                {
                                    Console.Write("|");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.BackgroundColor = ConsoleColor.Yellow;
                                    string ertek = Program.koordinatak[i, j].TrimEnd('W');
                                    Console.Write("   " + ertek + "   ");
                                    Console.ResetColor();
                                }
                                else if (babu[1] == 'F')
                                {
                                    Console.Write("|");
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.BackgroundColor = ConsoleColor.Yellow;
                                    string ertek = Program.koordinatak[i, j].TrimEnd('F');
                                    Console.Write("   " + ertek + "   ");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.Write("|");
                                    Console.BackgroundColor = ConsoleColor.Yellow;
                                    Console.Write("\t");
                                    Console.ResetColor();
                                }
                            }
                        }
                        if (map[i, j] == "P")
                        {
                            if (k != 1)
                            {
                                Console.Write("|");
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write("\t");
                                Console.ResetColor();
                            }
                            else
                            {
                                string babu = Program.koordinatak[i, j];
                                if (babu[1] == 'W')
                                {
                                    Console.Write("|");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    string ertek = Program.koordinatak[i, j].TrimEnd('W');
                                    Console.Write("   " + ertek + "   ");
                                    Console.ResetColor();
                                }
                                else if (babu[1] == 'F')
                                {
                                    Console.Write("|");
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    string ertek = Program.koordinatak[i, j].TrimEnd('F');
                                    Console.Write("   " + ertek + "   ");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.Write("|");
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.Write("\t");
                                    Console.ResetColor();
                                }
                            }
                        }
                        if (map[i, j] == "Z")
                        {
                            if (k != 1)
                            {
                                Console.Write("|");
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write("\t");
                                Console.ResetColor();
                            }
                            else
                            {
                                string babu = Program.koordinatak[i, j];
                                if (babu[1] == 'W')
                                {
                                    Console.Write("|");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.BackgroundColor = ConsoleColor.Green;
                                    string ertek = Program.koordinatak[i, j].TrimEnd('W');
                                    Console.Write("   " + ertek + "   ");
                                    Console.ResetColor();
                                }
                                else if (babu[1] == 'F')
                                {
                                    Console.Write("|");
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.BackgroundColor = ConsoleColor.Green;
                                    string ertek = Program.koordinatak[i, j].TrimEnd('F');
                                    Console.Write("   " + ertek + "   ");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.Write("|");
                                    Console.BackgroundColor = ConsoleColor.Green;
                                    Console.Write("\t");
                                    Console.ResetColor();
                                }
                            }
                        }
                        if (map[i, j] == "B")
                        {
                            if (k != 1)
                            {
                                Console.Write("|");
                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                Console.Write("\t");
                                Console.ResetColor();
                            }
                            else
                            {
                                string babu = Program.koordinatak[i, j];
                                if (babu[1] == 'W')
                                {
                                    Console.Write("|");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.BackgroundColor = ConsoleColor.DarkGray;
                                    string ertek = Program.koordinatak[i, j].TrimEnd('W');
                                    Console.Write("   " + ertek + "   ");
                                    Console.ResetColor();
                                }
                                else if (babu[1] == 'F')
                                {
                                    Console.Write("|");
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.BackgroundColor = ConsoleColor.DarkGray;
                                    string ertek = Program.koordinatak[i, j].TrimEnd('F');
                                    Console.Write("   " + (ertek/*+'B'*/) + "   ");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.Write("|");
                                    Console.BackgroundColor = ConsoleColor.DarkGray;
                                    Console.Write("\t");
                                    Console.ResetColor();
                                }
                            }
                        }




                    }
                                                    
                        if (k == 1)
                        {

                            Console.Write("|"+i);
                        }
                        else
                        {
                            Console.Write("|");
                        }
                        
                        Console.WriteLine();

                    }
                }
            }


        }
    }

