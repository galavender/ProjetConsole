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
        public void TestPersonneEtActivités()
        {
            //Initialisation des données utile au test
            var listePersonne = new Dictionary<string, Personnes>();
            var listeMétier = new Dictionary<CodeMetiers, Metiers>();
            Program.InitPersonne(ref listePersonne, ref listeMétier);
            var Genomica = new DAL(listePersonne, listeMétier);
            Genomica.ChargerDonnées();
            //Test reliant les personnes à leurs différentes activités 
            Assert.AreEqual(LibelléActivités.DéfinitionDesBesoins | LibelléActivités.ArchitectureFonctionnelle | LibelléActivités.AnalyseFonctionnelle, listePersonne["GL"].Métier.LibelléActivité);
        }

        [TestMethod]
        public void TestDuréeTravail()
        {
            //Initialisation des données utile au test
            var listePersonne = new Dictionary<string, Personnes>();
            var listeMétier = new Dictionary<CodeMetiers, Metiers>();
            Program.InitPersonne(ref listePersonne, ref listeMétier);
            var Genomica = new DAL(listePersonne, listeMétier);
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
            var listeMétier = new Dictionary<CodeMetiers, Metiers>();
            Program.InitPersonne(ref listePersonne,ref listeMétier);
            var Genomica = new DAL(listePersonne, listeMétier);
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
            var listeMétier = new Dictionary<CodeMetiers, Metiers>();
            Program.InitPersonne(ref listePersonne, ref listeMétier);
            var Genomica = new DAL(listePersonne,listeMétier);
            Genomica.ChargerDonnées();

            //Test
            string s = Results.TotalTravailRéa("1.00", Genomica);
            Assert.AreEqual("DBE : 126j\nARF : 79j\n"+
                            "ANF : 295j\nART : 95j\n"+
                            "TES : 248j\nGDP : 54j\nANT : 184j\n"+
                            "DEV : 259j\nDES : 81j\nINF : 81j\n"+
                            "RPT : 184j\n", s);
        }
    }
}
