using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonSamochodowy
{
    public class DataProcessing
    {
        public Samochod PobierzSamochodZNajwiekszymWyposazeniem(List<Samochod> samochody)
        {
            //wersja 1
            Samochod result = (from Samochod s in samochody
                               orderby s.ListaWyposazenia.Count
                               select s).
                               First();

            //wersja 2
            int maksymalnaLiczbaDodatkow = (from Samochod s in samochody
                   select s.ListaWyposazenia.Count).Max();
            result = (from Samochod s in samochody
                      where 
                      s.ListaWyposazenia.Count == maksymalnaLiczbaDodatkow
                      select s).
                      First();

            //wersja 3
            result = samochody.OrderBy(s => s.ListaWyposazenia.Count).First();

            return result;
        }

        public Samochod PobierzSamochodNajdrozszy(List<Samochod> samochody)
        {
            // wersja 1
            //return samochody.OrderBy(s => s.CenaZDodatkami).First();

            // wersja 2
            return samochody.OrderBy(
                s => (s.CenaBazowa +
                s.ListaWyposazenia.Where(w => w.CzyStandard == false).
                Sum(w => w.Cena))).First();
        }

        public List<Samochod> PosortujPoCenie(List<Samochod> samochody)
        {
            //return samochody.OrderBy(s => s.CenaZDodatkami).ToList();

            List<Samochod> wynik;
            wynik = (from Samochod s in samochody
                     orderby s.CenaZDodatkami
                     select s).ToList();
            return wynik;
        }

        public bool CzyMaWyposazenie(Samochod s, Wyposazenie w)
        {
            // wersja "najczęściej działająca"
            // żeby działało jak należy, trzeba zaimplementować Equals()
            return s.ListaWyposazenia.Contains(w);

            //return s.ListaWyposazenia.Select(wyp => wyp.Nazwa).
            //    Contains(w.Nazwa);
        }

        public List<Samochod> PobierzSamochodyZWyposazeniem(List<Samochod> samochody, Wyposazenie w)
        {
            //return samochody.Where(s => s.ListaWyposazenia.Contains(w)).ToList();

            //return (from Samochod s in samochody
            //        where s.ListaWyposazenia.Contains(w)
            //        select s).ToList();

            return (from Samochod s in samochody
                    where (from Wyposazenie wyp in s.ListaWyposazenia
                           where wyp.Nazwa == w.Nazwa
                           select wyp).Count() > 0
                    select s).ToList();
        }
    }
}
