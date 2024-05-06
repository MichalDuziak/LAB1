using System;
using System.Runtime.Serialization;

namespace ZarzadzanieZadaniami
{
    [DataContract]
    public class Zadanie
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nazwa { get; set; }
        [DataMember]
        public string Opis { get; set; }
        [DataMember]
        public DateTime DataZakonczenia { get; set; }
        [DataMember]
        public bool CzyWykonane { get; set; }

        public Zadanie(int id, string nazwa, string opis, DateTime dataZakonczenia, bool czyWykonane)
        {
            Id = id;
            Nazwa = nazwa;
            Opis = opis;
            DataZakonczenia = dataZakonczenia;
            CzyWykonane = czyWykonane;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Nazwa: {Nazwa}, Opis: {Opis}, Data zakończenia: {DataZakonczenia}, Wykonane: {(CzyWykonane ? "Tak" : "Nie")}";
        }
    }
}
