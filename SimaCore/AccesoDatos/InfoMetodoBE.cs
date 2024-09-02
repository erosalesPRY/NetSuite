using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class InfoMetodoBE
    {
        public InfoMetodoBE()
        {
        }

        public string FullName { get; set; }
        public string MetodoANDParams { get; set; }

        string strOut = "";
        public string VoidParams { get; set; }

        private List<string> lstValues = new List<string>();
        public override string ToString()
        {
            string LogMetod = "NAMESAPACE: " + this.FullName + " || " + " METODO:= " + this.MetodoANDParams;
            return LogMetod.ToString();
        }

    }
}
