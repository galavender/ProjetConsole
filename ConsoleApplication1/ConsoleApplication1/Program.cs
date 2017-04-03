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

            while (true)
            {
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Quel action voulez-vous effectuer ? \n r : resultats\n a : Ajouter une activité annexe\n ");
                switch (Console.ReadLine())
                {
                    case "r":
                        resultat(Genomica);
                        break;
                    case "a":
                        InitActivitésAnnexes(ref ActiAne);
                        break;
                    default:
                        Console.WriteLine("Ce n'est pas une action, appuyez sur une touche");
                        break;
                }
                

            }

            //Console.WriteLine(Results.DuréeTravail(new Personnes() { Nom = "Geneviève", Prenom = "Leclerq", Code = "GL", Métier =  CodeMetiers.ANA } ,"2.00", Genomica));
            //Console.WriteLine(Results.RetardVersion("1.00", Genomica));
            //Console.WriteLine(Results.TotalTravailRéa("1.00", Genomica));
            //Console.ReadKey();
        }


        static void InitActivitésAnnexes(ref SortedDictionary<string, Taches> ActiAne)
        {
            bool PlusDActiAnn = false;

            string libellé = string.Empty;

            while (!PlusDActiAnn)
            {
                Console.WriteLine("Veuillez saisir le code d'une activité annexe :");
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


        static void resultat(DAL Genomica)
        {
            Console.WriteLine("Quel resultat voulez-vous ?\n p : durées de travail réalisée et restante d’une personne sur une version\n n : nombre de jours et le pourcentage d’avance ou de retard sur une version \n d : durées totales de travail réalisées sur la production d’une version, pour chaque activité");
            switch (Console.ReadLine())
            {
                case "d":
                    Console.WriteLine("Sur quelle version");
                    Console.WriteLine(Results.TotalTravailRéa(Console.ReadLine(), Genomica));
                    break;
                case "n":
                    Console.WriteLine("Sur quelle version");
                    Console.WriteLine(Results.RetardVersion(Console.ReadLine(), Genomica));
                    break;
                case "p":
                    Console.WriteLine("Quelles sont les initiales de la personne?");
                    string initial = Console.ReadLine().ToUpper();
                    Console.WriteLine("Sur quelle version");

                    Console.WriteLine(Results.DuréeTravail(new Personnes() { Nom = "Geneviève", Prenom = "Leclerq", Code = "GL", Métier = CodeMetiers.ANA }, Console.ReadLine(), Genomica));
                    break;
                default:
                    break;
            }
        }
    }
}
