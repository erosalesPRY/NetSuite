using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionLogistica;

namespace Controladora.GestionLogistica
{
    public class cStock
    {
        private readonly StockNTAD _stock;

        public cStock(StockNTAD stock)
        {
            _stock = stock;
        }

        public DataTable Listar_TransStockVerFec(string FECHA_DE_TRANSFERENCIA_Inicio,
            string FECHA_DE_TRANSFERENCIA_Termino, string Material_Inicial, string Material_Final, string UserName)
        {
            return _stock.Listar_TransStockVerFec(FECHA_DE_TRANSFERENCIA_Inicio, FECHA_DE_TRANSFERENCIA_Termino,
                Material_Inicial, Material_Final, UserName);
        }

        public DataTable Lista_TransStockVerCon(string Fecha_Inicial, string Fecha_Final, string USUARIO,
            string TERMINAL, string UserName)
        {
            return _stock.Lista_TransStockVerCon(Fecha_Inicial, Fecha_Final, USUARIO, TERMINAL, UserName);
        }

        public DataTable Listar_Valorizacion_Disp_Stock(string N_CEO, string V_CODDIV, string V_NROVAL, string UserName)
        {
            return _stock.Listar_Valorizacion_Disp_Stock(N_CEO, V_CODDIV, V_NROVAL, UserName);
        }

        public DataTable Listar_Punto_Reposicion_Pedido(string TIPO_STOCK, string CLASE_MATERIAL, string CLASIFICACION,
            string MATERIAL_CRITICO, string UserName)
        {
            return _stock.Listar_Punto_Reposicion_Pedido(TIPO_STOCK, CLASE_MATERIAL, CLASIFICACION, MATERIAL_CRITICO,
                UserName);
        }

        public DataTable Listar_liberareservastrf(string FECHA_DE_LIBERACION_INICIO, string FECHA_DE_LIBERACION_TERMINO,
            string MATERIAL_FINAL, string MATERIAL_INICIAL, string UserName)
        {
            return _stock.Listar_liberareservastrf(FECHA_DE_LIBERACION_INICIO, FECHA_DE_LIBERACION_TERMINO,
                MATERIAL_FINAL, MATERIAL_INICIAL, UserName);
        }

        public DataTable Listar_liberareservascon(string FECHA_FINAL, string FECHA_INICIAL, string UserName)
        {
            return _stock.Listar_liberareservascon(FECHA_FINAL, FECHA_INICIAL, UserName);
        }
    }
}
