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
        public Dictionary<int, Metiers> ListeMétier { get; set; }
        public Dictionary<int, Personnes> ListePersonne { get; set; }
        public Dictionary<int, Taches> ListeTache { get; set; }
        public object Logiciel { get; set; }    //A modifier avec la classe logiciel
        #endregion

        #region Méthode
        public void ChargerDonnées()
        {
            string chemin = @"..\..\Données.xlsx";  
            int compteur = 0;
            using (StreamReader str = new StreamReader(chemin)) 
            {
                string ligne;
                while ((ligne = str.ReadLine()) != null)
                {
                    compteur++;
                    if (compteur < 2) continue;
                    var tab = ligne.Split('\t');
                    try
                    {
                        var DonnéesGestionTache = new DonnéesGestionTaches                   
                        {
                            NumTache = int.Parse(tab[0]),                                           
                            Version = tab[1],   //A modifier                            
                            Personne = new Personnes() { Code = tab[2]},                        //Nouvelle instance de Personne renseignant le champ Code
                            CodeActivité = (Activités) Enum.Parse(typeof(Activités), tab[3]),
                            Tache = new TachesProd()                                            //Nouvelle instance de Tache renseignant tous ces champs
                            {
                                Libellé = tab[4],
                                DateDébut = DateTime.Parse(tab[5]),
                                DuréePrévue = int.Parse(tab[6]),
                                DuréeRéalisée = int.Parse(tab[7]),
                                DuréeRestante = int.Parse(tab[8])
                            }
                        };
                    }
                    catch (FormatException)
                    {
                        throw new FormatException();
                    }
                }
            }
        }
        #endregion

    }

    public class DonnéesGestionTaches
    {
        public int NumTache { get; set; }
        public Object Version { get; set; } //A modifier avec la classe Version
        public Personnes Personne { get; set; }
        public Activités CodeActivité { get; set; }
        public Taches Tache { get; set; }

    }

}
