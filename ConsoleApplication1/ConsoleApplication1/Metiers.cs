using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOverview
{
    [Flags]
    public enum Activités
    {
        Aucune = 0,
        DBE = 1,
        ARF = 2,
        ANF = 4,
        DES = 8,
        INF = 16,
        ART = 32,
        ANT = 64,
        DEV = 128,
        RPT = 256,
        TES = 512,
        GDP = 1024
    }
    [Flags]
    public enum LibelléActivités
    {
        Aucune = 0,
        DéfinitionDesBesoins = 1,
        ArchitectureFonctionnelle = 2,
        AnalyseFonctionnelle = 4,
        Design = 8,
        Infographie = 16,
        ArchitectureTechnique = 32,
        AnalyseTechnique = 64,
        Développement = 128,
        RédactionDePlanDeTest = 256,
        Test = 512,
        GestionDeProjet = 1024
    }
    public enum CodeMetiers
    {
        ANA, CDP, DEV, DES, TES
    }
    public enum LibelléMetiers
    {
        Analyste, ChefDeProjet, Développeur, Designer, Testeur
    }

    public class Metiers
    {
        #region Propriété
        public Activités Activité { get; set; }
        public LibelléActivités LibelléActivité { get; set; }
        public CodeMetiers CodeMetier { get; set; }
        public LibelléMetiers LibelléMetier { get; set; }
        #endregion
    }
}
