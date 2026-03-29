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

