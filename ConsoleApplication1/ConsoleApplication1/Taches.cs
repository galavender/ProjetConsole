using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Taches
    {
        public string Libellé { get; set; }
    }

    public class TachesProd : Taches
    {
        #region Propriétés
        public DateTime DateDébut { get; set; }
        public int DuréeRéalisée { get; set; }
        public int DuréeRestante { get; set; }
        public int DuréePrévue { get; set; }
        #endregion
    }

    public class TachesAnne : Taches
    {
        #region Propriétés
        public int ActivitéAnne { get; set; }
        public int CumulTempsPassé { get; set; }
        #endregion
    }
}
