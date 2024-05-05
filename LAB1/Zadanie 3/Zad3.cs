using System;
using System.IO;

class Zad3
{
    static void Plik()
    {
        string sciezkaDoPliku = "C:\\Users\\Michal\\source\\repos\\LAB1\\LAB1\\Zadanie 3\\plik.txt";

        using (FileStream fs = new FileStream(sciezkaDoPliku, FileMode.Open, FileAccess.Read))
        {
            using (StreamReader sr = new StreamReader(fs))
            {
                string linia;
                while ((linia = sr.ReadLine()) != null)
                {
                    Console.WriteLine(linia);
                }
            }
        }

        Console.ReadKey();
    }
}
