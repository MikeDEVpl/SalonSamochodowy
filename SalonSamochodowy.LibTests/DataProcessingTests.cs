using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalonSamochodowy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonSamochodowy.Tests
{
    [TestClass()]
    public class DataProcessingTests
    {
        [TestMethod()]
        public void CzyMaWyposazenieTest()
        {
            List<Samochod> auta = Dane.Dane.Samochody;
            List<Wyposazenie> elementyWyposazenia = Dane.Dane.DostepneWyposazenie;

            DataProcessing dp = new DataProcessing();
            bool result = dp.CzyMaWyposazenie(auta[0], elementyWyposazenia[2]);
            Assert.IsTrue(result);

            Wyposazenie radio = new Wyposazenie() { Nazwa = "Radio", Cena = 2000, CzyStandard = true };
            result = dp.CzyMaWyposazenie(auta[0], radio);
            Assert.IsTrue(result);

        }
    }
}