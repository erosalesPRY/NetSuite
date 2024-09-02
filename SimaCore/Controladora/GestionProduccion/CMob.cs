using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionProduccion;
using System.Data;

namespace Controladora.GestionProduccion
{ 
    public class CMob
    {
        private readonly MobNTAD _mob;

        public CMob(MobNTAD mob)
        {
            _mob = mob;
        }

        public DataTable Listar_vacaciones(string D_PERIODO, string V_CO, string V_ROL, string UserName)
        {
            return _mob.Listar_vacaciones(D_PERIODO,V_CO,V_ROL,UserName);
        }

        public DataTable Listar_novedades_paus(string N_CEO, string V_CODUNS, string V_PERIODO, string UserName)
        {
            return _mob.Listar_novedades_paus(N_CEO,V_CODUNS,V_PERIODO,UserName);
        }
        public DataTable Listar_mob_x_fecha(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string UserName)
        {
            return _mob.Listar_mob_x_fecha(D_FECHAFIN,D_FECHAINI,N_CEO,UserName);
        }

        public DataTable Listar_lista_saldo_mo(string N_CEO, string V_CATVCRV, string V_CODDIV, string V_CODPROY, string V_NROOTS, string UserName)
        {
            return _mob.Listar_lista_saldo_mo(N_CEO,V_CATVCRV,V_CODDIV,V_CODPROY,V_NROOTS,UserName);
        }
    }
}
