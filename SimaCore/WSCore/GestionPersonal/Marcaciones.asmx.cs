using Controladora.GestionPersonal;
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
    /// Descripción breve de Marcaciones
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Marcaciones : System.Web.Services.WebService
    {

        [WebMethod]
        public void RegistrarMarcaciones(string CodigoCia, string CodigoSuc, string NroIP, string NomDisp, string SenSid, string NroDNI, string FechaHora, string ChkTyp, string Msg)
        {
            MarcacionesBE oMarcacionesBE = new MarcacionesBE();
            oMarcacionesBE.CodigoCia = CodigoCia;
            oMarcacionesBE.CodigoSuc = CodigoSuc;
            oMarcacionesBE.NroIP = NroIP;
            oMarcacionesBE.NomDisp = NomDisp;
            oMarcacionesBE.SenSid = SenSid;
            oMarcacionesBE.NroDNI = NroDNI;
            oMarcacionesBE.FechaHora = FechaHora;
            oMarcacionesBE.ChkTyp = ChkTyp;
            oMarcacionesBE.Msg = Msg;

            CMarcaciones oCMarcaciones = new CMarcaciones();

            string iresult = oCMarcaciones.Inserta(oMarcacionesBE);
            //return oCMarcaciones.Inserta(oMarcacionesBE);
            Utilitario.Helper.Archivo.XMLinURL.TransaccionalAccesoDatos("1");


            //return oCMarcaciones.Inserta(oMarcacionesBE);
        }
    }
}
