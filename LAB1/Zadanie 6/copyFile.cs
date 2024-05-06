using System;
using System.IO;

class copyFile
{
    static void Zad6()
    {
        Console.Write("Podaj ścieżkę do pliku źródłowego: ");
        string sciezkaZrodlo = Console.ReadLine();

        Console.Write("Podaj ścieżkę do pliku docelowego: ");
        string sciezkaDocelowa = Console.ReadLine();

        if (File.Exists(sciezkaZrodlo))
        {
            KopiujPlik(sciezkaZrodlo, sciezkaDocelowa);
            Console.WriteLine("Plik został pomyślnie skopiowany.");
        }
        else
        {
            Console.WriteLine("Plik źródłowy nie istnieje.");
        }

        Console.WriteLine("Naciśnij dowolny klawisz, aby zakończyć program");
        Console.ReadKey();
    }

    static void KopiujPlik(string sciezkaZrodlo, string sciezkaDocelowy)
    {
        using (FileStream zrodloFs = new FileStream(sciezkaZrodlo, FileMode.Open))
        {
            using (FileStream docelowyFs = new FileStream(sciezkaDocelowy, FileMode.Create))
            {
                zrodloFs.CopyTo(docelowyFs);
            }
        }
    }
}
