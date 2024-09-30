using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetSuiteSocket.Server
{
    public  class ConeccionBE
    {
        public  ConeccionBE() { }
        public ConeccionBE(string jSon) {
            string[] Data = jSon.Split('&');
            this.platform=Data[0].Split('=')[1];
            this.App = Data[1].Split('=')[1];
            this.name = Data[2].Split('=')[1];
            this.CodPer = Data[3].Split('=')[1];
            this.IdContac = Data[4].Split('=')[1];
        }

        public string platform { get; set; }
        public string App { get; set; }
        public string name { get; set; }
        public string CodPer { get; set; }
        public string IdContac { get; set; }
    }
}
