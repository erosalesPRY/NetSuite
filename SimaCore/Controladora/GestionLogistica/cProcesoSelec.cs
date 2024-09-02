using AccesoDatos.NoTransaccional.GestionLogistica;
using AccesoDatos.Transaccional.GestionLogistica;
using EntidadNegocio.GestionLogistica;
using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionLogistica
{
    public class cProcesoSelec
    {
        //---------- sistrades
        public DataTable ListarTodos2(string Id1, string UserName)
        {
            return (new ProcesoSistradesNTAD()).ListarTodos(Id1, UserName);
        }

        //------- MPV -----------
        public DataTable ListarTodos(string Id1, string sEstado)
        {
            return (new ProcesoMPV_NTAD()).ListarTodos(Id1, sEstado);
        }
        
        public int Modificar(BaseBE oBaseBE)
        {
            return (new ProcesoSelecTAD()).Modificar(oBaseBE);
        }
        public int Insertar(BaseBE oBaseBE)
        {
            return (new ProcesoSelecTAD()).Insertar(oBaseBE);
        }
        public int ModificarProcesos(BaseBE oBaseBE)
        {
            return (new ProcesoSistradesTAD()).Modificar(oBaseBE);
        }
    }
}
