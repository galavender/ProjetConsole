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
            //Initialisation des données utile au test
            var listePersonne = new Dictionary<string, Personnes>();
            Program.InitPersonne(ref listePersonne);
            var Genomica = new DAL(listePersonne);
            Genomica.ChargerDonnées();

            //Premier test
            string s = Results.DuréeTravail(listePersonne["GL"], "2.00", Genomica);
            Assert.AreEqual("Sur la version 2.00, Geneviève LECLERCQ a réalisé 58 jours de travail, et il lui reste 21 jours de planifiés", s);

            //Second test
             s = Results.DuréeTravail(listePersonne["MW"], "2.00", Genomica);
            Assert.AreEqual("Sur la version 2.00, Marguerite WEBER a réalisé 72 jours de travail, et il lui reste 11 jours de planifiés", s);
        }

        [TestMethod]
        public void TestRetardVersion()
        {
            //Initialisation des données utile au test
            var listePersonne = new Dictionary<string, Personnes>();
            Program.InitPersonne(ref listePersonne);
            var Genomica = new DAL(listePersonne);
            Genomica.ChargerDonnées();

            //Test
            string s = Results.RetardVersion("1.00", Genomica);
            Assert.AreEqual("Sur la version 1.00, la durée de travail réalisée a dépassé de 3j la durée prévue, ce qui reprèsente un pourcentage proche de 0", s);
        }

        [TestMethod]
        public void TestTotalTravailRéa()
        {
            //Initialisation des données utile au test
            var listePersonne = new Dictionary<string, Personnes>();
            Program.InitPersonne(ref listePersonne);
            var Genomica = new DAL(listePersonne);
            Genomica.ChargerDonnées();

            //Test
            string s = Results.TotalTravailRéa("1.00", Genomica);
            Assert.AreEqual("DéfinitionDesBesoins : 126j\nArchitectureFonctionnelle : 79j\n"+
                            "AnalyseFonctionnelle : 295j\nArchitectureTechnique : 95j\n"+
                            "Test : 248j\nGestionDeProjet : 54j\nAnalyseTechnique : 184j\n"+
                            "Développement : 259j\nDesign : 81j\nInfographie : 81j\n"+
                            "RédactionDePlanDeTest : 184j\n", s);
        }
    }
}
