using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Estandar;

namespace AccesoDatos.NoTransaccional.GestionLogistica
{
    public class StockNTAD
    {
        private readonly IStandarProcedure _standarProcedure;

        public StockNTAD(IStandarProcedure standarProcedure)
        {
            _standarProcedure = standarProcedure;
        }

        public DataTable Listar_TransStockVerFec(string FECHA_DE_TRANSFERENCIA_Inicio,
            string FECHA_DE_TRANSFERENCIA_Termino, string Material_Inicial, string Material_Final, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_TransStockVerFec";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("FECHA_DE_TRANSFERENCIA_Inicio", FECHA_DE_TRANSFERENCIA_Inicio);
            parameters.Add("FECHA_DE_TRANSFERENCIA_Termino", FECHA_DE_TRANSFERENCIA_Termino);
            parameters.Add("Material_Inicial", Material_Inicial);
            parameters.Add("Material_Final", Material_Final);
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

        public DataTable Listar_liberareservastrf(string FECHA_DE_LIBERACION_INICIO, string FECHA_DE_LIBERACION_TERMINO, string MATERIAL_FINAL, string MATERIAL_INICIAL, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_LIBERARESERVASTRF";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("FECHA_DE_LIBERACION_INICIO", FECHA_DE_LIBERACION_INICIO);
            parameters.Add("FECHA_DE_LIBERACION_TERMINO", FECHA_DE_LIBERACION_TERMINO);
            parameters.Add("MATERIAL_INICIAL", MATERIAL_INICIAL);
            parameters.Add("MATERIAL_FINAL", MATERIAL_FINAL);
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

        public DataTable Listar_Valorizacion_Disp_Stock(string N_CEO, string V_CODDIV, string V_NROVAL, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_Valorizacion_Disp_Stock";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("N_CEO", N_CEO);
            parameters.Add("V_CODDIV", V_CODDIV);
            parameters.Add("V_NROVAL", V_NROVAL);
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

        public DataTable Listar_Punto_Reposicion_Pedido(string TIPO_STOCK, string CLASE_MATERIAL, string CLASIFICACION,
            string MATERIAL_CRITICO, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_Punto_Reposicion_Pedido";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("TIPO_STOCK", TIPO_STOCK);
            parameters.Add("CLASE_MATERIAL", CLASE_MATERIAL);
            parameters.Add("CLASIFICACION", CLASIFICACION);
            parameters.Add("MATERIAL_CRITICO", MATERIAL_CRITICO);
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

        public DataTable Lista_TransStockVerCon(string Fecha_Inicial, string Fecha_Final, string USUARIO,
            string TERMINAL, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_TransStockVerCon";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Fecha_Inicial", Fecha_Inicial);
            parameters.Add("Fecha_Final", Fecha_Final);
            parameters.Add("USUARIO", USUARIO);
            parameters.Add("TERMINAL", TERMINAL);
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

        public DataTable Listar_liberareservascon(string FECHA_FINAL, string FECHA_INICIAL, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_LIBERARESERVASCON";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("FECHA_FINAL", FECHA_FINAL);
            parameters.Add("FECHA_INICIAL", FECHA_INICIAL);
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
