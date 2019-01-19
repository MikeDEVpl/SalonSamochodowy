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
            return null;
        }

        public bool CzyMaWyposazenie(Samochod s, Wyposazenie w)
        {
            return false;
        }

        public List<Samochod> PobierzSamochodyZWyposazeniem(List<Samochod> samochody, Wyposazenie w)
        {
            return null;
        }
    }
}
