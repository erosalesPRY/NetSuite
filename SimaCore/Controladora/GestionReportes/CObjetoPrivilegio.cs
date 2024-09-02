using AccesoDatos.Transaccional.GestionReportes;
using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionReportes
{
    public  class CObjetoPrivilegio
    {
        public string ModificaInserta(BaseBE oBaseBE)
        {
            return (new ObjetoPrivilegioTAD()).ModificaInserta(oBaseBE);
        }
     }
}
