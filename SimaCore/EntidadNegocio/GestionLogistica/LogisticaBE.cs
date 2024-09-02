using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionLogistica
{
    public class LogisticaBE : BaseBE
    {
        public string tdo_codigo { get; set; }
        public string tdo_descripcion { get; set; }
        public string c_estado { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime created_at { get; set; }
        public Char IdCodigoChar { get; set; }

        public LogisticaBE() { }
        public LogisticaBE(string _tdo_codigo, string _tdo_descripcion, string _c_estado, DateTime _updated_at, DateTime _created_at)
        {
            this.tdo_codigo = _tdo_codigo;
            this.tdo_descripcion = _tdo_descripcion;
            this.c_estado = _c_estado;
            this.updated_at = _updated_at;
            this.created_at = _created_at;
        }
    }
}
