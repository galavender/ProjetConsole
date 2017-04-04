using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JobOverview
{
    public class DAL
    {
        #region Propriété
        public Dictionary<CodeMetiers, Metiers> ListeMétier { get; set; }
        public Dictionary<string, Personnes> ListePersonne { get; set; }
        public Dictionary<string, Taches> ListeTache { get; set; }
        public Dictionary<int, DonnéesGestionTaches> ListeDonnées { get; set; }
        public Logiciels Logiciel { get; set; }
        #endregion

        #region Constructeur
        /// <summary>
        /// Constructeur Data Acess Layer (DAL)
        /// </summary>
        /// <param name="listePersonne"></param>
        /// <param name="listeMétier"></param>
        public DAL(Dictionary<string,Personnes> listePersonne,Dictionary<CodeMetiers,Metiers> listeMétier)
        {
            //Initialisation des dictionnaires
            ListeMétier = listeMétier;
            ListeTache = new Dictionary<string, Taches>();
            ListeDonnées = new Dictionary<int, DonnéesGestionTaches>();
            ListePersonne = listePersonne;

            //Initialise Version
            var version1 = new Versions { DateDebut = new DateTime(2016, 01, 02), DatePubli = new DateTime(2017, 01, 08), Millésime = 2017, Numéro = "1.00" };
            var version2 = new Versions { DateDebut = new DateTime(2016, 12, 28), DatePubli = new DateTime(), Millésime = 2018, Numéro = "2.00" };
            var listeVersion = new Dictionary<string,Versions>();
            listeVersion.Add("1.00",version1);
            listeVersion.Add("2.00",version2);

            //Initialise Logiciel
            Logiciel = new Logiciels { libellé = "Genomica", ListeVersion = listeVersion };

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
