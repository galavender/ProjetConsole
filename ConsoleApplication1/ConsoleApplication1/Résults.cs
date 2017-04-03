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
            var d = dal.ListeDonnées.Where(a => a.Value.Personne.Code == personne.Code).Where(b => b.Value.Version.Numéro == version).Sum(c => c.Value.Tache.DuréeRéalisée);
            var d2 = dal.ListeDonnées.Where(a => a.Value.Personne.Code == personne.Code).Where(b => b.Value.Version.Numéro == version).Sum(c => c.Value.Tache.DuréeRestante);
            return string.Format("Sur la version {0}, {1} {2} a réalisé {3} jours de travail, et il lui reste {4} jours de planifiés", version, personne.Prenom, personne.Nom, d, d2);
        }

        public static string RetardVersion(string version, DAL dal)
        {
            var d = dal.ListeDonnées.Where(a => a.Value.Version.Numéro == version).Sum(b => b.Value.Tache.DuréePrévue);
            var d2 = dal.ListeDonnées.Where(a => a.Value.Version.Numéro == version).Sum(b => b.Value.Tache.DuréeRéalisée);
            if (d < d2)
                return string.Format("Sur la version {0}, la durée de travail réalisée a dépassé de {1}j la durée prévue, ce qui reprèsente un pourcentage proche de {2}", version, d2 - d, (100 * d2) / d);
            else
                return string.Format("Sur la version {0}, la durée de travail prévue a dépassé de {1}j la durée réalisée, ce qui reprèsente un pourcentage proche de {2}", version, d - d2, (100 * d2) / d);
        }

        public static string TotalTravailRéa(string version, DAL dal)
        {
            foreach ( var d in dal.ListeDonnées.Select(a => a.Value.Tache.Libellé))
            {
                var 
            }
            var d = dal.ListeDonnées.Where(a => a.Value.Tache.Libellé)
        }
    }
}
