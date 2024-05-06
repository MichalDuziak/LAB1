using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace ZarzadzanieZadaniami
{
    public class ManagerZadan
    {
        private List<Zadanie> listaZadan;

        public ManagerZadan()
        {
            listaZadan = new List<Zadanie>();
        }

        public void DodajZadanie(Zadanie zadanie)
        {
            listaZadan.Add(zadanie);
        }

        public void UsunZadanie(int id)
        {
            listaZadan.RemoveAll(z => z.Id == id);
        }

        public void WyswietlZadania()
        {
            foreach (var zadanie in listaZadan)
            {
                Console.WriteLine(zadanie);
            }
        }

        public void ZapiszDoPlikuXML(string sciezka)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Zadanie>));
            using (TextWriter writer = new StreamWriter(sciezka))
            {
                serializer.Serialize(writer, listaZadan);
            }
        }

        public void WczytajZPlikuXML(string sciezka)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Zadanie>));
            using (TextReader reader = new StreamReader(sciezka))
            {
                listaZadan = (List<Zadanie>)serializer.Deserialize(reader);
            }
        }

        public void ZapiszDoPlikuJSON(string sciezka)
        {
            using (var fs = new FileStream(sciezka, FileMode.Create))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Zadanie>));
                serializer.WriteObject(fs, listaZadan);
            }
        }

        public void WczytajZPlikuJSON(string sciezka)
        {
            using (var fs = new FileStream(sciezka, FileMode.Open))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Zadanie>));
                listaZadan = (List<Zadanie>)serializer.ReadObject(fs);
            }
        }
    }
}
