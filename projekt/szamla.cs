using System;
using System.Collections.Generic;
using System.IO;

class Account
{
    private string szamlaszam;
    private string nev;
    private double egyenleg;
    private double hitelkeret;
    private double nyitoEgyenleg;
    private List<string> naplo = new List<string>();

    public Account(string szamlaszam, string nev, double egyenleg)
    {
        this.szamlaszam = szamlaszam;
        this.nev = nev;
        this.egyenleg = egyenleg;
        this.nyitoEgyenleg = egyenleg;
        this.hitelkeret = 0;
    }

    public string GetSzamlaszam()
    {
        return szamlaszam;
    }

    private void Naplozas(string tipus, double osszeg)
    {
        string bejegyzes = DateTime.Now.ToString() + ";" + tipus + ";" + osszeg + ";" + egyenleg;
        naplo.Add(bejegyzes);
    }

    public void Deposit(double osszeg)
    {
        if (osszeg > 0)
        {
            egyenleg += osszeg;
            Naplozas("befizetés", osszeg);
        }
    }

    public bool Withdraw(double osszeg)
    {
        if (osszeg > 0 && egyenleg + hitelkeret >= osszeg)
        {
            egyenleg -= osszeg;
            Naplozas("kifizetés", osszeg);
            return true;
        }
        return false;
    }


    public bool Utalas(Account celSzamla, double osszeg)
    {
        if (this.Withdraw(osszeg))
        {
            celSzamla.Deposit(osszeg);
            return true;
        }
        return false;
    }

    public bool HitelkeretModositasa(double ujKeret)
    {
        if (ujKeret >= 0 && ujKeret <= nyitoEgyenleg * 0.2)
        {
            hitelkeret = ujKeret;
            Naplozas("hitelkeret módosítása", ujKeret);
            return true;
        }
        return false;
    }

}



