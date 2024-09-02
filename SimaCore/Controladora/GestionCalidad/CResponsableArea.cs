﻿using AccesoDatos.NoTransaccional.GestionCalidad;
using AccesoDatos.Transaccional.GestionCalidad;
using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionCalidad
{
    public class CResponsableArea
    {
        public DataTable ListarTodos(string Id1, string UserName)
        {
            return (new ResponsableAreaNTAD()).ListarTodos(Id1, UserName);
        }
        public string ModificaInserta(BaseBE oBaseBE)
        {
            return (new ResponsableAreaTAD()).ModificaInserta(oBaseBE);
        }
    }
}
