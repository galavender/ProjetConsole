using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var Genomica = new DAL();
            Genomica.ChargerDonnées();
            SortedDictionary<string, Taches> ActiAne = new SortedDictionary<string, Taches>();
            InitActivitésAnnexes(ref ActiAne);
            Console.WriteLine( Results.DuréeTravail(new Personnes() { Nom = "Geneviève", Prenom = "Leclerq", Code = "GL", Métier = new Metiers() { CodeMetier = CodeMetiers.ANA } },"2.00", Genomica));

            Console.ReadKey();
        }


        static void InitActivitésAnnexes(ref SortedDictionary<string, Taches> ActiAne)
        {
            bool PlusDActiAnn = false;

            string libellé = string.Empty;

            while (!PlusDActiAnn)
            {
                Console.WriteLine("Bonjour, Veuillez saisir le code d'une activité annexe :");
                string code = Console.ReadLine();
                if (!ActiAne.ContainsKey(code))
                {
                    Console.WriteLine("Veuillez saisir le nom de l'activité annexe correspondante:");
                    libellé = Console.ReadLine();
                    ActiAne.Add(code, new Taches { Libellé = libellé });
                    }
                else
                {
                    Console.WriteLine("Ce code existe déjà, veuillez saisir un code différent");
                }
                Console.WriteLine("Voulez-vous saisir une autre activité annexe ? o/n");
                if (Console.ReadLine() == "n")
                    PlusDActiAnn = true;
            }

            Console.Clear();
            foreach (var a in ActiAne)
            {
                Console.WriteLine("Activité n°{0} : {1}", a.Key, a.Value.Libellé);
            }

        }

    }
}
