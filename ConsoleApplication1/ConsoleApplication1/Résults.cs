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
            var d = dal.ListeDonnées.Where(a => a.Value.Personne == personne).Where(b => b.Value.Version.Numéro == version).Sum(c => c.Value.Tache.DuréeRéalisée);
            var d2 = dal.ListeDonnées.Where(a => a.Value.Personne == personne).Where(b => b.Value.Version.Numéro == version).Sum(c => c.Value.Tache.DuréeRestante);
            return string.Format("Sur la version {0}, {1} {2} a réalisé {3} jours de travail, et il lui reste {4} jours de planifiés", version, personne.Prenom, personne.Nom, d, d2);
        }
    }
}
