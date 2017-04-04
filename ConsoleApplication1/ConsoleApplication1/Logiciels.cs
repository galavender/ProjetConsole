using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOverview
{
    public class Logiciels
    {
        #region Propriété
        public string libellé { get; set; }
        public Dictionary<string,Versions> ListeVersion { get; set; }
        #endregion
    }
}
