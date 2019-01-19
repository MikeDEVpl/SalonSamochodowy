using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonSamochodowy
{
    public class Wyposazenie
    {
        public string Nazwa { get; set; }
        public int Cena { get; set; }
        public bool CzyStandard { get; set; }

        public override bool Equals(object obj)
        {
            Wyposazenie other = (Wyposazenie)obj;
            return this.Nazwa == other.Nazwa;
        }
    }
}
