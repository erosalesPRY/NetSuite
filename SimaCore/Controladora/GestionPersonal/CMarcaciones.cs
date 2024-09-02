using AccesoDatos.Transaccional.GestionPersonal;
using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionPersonal
{
    public class CMarcaciones
    {
        public string Inserta(BaseBE oBaseBE)
        {
            return (new MarcacionesTAD()).Inserta(oBaseBE);
        }
    }
}
