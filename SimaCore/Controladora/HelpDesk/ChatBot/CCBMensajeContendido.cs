﻿using AccesoDatos.Transaccional.HelpDesk.ChatBot;
using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.HelpDesk.ChatBot
{
    public  class CCBMensajeContendido
    {
        public string Inserta(BaseBE oBaseBE)
        {
            return (new CBMensajeContendidoTAD()).Inserta(oBaseBE);
        }
    }
}
