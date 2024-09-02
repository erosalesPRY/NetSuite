using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionLogistica
{
    public class LogisticaSqlBE : BaseBE
    {
        public string tdo_codigo { get; set; }
        public string tdo_descripcion { get; set; }
        public int tdo_estado { get; set; }
        public DateTime tdo_fechaupd { get; set; }
        public DateTime usu_updated { get; set; }
        public string IdCodigoChar { get; set; }
        public LogisticaSqlBE() { }
        public LogisticaSqlBE(string _tdo_codigo, string _tdo_descripcion, int _tdo_estado, DateTime _tdo_fechaupd, DateTime _usu_updated)
        {
            this.tdo_codigo = _tdo_codigo;
            this.tdo_descripcion = _tdo_descripcion;
            this.tdo_estado = _tdo_estado;
            this.tdo_fechaupd = _tdo_fechaupd;
            this.usu_updated = _usu_updated;
        }
    }
}
