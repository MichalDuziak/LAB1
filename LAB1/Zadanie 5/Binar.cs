using System;
using System.IO;

class Binar
{
    static void Zad5()
    {
        Console.WriteLine("Wybierz opcję:");
        Console.WriteLine("1. Zapisz dane do pliku");
        Console.WriteLine("2. Odczytaj dane z pliku");
        Console.Write("Twój wybór: ");

        string wybor = Console.ReadLine();

        if (wybor == "1")
        {
            ZapiszDaneDoPliku();
        }
        else if (wybor == "2")
        {
            OdczytajDaneZPliku();
        }
        else
        {
            Console.WriteLine("Niepoprawny wybór.");
        }

        Console.WriteLine("Naciśnij dowolny klawisz, aby zakończyć...");
        Console.ReadKey();
    }

    static void ZapiszDaneDoPliku()
    {
        Console.WriteLine("Podaj dane do zapisania:");
        Console.Write("Imię: ");
        string imie = Console.ReadLine();
        Console.Write("Wiek: ");
        int wiek = int.Parse(Console.ReadLine());
        Console.Write("Adres: ");
        string adres = Console.ReadLine();

        using (FileStream fs = new FileStream("dane.bin", FileMode.Create))
        {
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                writer.Write(imie);
                writer.Write(wiek);
                writer.Write(adres);
            }
        }

        Console.WriteLine("Dane zostały zapisane do pliku.");
    }

    static void OdczytajDaneZPliku()
    {
        if (File.Exists("dane.bin"))
        {
            using (FileStream fs = new FileStream("dane.bin", FileMode.Open))
            {
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    string imie = reader.ReadString();
                    int wiek = reader.ReadInt32();
                    string adres = reader.ReadString();

                    Console.WriteLine("Odczytane dane:");
                    Console.WriteLine("Imię: " + imie);
                    Console.WriteLine("Wiek: " + wiek);
                    Console.WriteLine("Adres: " + adres);
                }
            }
        }
        else
        {
            Console.WriteLine("Plik nie istnieje.");
        }
    }
}
