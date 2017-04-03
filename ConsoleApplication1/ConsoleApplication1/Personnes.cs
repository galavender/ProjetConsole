using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Personnes
    {

        public Personnes(string code)
        {
            Code = code;

        }
        #region Propriété
        public String Code { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public Metiers Métier { get; set; }
        #endregion
    }
}
