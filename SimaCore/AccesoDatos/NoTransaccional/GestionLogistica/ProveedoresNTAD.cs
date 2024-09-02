using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Estandar;

namespace AccesoDatos.NoTransaccional.GestionLogistica
{
    public class ProveedoresNTAD
    {
        private readonly IStandarProcedure _standarProcedure;

        public ProveedoresNTAD(IStandarProcedure standarProcedure)
        {
            _standarProcedure = standarProcedure;
        }

        public DataTable Listar_PDT601_4TA(string D_FECHAPRO, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_PDT601_4TA";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("D_FECHAPRO", D_FECHAPRO);
            parameters.Add("UserName", UserName);

            try
            {
                return _standarProcedure.EjecutarProcedimiento(packageName, parameters);
            }
            catch
            {
                return null;
            }
        }

        public DataTable Listar_PDT601_PS4(string D_FECHAPRO, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_PDT601_PS4";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("D_FECHAPRO", D_FECHAPRO);
            parameters.Add("UserName", UserName);

            try
            {
                return _standarProcedure.EjecutarProcedimiento(packageName, parameters);
            }
            catch
            {
                return null;
            }
        }

        public DataTable Listar_Reg_Retencion_4TA(string D_FECHAPRO, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_Reg_Retencion_4TA";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("D_FECHAPRO", D_FECHAPRO);
            parameters.Add("UserName", UserName);

            try
            {
                return _standarProcedure.EjecutarProcedimiento(packageName, parameters);
            }
            catch
            {
                return null;
            }
        }

        public DataTable Listar_Salidas_Dev_Prov(string N_CEO, string V_PROCESO, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_Salidas_Dev_Prov";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("N_CEO", N_CEO);
            parameters.Add("V_PROCESO", V_PROCESO);
            parameters.Add("UserName", UserName);

            try
            {
                return _standarProcedure.EjecutarProcedimiento(packageName, parameters);
            }
            catch
            {
                return null;
            }
        }

        public DataTable Listar_ProgramaAdquiEnvioCot(string PROGRAMA_ADQUISICION, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_ProgramaAdquiEnvioCot";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("PROGRAMA_ADQUISICION", PROGRAMA_ADQUISICION);
            parameters.Add("UserName", UserName);

            try
            {
                return _standarProcedure.EjecutarProcedimiento(packageName, parameters);
            }
            catch
            {
                return null;
            }
        }

        public DataTable Listar_RegistroProveedores(string Fecha_Registro, string Estado, string Tipo, string RUC,
            string Procedencia, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_RegistroProveedores";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Fecha_Registro", Fecha_Registro);
            parameters.Add("Estado", Estado);
            parameters.Add("Tipo", Tipo);
            parameters.Add("RUC", RUC);
            parameters.Add("Procedencia", Procedencia);
            parameters.Add("UserName", UserName);

            try
            {
                return _standarProcedure.EjecutarProcedimiento(packageName, parameters);
            }
            catch
            {
                return null;
            }
        }
    }
}
