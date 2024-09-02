using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionPersonal
{
    public class MarcacionesBE : BaseBE
    {
        public string CodigoCia { get; set; }
        public string CodigoSuc { get; set; }
        public string NroIP { get; set; }
        public string NomDisp { get; set; }
        public string SenSid { get; set; }
        public string NroDNI { get; set; }
        public string FechaHora { get; set; }
        public string ChkTyp { get; set; }
        public string Msg { get; set; }

        public MarcacionesBE() { }
    }
}
