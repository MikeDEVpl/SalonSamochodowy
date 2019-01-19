using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonSamochodowy
{
    public class Samochod
    {
        public string Model { get; set; }
        public int RokProdukcji { get; set; }
        public Silnik Silnik { get; set; }
        public double SpalanieSrednie { get; set; }
        public int CenaBazowa { get; set; }
        public List<Wyposazenie> ListaWyposazenia {get;set; }

        public int CenaZDodatkami
        {
            get
            {
                // wariant 1
                int cenaDodatkowNieobowiazkowych = 0;
                foreach (Wyposazenie wyposazenie in ListaWyposazenia)
                {
                    if (!wyposazenie.CzyStandard)
                        cenaDodatkowNieobowiazkowych += wyposazenie.Cena;
                }
                // return CenaBazowa + cenaDodatkowNieobowiazkowych

                // wariant 2
                return CenaBazowa +
                    ListaWyposazenia.
                    Where(w=>w.CzyStandard == false).
                    Sum(w => w.Cena);
            }
        }
    }
}
