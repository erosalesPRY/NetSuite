using AccesoDatos.NoTransaccional.GestionLogistica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionLogistica
{
    public class cGeneral
    {
        private readonly GeneralNTAD _general;

        public cGeneral(GeneralNTAD general)
        {
            _general = general;
        }

        public DataTable Listar_TG_EQUIVALENICIASGENERICAS(string UserName)
        {
            return _general.Listar_TG_EQUIVALENICIASGENERICAS(UserName); 
        }

        public DataTable Listar_TG_EQUIVALENICIASPORMATERIA(string UserName)
        {
            return _general.Listar_TG_EQUIVALENICIASPORMATERIA(UserName);
        }

        public DataTable Listar_Tg_Unidad_Medida(string UserName)
        {
            return _general.Listar_Tg_Unidad_Medida(UserName);
        }
    }
}
