using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{
    public class DAL
    {
        #region Propriété
        public Dictionary<Activités, Metiers> ListeMétier { get; set; }
        public Dictionary<string, Personnes> ListePersonne { get; set; }
        public Dictionary<string, Taches> ListeTache { get; set; }
        public Dictionary<int, DonnéesGestionTaches> ListeDonnées { get; set; }
        public Logiciels Logiciel { get; set; }
        #endregion

        #region Constructeur
        public DAL(Dictionary<string,Personnes> listePersonne)
        {
            //Initialisation des dictionnaires
            ListeMétier = new Dictionary<Activités, Metiers>();
            ListeTache = new Dictionary<string, Taches>();
            ListeDonnées = new Dictionary<int, DonnéesGestionTaches>();
            ListePersonne = listePersonne;

            //Initialisation des métiers et activités dans la liste Métier
            ListeMétier.Add(Activités.DBE ,new Metiers { Activité = Activités.DBE, LibelléActivité = LibelléActivités.DéfinitionDesBesoins, CodeMetier = CodeMetiers.ANA, LibelléMetier = LibelléMetiers.Analyste });
            ListeMétier.Add(Activités.ARF, new Metiers { Activité = Activités.ARF, LibelléActivité = LibelléActivités.ArchitectureFonctionnelle, CodeMetier = CodeMetiers.ANA | CodeMetiers.CDP, LibelléMetier = LibelléMetiers.Analyste | LibelléMetiers.ChefDeProjet });
            ListeMétier.Add(Activités.ANF, new Metiers { Activité = Activités.ANF, LibelléActivité = LibelléActivités.AnalyseFonctionnelle, CodeMetier = CodeMetiers.ANA | CodeMetiers.CDP | CodeMetiers.DEV |CodeMetiers.DES, LibelléMetier = LibelléMetiers.Analyste | LibelléMetiers.ChefDeProjet |LibelléMetiers.Développeur|LibelléMetiers.Designer});
            ListeMétier.Add(Activités.DES, new Metiers { Activité = Activités.DES, LibelléActivité = LibelléActivités.Design, CodeMetier = CodeMetiers.DES, LibelléMetier = LibelléMetiers.Designer });
            ListeMétier.Add(Activités.INF, new Metiers { Activité = Activités.INF, LibelléActivité = LibelléActivités.Infographie, CodeMetier = CodeMetiers.DES, LibelléMetier = LibelléMetiers.Designer });
            ListeMétier.Add(Activités.ART, new Metiers { Activité = Activités.ART, LibelléActivité = LibelléActivités.ArchitectureTechnique, CodeMetier = CodeMetiers.CDP|CodeMetiers.DEV, LibelléMetier = LibelléMetiers.ChefDeProjet|LibelléMetiers.Développeur});
            ListeMétier.Add(Activités.ANT, new Metiers { Activité = Activités.ANT, LibelléActivité = LibelléActivités.AnalyseTechnique, CodeMetier = CodeMetiers.DEV, LibelléMetier = LibelléMetiers.Développeur });
            ListeMétier.Add(Activités.DEV, new Metiers { Activité = Activités.DEV, LibelléActivité = LibelléActivités.Développement, CodeMetier = CodeMetiers.DEV, LibelléMetier = LibelléMetiers.Développeur });
            ListeMétier.Add(Activités.RPT, new Metiers { Activité = Activités.RPT, LibelléActivité = LibelléActivités.RédactionDePlanDeTest, CodeMetier = CodeMetiers.TES, LibelléMetier = LibelléMetiers.Testeur });
            ListeMétier.Add(Activités.TES, new Metiers { Activité = Activités.TES, LibelléActivité = LibelléActivités.Test, CodeMetier = CodeMetiers.TES|CodeMetiers.DEV, LibelléMetier = LibelléMetiers.Testeur|LibelléMetiers.Développeur });
            ListeMétier.Add(Activités.GDP, new Metiers { Activité = Activités.GDP, LibelléActivité = LibelléActivités.GestionDeProjet, CodeMetier = CodeMetiers.CDP, LibelléMetier = LibelléMetiers.ChefDeProjet });
        }
        #endregion

        #region Méthode
        public void ChargerDonnées()
        {
            string chemin = @"..\..\Données.txt";
            int compteur = 0;
            using (StreamReader str = new StreamReader(chemin))
            {
                string ligne;
                while ((ligne = str.ReadLine()) != null) //Boucle tant qu'il y a des lignes à lire
                {
                    compteur++;
                    if (compteur == 1) continue; //La première ligne n'est pas lu, elle sert de titre
                    var tab = ligne.Split('\t');
                    try
                    {
                        //Initialise une instance de DonnéesGestionTaches
                        var DonnéesGestionTache = new DonnéesGestionTaches
                        {
                            NumTache = int.Parse(tab[0]),
                            Version = new Versions() { Numéro = tab[1] }, //Nouvelle instance de Version renseignant le numéro                          
                            Personne = ListePersonne[tab[2]], //Nouvelle instance de Personne renseignant le champ Code
                            CodeActivité = (Activités)Enum.Parse(typeof(Activités), tab[3]),
                            Tache = new TachesProd() //Nouvelle instance de Tache renseignant tous ces champs
                            {
                                Libellé = tab[4],
                                DateDébut = DateTime.Parse(tab[5]),
                                DuréePrévue = int.Parse(tab[6]),
                                DuréeRéalisée = int.Parse(tab[7]),
                                DuréeRestante = int.Parse(tab[8])
                            }
                        };
                        //Ajout de l'instance DonnéesGestionTaches à la collection de données
                        ListeDonnées.Add(compteur - 1, DonnéesGestionTache);
                    }
                    catch (FormatException)
                    {
                        //Lève une exception si le format des données du fichier n'est pas bon.
                        throw new FormatException("Une erreur de format a été identifié dans le fichier de données à la ligne");
                    }
                }
            }
        }
        #endregion
    }

    public class DonnéesGestionTaches
    {
        #region Propriété
        public int NumTache { get; set; }
        public Versions Version { get; set; }
        public Personnes Personne { get; set; }
        public Activités CodeActivité { get; set; }
        public TachesProd Tache { get; set; }
        #endregion
    }

}
