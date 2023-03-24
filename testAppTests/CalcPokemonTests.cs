using Microsoft.VisualStudio.TestTools.UnitTesting;
using testApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace testApp.Tests
{
    [TestClass()]
    public class CalcPokemonTests

    {

        [TestMethod()]
        public void calcDamageTest()
        {
            CalcPokemon calcPokemon = new CalcPokemon(attack: 55,attackRank:-6,defenseRank:-3);
            if (calcPokemon.calcDamage() != 90)
            {
                Assert.Fail();
            }

        }
        [TestMethod()]
        public void calcOverHalfTest() {
            CalcPokemon calcPokemon = new CalcPokemon();
            Debug.WriteLine(calcPokemon.OverHalf(2.9));
            Assert.Fail();
        }
    }
}
