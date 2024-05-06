using System;
using System.IO;

class Zad4
{
    static void revert()
    {
        string sciezkaDoPliku = "C:\\Users\\Michal\\source\\repos\\LAB1\\LAB1\\Zadanie 3\\plik.txt";

        using (StreamReader sr = new StreamReader(sciezkaDoPliku))
        {
            string linia;
            while ((linia = sr.ReadLine()) != null)
            {
                Console.WriteLine(OdwrocLinie(linia));
            }
        }

        Console.ReadKey();
    }

    static string OdwrocLinie(string linia)
    {
        char[] odwrocona = new char[linia.Length];
        for (int i = 0; i < linia.Length; i++)
        {
            odwrocona[i] = linia[linia.Length - 1 - i];
        }
        return new string(odwrocona);
    }
}
