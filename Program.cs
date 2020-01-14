using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZI1
{
    class Program
    {
        public static bool[,] BlokowaneKWS = new bool[8, 8];
        public static bool[,] Hetman = new bool[8, 8];    
        public static string[] ZbiórStringów = new string[96];
        public static int zliczaj=0;
        public static string zapisuj = "";
        public static bool skocz = false;
        

        static void Main(string[] args)
        {
            List<string> liczby1 = new List<string>();
            List<string> pomocn1 = new List<string>();

            do
            {
                Console.WriteLine("Które zadanie?");
                string sWybór = Console.ReadLine();

                switch (sWybór)
                {
                    case "1":

                        /////////// ZADANIE 1 ///////////

                        Console.WriteLine("Podaj N:");
                        int n = Convert.ToInt32(Console.ReadLine()) - 1;

                        liczby1.Add("1");

                        for (int i = 0; i < n; i++)
                        {
                            for (int k = 0; k < Silnia(i + 1); k++)
                            {
                                for (int j = 0; j < liczby1[k].Length + 1; j++)
                                {
                                    pomocn1.Add(liczby1[k].Insert(j, (i + 2).ToString()));

                                }
                            }

                            liczby1 = new List<string>(pomocn1);
                            pomocn1.Clear();
                        }

                        foreach (string str in liczby1)
                        {
                            Console.WriteLine(str);
                        }

                        Console.WriteLine("Kliknij ENTER, żeby wyczyścić konsolę i powrócić do wyboru.....");

                        sWybór = "";

                        liczby1.Clear();

                        Console.ReadKey();

                        Console.Clear();

                        break;

                    case "2":

                        /////////// ZADANIE 2 ///////////                        

                        liczby1 = new List<string>();
                        pomocn1 = new List<string>();

                        Console.WriteLine("Podaj N:");
                        int n2 = Convert.ToInt32(Console.ReadLine()) - 1;

                        liczby1.Add("1");

                        for (int i = 0; i < n2; i++)
                        {
                            for (int k = 0; k < Silnia(i + 1); k++)
                            {
                                for (int j = 0; j < liczby1[k].Length + 1; j++)
                                {
                                    pomocn1.Add(liczby1[k].Insert(j, (i + 2).ToString()));

                                }
                            }

                            liczby1 = new List<string>(pomocn1);
                            pomocn1.Clear();
                        }

                        //foreach (string str in liczby1)
                        //{
                        //    Console.WriteLine(str);
                        //}

                        int wiersz = 0;
                        char[] pomocChar = new char[8];
                        string[] pomocString = new string[8];
                        int[] pocięteLiczby = new int[8];
                        int która = 0;
                        string ciąg = "";
                        int lącznie = 0;

                        Console.WriteLine("Ile łącznie liczb w tablicy: " + liczby1.Count());

                        for (int i = 0; i < liczby1.Count(); i++)
                        {
                            która = i + 1;
                            for (int j = 0; j < n2; j++)
                            {
                                pomocChar = (liczby1[i]).ToCharArray();
                                pomocString[j] = pomocChar[j].ToString();
                                pocięteLiczby[j] = Convert.ToInt32(pomocString[j]);
                                wiersz = pocięteLiczby[j] - 1;

                                ciąg += pomocChar[j].ToString();

                                Hetman = ZablokujHetman(wiersz, j, BlokowaneKWS, Hetman);
                                if (skocz == false)
                                {
                                    BlokowaneKWS = ZablokujKWS(BlokowaneKWS, Hetman, wiersz, j);
                                }
                                if (skocz == true)
                                {
                                    for (int kol = 0; kol < 8; kol++)
                                    {
                                        for (int wie = 0; wie < 8; wie++)
                                        {
                                            Hetman[kol, wie] = false;
                                            BlokowaneKWS[kol, wie] = false;
                                        }
                                    }

                                    ciąg = "";

                                    zliczaj = 0;
                                    break;
                                }


                                if ((j == 7) && (zliczaj < 8))
                                {
                                    for (int kol = 0; kol < 8; kol++)
                                    {
                                        for (int wie = 0; wie < 8; wie++)
                                        {
                                            Hetman[kol, wie] = false;
                                            BlokowaneKWS[kol, wie] = false;

                                        }
                                    }

                                    ciąg = "";

                                    zliczaj = 0;
                                }

                                if (zliczaj == 8)
                                {

                                    for (int v = 0; v < 8; v++)
                                    {
                                        if (((ciąg[v] - ciąg[v + 1]) == 1) || ((ciąg[v] - ciąg[v + 1]) == -1))
                                        {
                                            goto NieRóbNic;
                                        }
                                    }

                                    Console.WriteLine("");
                                    Console.WriteLine("Ciąg: " + ciąg + " która w tablicy: " + która + " Numer rozwiązania: " + ++lącznie);
                                    Console.WriteLine("");
                                    Wypisz();

                                    NieRóbNic:

                                    for (int kol = 0; kol < 8; kol++)
                                    {
                                        for (int wie = 0; wie < 8; wie++)
                                        {
                                            Hetman[kol, wie] = false;
                                            BlokowaneKWS[kol, wie] = false;
                                        }
                                    }

                                    ciąg = "";

                                    zliczaj = 0;
                                }

                                
                            }


                        }

                        Console.WriteLine("Kliknij ENTER, żeby wyczyścić konsolę i powrócić do wyboru.....");

                        liczby1.Clear();
                        sWybór = "0";

                        Console.ReadKey();

                        Console.Clear();

                        break;

                    default:
                        {
                            Console.WriteLine("Wpisz 1 lub 2 !");

                            sWybór = "0";

                            Console.ReadKey();

                            break;
                        }
                }
            } while (true);

           

        }

        public static void Wypisz()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(Hetman[i, j] + " ");
                    if (Hetman[i, j] == true)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine(" ");
            }

            Console.WriteLine(" ");

            //for (int i = 0; i < 8; i++)
            //{
            //    for (int j = 0; j < 8; j++)
            //    {
            //        Console.Write(BlokowaneKWS[i, j] + " ");
            //        if (BlokowaneKWS[i, j] == true)
            //        {
            //            Console.Write(" ");
            //        }
            //    }
            //    Console.WriteLine(" ");
            //}
        }

        public static bool[,] ZablokujHetman(int w, int k, bool[,] blok, bool[,] het)
        {

            int kolumna = k;

            int wiersz = w;
            bool[,] Blokowane = blok;
            bool[,] Hetm = het;

            if (Blokowane[w, k] == false)
            {
                Hetm[w, k] = true;
                skocz = false;
            }
            else
            {
                skocz = true;
            }

            return Hetm;
        }

        public static bool[,] ZablokujKWS(bool[,] Blok, bool[,] het, int w, int k)
        {

            if (Blok[w, k] == false)
            {
                ZablokujHetman(w, k, BlokowaneKWS, Hetman);
                zapisuj += (w + 1).ToString();
                

                for (int i = w; i < 8; i++)
                {
                    Blok[w, i] = true;

                    if (w > 0)
                    {
                        for (int c = w; c > -1; c--)
                        {
                            Blok[w, c] = true;

                        }
                    }
                }

                for (int j = k; j < 8; j++)
                {
                    Blok[j, k] = true;


                    if (k > 0)
                    {
                        for (int c = k; c > -1; c--)
                        {
                            Blok[c, k] = true;
                        }
                    }
                }

                int pomW = w;
                int pomK = k;

                int ZmiennaWK = k;
                int DrugaZmiennaWK = k;

                if (k > w)
                {
                    ZmiennaWK = w;
                    DrugaZmiennaWK = k;
                }
                if (w > k)
                {
                    ZmiennaWK = k;
                    DrugaZmiennaWK = w;
                }

                for (int sDP = DrugaZmiennaWK; sDP < 8; sDP++)
                {
                    if (pomW == pomK)
                    {
                        Blok[sDP, sDP] = true;

                    }
                    else
                    {
                        Blok[pomW++, pomK++] = true;

                    }
                }

                pomW = w;
                pomK = k; 

                try
                {
                    for (int ile = 0; ile < pomK + 1; ile++)
                    {
                        Blok[pomW + ile, pomK - ile] = true;
                    }
                }
                catch
                {
                    goto Dalej;
                }

                Dalej:

                pomW = w;
                pomK = k;

                for (int sGL = ZmiennaWK; sGL > -1; sGL--)
                {
                    Blok[pomW--, pomK--] = true;

                }

                pomW = w;
                pomK = k;

                try
                {
                    for (int ile = 0; ile < pomW; ile++)
                    {
                        Blok[pomW - ile, pomK + ile] = true;
                    }
                }
                catch
                {
                    goto Dalej2;
                }

                Dalej2:

                pomW = w;
                pomK = k;

                zliczaj++;

            }

            return Blok;
        }

        private static int Silnia(int n)
        {
            int silniaa = 1;
            for (int k = 1; k <= n; k++)
            {
                silniaa *= k;
            }
            return silniaa;
        }


 


    }
}
