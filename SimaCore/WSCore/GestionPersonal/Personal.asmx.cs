using Controladora.GestionPersonal;
using EntidadNegocio;
using EntidadNegocio.GestionPersonal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WSCore.GestionPersonal
{
    /// <summary>
    /// Descripción breve de Personal
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Personal : System.Web.Services.WebService
    {

        [WebMethod(Description = "Permite buscar a una persona")]
        public DataTable BuscarPersona(string TextFind, string UserName)
        {
            return (new CPersonal()).Buscar(TextFind, UserName);
        }

        [WebMethod(Description = "Permite buscar a una personal contratista")]
        public DataTable BuscarTrabajadorContratista(string TextFind, string UserName)
        {
            return (new CPersonal()).BuscarTrabajadorContratista(TextFind, UserName);
        }

        [WebMethod(Description = "Se vizualiza el detalle de personal")]
        public PersonalUbicacionBE DetallePersonaUbicacion(int IdPersonal, string UserName)
        {
            return (PersonalUbicacionBE)(new CPersonal()).Detalle(IdPersonal.ToString(), UserName);
        }


        [WebMethod(Description = "Insertar Huella ")]
        public string LeeHuallaRelogInsertaInBD(string CodTrabajador, string IdHuella, string HuellaM1, string HuellaM2, int Version, int IdOrg,int IdEstado,int IdUsuario, string UserName)
        {
            ZKFingerBE oZKFingerBE = new ZKFingerBE();

            oZKFingerBE.CodTrabajador = CodTrabajador;
            oZKFingerBE.IdHuella = IdHuella;
            oZKFingerBE.HuellaM1 = HuellaM1;
            oZKFingerBE.HuellaM2 = HuellaM2;
            oZKFingerBE.Version = Version;
            oZKFingerBE.IdOrg = IdOrg;
            oZKFingerBE.IdEstado = IdEstado;
            oZKFingerBE.IdUsuario = IdUsuario;
            return (new CZKFinger()).ModificaInserta(oZKFingerBE);
        }
    }
}
