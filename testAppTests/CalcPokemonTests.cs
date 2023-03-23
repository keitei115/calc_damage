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
        CalcPokemon calcPokemon = new CalcPokemon(attack: 50);

        [TestMethod()]
        public void calcDamageTest()
        {
   
            if (calcPokemon.calcDamage() != 90)
            {
                Assert.Fail();
            }
            
        }
    }
}
