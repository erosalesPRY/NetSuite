﻿using AccesoDatos.Estandar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.NoTransaccional.GestionProyecto
{ 
    public class AdquisicionesNTAD
    {
        private readonly IStandarProcedure _standarProcedure;

        public AdquisicionesNTAD(IStandarProcedure standarProcedure)
        {
            _standarProcedure = standarProcedure;
        }

        public DataTable Listar_det_gasto_pry_ot_pgmsu(string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            string packageName = "CONSULTA.PKG_PROYECTOS.SP_DET_GASTO_PRY_OT_PGMSU";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("V_CENTRO_OPERATIVO", V_CENTRO_OPERATIVO);
            parameters.Add("V_DIVISION", V_DIVISION);
            parameters.Add("V_PROYECTO", V_PROYECTO);
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