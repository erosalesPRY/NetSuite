using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionActivoFijo;

namespace Controladora.GestionActivoFijo
{
    public class cActivoFijo
    {
        private readonly ActivoFijoNTAD _activoFijo;

        public cActivoFijo(ActivoFijoNTAD activoFijo)
        {
            _activoFijo = activoFijo;
        }

        public DataTable Listar_actfijo_cons_inv(string COD_EMP, string EST_BIEN, string UserName)
        {
            return _activoFijo.Listar_actfijo_cons_inv(COD_EMP, EST_BIEN, UserName);
        }

        public DataTable Listar_actfijo_pen(string COD_EMP, string EST_BIEN, string UserName)
        {
            return _activoFijo.Listar_actfijo_pen(COD_EMP, EST_BIEN, UserName);
        }

        public DataTable Listar_altascuentord_m(string ANIO, string COD_EMP, string EST_BIEN, string MES,
            string UserName)
        {
            return _activoFijo.Listar_altascuentord_m(ANIO, COD_EMP, EST_BIEN, MES, UserName);
        }

        public DataTable Listar_altasmes_actf(string ANIO, string COD_EMP, string EST_BIEN, string MES, string UserName)
        {
            return _activoFijo.Listar_altasmes_actf(ANIO, COD_EMP, EST_BIEN, MES, UserName);
        }

        public DataTable Listar_formato_7_1(string COD_EMP, string N_ANIO, string UserName)
        {
            return _activoFijo.Listar_formato_7_1(COD_EMP, N_ANIO, UserName);
        }

        public DataTable Listar_invent_actxgrupoysubgrsmn(string COD_EMPE, string GRUPOBN, string SUBGRUPOBN,
            string TIPOACTV, string UserName)
        {
            return _activoFijo.Listar_invent_actxgrupoysubgrsmn(COD_EMPE, GRUPOBN, SUBGRUPOBN, TIPOACTV, UserName);
        }

        public DataTable Listar_inventario_activosxcc(string CCOSTO1, string CCOSTO2, string COD_EMPE, string COD_PANOL,
            string TIPOACTV, string UserName)
        {
            return _activoFijo.Listar_inventario_activosxcc(CCOSTO1, CCOSTO2, COD_EMPE, COD_PANOL, TIPOACTV, UserName);
        }

        public DataTable Listar_inventario_activosxccrsm(string CCOSTO1, string CCOSTO2, string COD_EMPE,
            string TIPOACTV, string UserName)
        {
            return _activoFijo.Listar_inventario_activosxccrsm(CCOSTO1, CCOSTO2, COD_EMPE, TIPOACTV, UserName);
        }

        public DataTable Listar_inventario_activosxcustod(string COD_EMPE, string COD_ROL, string TIPOACTV,
            string UserName)
        {
            return _activoFijo.Listar_inventario_activosxcustod(COD_EMPE, COD_ROL, TIPOACTV, UserName);
        }

        public DataTable Listar_inventario_actsgrup_sub(string COD_EMP, string EST_BIEN, string GRUPO, string SUBGRUPO,
            string TIPO_BIEN, string UserName)
        {
            return _activoFijo.Listar_inventario_actsgrup_sub(COD_EMP, EST_BIEN, GRUPO, SUBGRUPO, TIPO_BIEN, UserName);
        }
    }
}
