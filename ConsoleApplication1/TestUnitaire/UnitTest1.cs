using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication1;
using System.Collections.Generic;

namespace TestUnitaire
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDuréeTravail()
        {

            var listePersonne = new Dictionary<string, Personnes>();
            Program.InitPersonne(ref listePersonne);
            var Genomica = new DAL(listePersonne);
            Genomica.ChargerDonnées();


            string s = Results.DuréeTravail(listePersonne["GL"], "2.00", Genomica);
            Assert.AreEqual("Sur la version 2.00, Geneviève LECLERCQ a réalisé 58 jours de travail, et il lui reste 21 jours de planifiés", s);
        }


    }
}
