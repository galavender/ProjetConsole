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
            var d = dal.ListeDonnées.Where(a => a.Value.Personne.Code == personne.Code)
                .Where(b => b.Value.Version.Numéro == version).Sum(c => c.Value.Tache.DuréeRéalisée);
            var d2 = dal.ListeDonnées.Where(a => a.Value.Personne.Code == personne.Code)
                .Where(b => b.Value.Version.Numéro == version).Sum(c => c.Value.Tache.DuréeRestante);
            //Retourne un format d'affichage
            return string.Format("Sur la version {0}, {1} {2} a réalisé {3} jours de travail, et il lui reste {4} jours de planifiés",
                version, personne.Prenom, personne.Nom, d, d2);
        }

        public static string RetardVersion(string version, DAL dal)
        {
            var d = dal.ListeDonnées.Where(a => a.Value.Version.Numéro == version)
                .Sum(b => b.Value.Tache.DuréePrévue);
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
            var activité = dal.ListeDonnées.Select(u => u.Value.CodeActivité).Distinct();
            foreach (var d in activité)
            {
                var totalJourTravaillé = dal.ListeDonnées.Where(y => y.Value.Version.Numéro == version).Where(c => c.Value.CodeActivité == d).Sum(g => g.Value.Tache.DuréeRéalisée);
                jourTravaillé += string.Format("{0} : {1}j\n",dal.ListeMétier[d].LibelléActivité, totalJourTravaillé);
            }
            //Retourne  un format d'affichage complété dans la boucle foreach
            return jourTravaillé;
        }
    }
}
