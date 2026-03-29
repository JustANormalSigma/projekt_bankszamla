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
        }
    }
}
