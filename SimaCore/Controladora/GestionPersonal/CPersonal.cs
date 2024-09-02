﻿using AccesoDatos.NoTransaccional.GestionPersonal;
using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionPersonal
{
    public class CPersonal
    {
        public DataTable Buscar(string TextFind, string UserName)
        {
            return (new PersonalNTAD()).Buscar(TextFind, UserName);
        }

        public DataTable BuscarTrabajadorContratista(string TextFind, string UserName)
        {
            return (new PersonalNTAD()).BuscarTrabajadorContratista(TextFind, UserName);
        }

        public BaseBE Detalle(string Id1, string UserName)
        {
            return (new PersonalNTAD()).Detalle(Id1, UserName);
        }
     }
}
