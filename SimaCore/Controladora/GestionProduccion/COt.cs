using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AccesoDatos.NoTransaccional.GestionProduccion;
using AccesoDatos.Transaccional.GestionProduccion;
using EntidadNegocio;
using System.IO;

namespace Controladora.GestionProduccion
{ 
    public class COt
    {
        public string Modifica(BaseBE oBaseBE)
        {
            return (new OtTAD()).Modifica(oBaseBE);
        }

        private readonly OtNTAD _ot;

        public COt(OtNTAD ot)
        {
            _ot = ot;
        }

        public DataTable Listar_detg_pry_ot_sinfact(string CENTRO_OPERATIVO, string DIVISION, string PROYECTO, string sAnio, string UserName)
        {
            return _ot.Listar_detg_pry_ot_sinfact(CENTRO_OPERATIVO,DIVISION,PROYECTO, sAnio,UserName);
        }
        public DataTable Listar_detalle_gasto_pry_ot_fac(string N_CEO, string V_CODDIV, string V_CODPRY, string V_PERIODO, string UserName)
        {
            return _ot.Listar_detalle_gasto_pry_ot_fac(N_CEO,V_CODDIV,V_CODPRY,V_PERIODO,UserName);
        }

        public DataTable Listar_lista_ots_dq(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string V_CODDIV, string UserName)
        {
            return _ot.Listar_lista_ots_dq(D_FECHAFIN,D_FECHAINI,N_CEO,V_CODDIV,UserName);
        }
        public DataTable Listar_cabecera_ot(string N_CEO, string V_CODDIV, string V_NROOTS, string UserName)
        {
            return _ot.Listar_cabecera_ot(N_CEO,V_CODDIV,V_NROOTS,UserName);
        }
        public DataTable Listar_actividad_ot(string N_CEO, string V_CODDIV, string V_NROOTS, string UserName)
        {
            return _ot.Listar_actividad_ot(N_CEO, V_CODDIV, V_NROOTS, UserName);
        }
        public DataTable Listar_lista_estado_ot(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string V_CODDIV, string V_CODSTD, string V_NROOTS, string UserName)
        {
            return _ot.Listar_lista_estado_ot(D_FECHAFIN,D_FECHAINI,N_CEO,V_CODDIV,V_CODSTD,V_NROOTS,UserName);
        }
        public DataTable Listar_det_gasto_pry_ot_sin_factsu(string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            return _ot.Listar_det_gasto_pry_ot_sin_factsu(V_CENTRO_OPERATIVO, V_DIVISION, V_PROYECTO, UserName);
        }
        public DataTable Listar_det_gasto_pry_ot_facsu(string V_CENTRO_OPERATIVO, string V_DIVISIÓN, string V_PROYECTO, string UserName)
        {
            return _ot.Listar_det_gasto_pry_ot_facsu(V_CENTRO_OPERATIVO,V_DIVISIÓN,V_PROYECTO,UserName);
        }
        public DataTable Listar_actividades_jg(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string N_OPCION, string V_CODDIV, string UserName)
        {
            return _ot.Listar_actividades_jg(D_FECHAFIN,D_FECHAINI,N_CEO,N_OPCION,V_CODDIV,UserName);
        }
        public DataTable Listar_actividades_jg2(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string N_OPCION, string V_CODDIV, string V_CODTLLR, string UserName)
        {
            return _ot.Listar_actividades_jg2(D_FECHAFIN,D_FECHAINI,N_CEO,N_OPCION,V_CODDIV,V_CODTLLR,UserName);
        }
        public DataTable Listar_gasto_otsx(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string V_CODDIV, string V_CODPROY, string V_NROOTS, string UserName)
        {
            return _ot.Listar_gasto_otsx(D_FECHAFIN,D_FECHAINI,N_CEO,V_CODDIV,V_CODPROY,V_NROOTS,UserName);
        }
        public DataTable Listar_actividad_ot_proy(string N_CEO, string V_CODDIV, string V_CODPRY, string UserName)
        {
            return _ot.Listar_actividad_ot_proy(N_CEO,V_CODDIV,V_CODPRY,UserName);
        }
        public DataTable Listar_acta_conf_inf_gen(string V_CODUND, string V_NROOTS, string UserName)
        {
            return _ot.Listar_acta_conf_inf_gen(V_CODUND,V_NROOTS,UserName);
        }
        public DataTable Listar_acta_conf_solmn(string V_CODUND, string V_NROOTS, string UserName)
        {
            return _ot.Listar_acta_conf_solmn(V_CODUND, V_NROOTS, UserName);
        }
        public DataTable Listar_acta_conf(string V_CODUND, string V_NROOTS, string UserName)
        {
            return _ot.Listar_acta_conf(V_CODUND, V_NROOTS, UserName);
        }
        public DataTable Listar_detalle_ots_recursos(string N_CEO, string V_CATVCRV, string V_CODDIV, string V_NROOTS, string V_TIPRCS, string UserName)
        {
            return _ot.Listar_detalle_ots_recursos(N_CEO,V_CATVCRV,V_CODDIV,V_NROOTS,V_TIPRCS,UserName);
        }
        public DataTable Listar_detalle_ots_recursos_pryc(string N_CEO, string V_CODATV, string V_CODDIV, string V_CODPROY, string V_NROOTS, string V_TIPRCS, string UserName)
        {
            return _ot.Listar_detalle_ots_recursos_pryc(N_CEO,V_CODATV,V_CODDIV,V_CODPROY,V_NROOTS,V_TIPRCS,UserName);
        }

        public DataTable SP_LISTA_PLANILAxTpxDvxAuxFech(string sTipo, string sDivision, string sAreaU, string sFecha, string sAmbiente, string UserName)
        {
            return _ot.SP_LISTA_PLANILAxTpxDvxAuxFech(sTipo, sDivision, sAreaU, sFecha, sAmbiente, UserName);
        }
        public DataTable BuscaAprobaciónPLL(string sTipoPL, string cTaller, string sNivel, string sFecha, string sAmbiente, string UserName)
        {
            return _ot.BuscaAprobaciónPLL(sTipoPL, cTaller, sNivel, sFecha, sAmbiente, UserName);
        }


    }
}
