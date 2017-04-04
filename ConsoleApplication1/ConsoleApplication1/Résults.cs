using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public static class Results
    {
        public static string DuréeTravail(Personnes personne, string version, DAL dal)
        {                   
                                        //Retourne la durée réalisée sur la version par la personne
            var d = dal.ListeDonnées.Where(a => a.Value.Personne.Code == personne.Code)
                .Where(b => b.Value.Version.Numéro == version).Sum(c => c.Value.Tache.DuréeRéalisée);
                                        //Retourne la durée restante sur la version pour la personne
            var d2 = dal.ListeDonnées.Where(a => a.Value.Personne.Code == personne.Code)
                .Where(b => b.Value.Version.Numéro == version).Sum(c => c.Value.Tache.DuréeRestante);
            //Retourne un format d'affichage
            return string.Format("Sur la version {0}, {1} {2} a réalisé {3} jours de travail, et il lui reste {4} jours de planifiés",
                version, personne.Prenom, personne.Nom, d, d2);
        }

        public static string RetardVersion(string version, DAL dal)
        {
                                    //Retourne la durée total de travail prévue sur une version
            var d = dal.ListeDonnées.Where(a => a.Value.Version.Numéro == version)
                .Sum(b => b.Value.Tache.DuréePrévue);
                                    //Retourne la durée total de travail réalisée sur une version
            var d2 = dal.ListeDonnées.Where(a => a.Value.Version.Numéro == version)
                .Sum(b => b.Value.Tache.DuréeRéalisée);

            if (d < d2)
                //Retourne un format d'affichage pour le cas du retard
                return string.Format("Sur la version {0}, la durée de travail réalisée a dépassé de {1}j la durée prévue, ce qui reprèsente un pourcentage proche de {2:F0}", version, d2 - d, 100-((100 * (double)(d)) / (double)(d2)));
            else
                //Retourne un format d'affichage pour le cas de l'avance
                return string.Format("Sur la version {0}, la durée de travail prévue a dépassé de {1}j la durée réalisée, ce qui reprèsente un pourcentage proche de {2:F0}", version, d - d2, 100-((100* (double)(d2)) / (double)(d)));
        }

        public static string TotalTravailRéa(string version, DAL dal)
        {
            string jourTravaillé = string.Empty;

                                    //Retourne la liste des code des activités
            var activité = dal.ListeDonnées.Select(u => u.Value.CodeActivité).Distinct();
            foreach (var d in activité)
            {
                                    //Stocke les durées de travail réalisées sur une version par activité dans une variable de type string
                var totalJourTravaillé = dal.ListeDonnées.Where(y => y.Value.Version.Numéro == version).Where(c => c.Value.CodeActivité == d).Sum(g => g.Value.Tache.DuréeRéalisée);
                jourTravaillé += string.Format("{0} : {1}j\n",d, totalJourTravaillé);
            }
            //Retourne  un format d'affichage complété dans la boucle foreach
            return jourTravaillé;
        }
    }
}
