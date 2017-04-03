using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Personnes
    {
        #region Propriété
        public String Code { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public CodeMetiers Métier { get; set; }
        #endregion
    }
}
