using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt
{
    internal class Program
    {
        static List<Account> szamlak = new List<Account>();

        static void Main()
        {
            StreamReader sr = new StreamReader("szamlak.txt");
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] adatok = sor.Split(';');
                szamlak.Add(new Account(adatok[0], adatok[1], double.Parse(adatok[2])));
            }
            sr.Close();

            bool fut = true;
            while (fut)
            {
                Console.Clear();
                foreach (Account sz in szamlak) Console.WriteLine(sz.ToString());

                Console.WriteLine("\n1. Befizetés\n2. Kifizetés\n3. Utalás\n4. Hitelkeret\n5. Kilépés");
                string v = Console.ReadLine();

                if (v == "5")
                {
                    fut = false;
                }
                else if (v == "1")
                {
                    Account sz = Keres();
                    if (sz != null)
                    {
                        double osszeg = Bekeres("Összeg: ");
                        sz.Deposit(osszeg);
                        Console.WriteLine("Sikeres befizetés!");
                    }
                    else Console.WriteLine("Nincs ilyen számla!");
                }
                else if (v == "2")
                {
                    Account sz = Keres();
                    if (sz != null)
                    {
                        if (sz.Withdraw(Bekeres("Összeg: "))) Console.WriteLine("Sikeres kifizetés!");
                        else Console.WriteLine("Hiba: Nincs elég fedezet!");
                    }
                    else Console.WriteLine("Nincs ilyen számla!");
                }
                else if (v == "3")
                {
                    Console.Write("Forrás "); Account honnan = Keres();
                    Console.Write("Cél "); Account hova = Keres();
                    if (honnan != null && hova != null)
                    {
                        if (honnan.Utalas(hova, Bekeres("Utalandó összeg: "))) Console.WriteLine("Sikeres utalás!");
                        else Console.WriteLine("Hiba: Nincs elég fedezet az utaláshoz!");
                    }
                    else Console.WriteLine("Valamelyik számla nem található!");
                }
                else if (v == "4")
                {
                    Account sz = Keres();
                    if (sz != null)
                    {
                        if (sz.HitelkeretModositasa(Bekeres("Új hitelkeret: "))) Console.WriteLine("Sikeres módosítás!");
                        else Console.WriteLine("Hiba: A keret max a nyitóegyenleg 20%-a lehet!");
                    }
                    else Console.WriteLine("Nincs ilyen számla!");
                }

                if (fut)
                {
                    Console.WriteLine("\nNyomj egy gombot...");
                    Console.ReadKey();
                }
            }

            foreach (Account sz in szamlak)
            {
                sz.NaploFajlbaIr();
            }


        }



        static Account Keres()
        {
            Console.Write("számlaszáma: ");
            string id = Console.ReadLine();
            foreach (Account sz in szamlak)
            {
                if (sz.GetSzamlaszam() == id) return sz;
            }
            return null;
        }
    
    static double Bekeres(string uzenet)
        {
            Console.Write(uzenet);
            double szam;
            while (!double.TryParse(Console.ReadLine(), out szam) || szam < 0)
            {
                Console.Write("Érvényes pozitív számot adj meg: ");
            }
            return szam;
        }


    }
}
