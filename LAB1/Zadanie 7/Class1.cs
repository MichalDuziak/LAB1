using System;
using System.Diagnostics;
using System.IO;

class Performance
{
    static void Zad7()
    {
        string sciezkaZrodlo = "plik_zrodlowy.txt";
        string sciezkaDocelowy = "plik_docelowy.txt";

        Console.WriteLine("Generowanie pliku źródłowego");
        GenerujPlik(sciezkaZrodlo, 300 * 1024 * 1024); // 300 MB

        Console.WriteLine("Testy wydajności kopiowania plików");

        PomiarCzasuKopiowania(() => KopiujPlik_CopyTo(sciezkaZrodlo, sciezkaDocelowy), "FileStream.CopyTo");

        PomiarCzasuKopiowania(() => KopiujPlik_FileCopy(sciezkaZrodlo, sciezkaDocelowy), "File.Copy");

        PomiarCzasuKopiowania(() => KopiujPlik_Write(sciezkaZrodlo, sciezkaDocelowy), "FileStream.Write");

        PomiarCzasuKopiowania(() => KopiujPlik_Binary(sciezkaZrodlo, sciezkaDocelowy), "BinaryReader/BinaryWriter");

        File.Delete(sciezkaZrodlo);
        File.Delete(sciezkaDocelowy);

        Console.WriteLine("Testy zakończone.");

        Console.WriteLine("Naciśnij dowolny klawisz, aby zakończyć program");
        Console.ReadKey();
    }

    static void GenerujPlik(string sciezka, int rozmiar)
    {
        byte[] dane = new byte[1024 * 1024];
        Random rand = new Random();
        using (FileStream fs = new FileStream(sciezka, FileMode.Create))
        {
            for (int i = 0; i < rozmiar / (1024 * 1024); i++)
            {
                rand.NextBytes(dane);
                fs.Write(dane, 0, dane.Length);
            }
        }
    }

    static void KopiujPlik_CopyTo(string zrodlo, string docelowy)
    {
        using (FileStream zrodloFs = new FileStream(zrodlo, FileMode.Open))
        {
            using (FileStream docelowyFs = new FileStream(docelowy, FileMode.Create))
            {
                zrodloFs.CopyTo(docelowyFs);
            }
        }
    }

    static void KopiujPlik_FileCopy(string zrodlo, string docelowy)
    {
        File.Copy(zrodlo, docelowy);
    }

    static void KopiujPlik_Write(string zrodlo, string docelowy)
    {
        byte[] bufor = new byte[1024 * 1024];
        using (FileStream zrodloFs = new FileStream(zrodlo, FileMode.Open))
        {
            using (FileStream docelowyFs = new FileStream(docelowy, FileMode.Create))
            {
                int odczytane;
                while ((odczytane = zrodloFs.Read(bufor, 0, bufor.Length)) > 0)
                {
                    docelowyFs.Write(bufor, 0, odczytane);
                }
            }
        }
    }

    static void KopiujPlik_Binary(string zrodlo, string docelowy)
    {
        byte[] bufor = new byte[1024 * 1024];
        using (BinaryReader reader = new BinaryReader(File.Open(zrodlo, FileMode.Open)))
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(docelowy, FileMode.Create)))
            {
                int odczytane;
                while ((odczytane = reader.Read(bufor, 0, bufor.Length)) > 0)
                {
                    writer.Write(bufor, 0, odczytane);
                }
            }
        }
    }

    static void PomiarCzasuKopiowania(Action kopiuj, string nazwaMetody)
    {
        Stopwatch stoper = new Stopwatch();
        stoper.Start();
        kopiuj();
        stoper.Stop();
        Console.WriteLine($"Metoda {nazwaMetody}: {stoper.Elapsed.TotalSeconds} sekund");
    }
}
