using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionProyecto;

namespace Controladora.GestionProyecto
{ 
    public class CMob
    {
        private readonly MobNTAD _mob;

        public CMob(MobNTAD mob)
        {
            _mob = mob;
        }

        public DataTable Listar_det_gasto_pry_ot_mob(string D_FECHA_DE_TRABAJO_DESDE, string D_FECHA_DE_TRABAJO_HASTA, string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            return _mob.Listar_det_gasto_pry_ot_mob(D_FECHA_DE_TRABAJO_DESDE,D_FECHA_DE_TRABAJO_HASTA,V_CENTRO_OPERATIVO,V_DIVISION,V_PROYECTO,UserName);
        }

    }
}
