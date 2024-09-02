using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AccesoDatos.NoTransaccional.GestionProyecto;

namespace Controladora.GestionProyecto
{ 
    public class COt
    {
        private readonly OtNTAD _ot;

        public COt(OtNTAD ot)
        {
            _ot = ot;
        }

        public DataTable Listar_detg_pry_ot_sinfact(string CENTRO_OPERATIVO, string DIVISION, string PROYECTO, string AÑO, string UserName)
        {
            return _ot.Listar_detg_pry_ot_sinfact(CENTRO_OPERATIVO,DIVISION,PROYECTO,AÑO,UserName);
        }

    }
}
