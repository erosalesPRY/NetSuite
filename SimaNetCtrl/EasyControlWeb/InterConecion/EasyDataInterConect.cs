using EasyControlWeb.Filtro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq; 
using System.Text;
using System.Web.UI;
using static EasyControlWeb.Form.Editor.EasyFormColletionsEditor;

namespace EasyControlWeb.InterConeccion
{

   

    [TypeConverter(typeof(Type_DataInterConect))]
    [Serializable]
    public class EasyDataInterConect
    {
    public EasyDataInterConect() { }

        public enum MetododeConexion
        {
            WebServiceInterno,
            WebServiceExterno,
            PaginaASPX,
        }
        public EasyDataInterConect(string _UrlWebService,string _Metodo, List<EasyFiltroParamURLws> _UrlWebServicieParams) {
            this.UrlWebService= _UrlWebService;
            this.Metodo = _Metodo;
            this.easyParams = _UrlWebServicieParams;
        }
        public EasyDataInterConect(string _UrlWebService, string _Metodo)
        {
            this.UrlWebService = _UrlWebService;
            this.Metodo = _Metodo;
            this.easyParams = null;
        }


        private MetododeConexion metodoConexion;
        public MetododeConexion MetodoConexion {
            get { return metodoConexion; }
            set { metodoConexion=value; }
        }


        private string _UrlWebService;
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.All)]
        [NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
        public string UrlWebService
        {
            get { 
                return _UrlWebService; 
            } 
            set {
                _UrlWebService = value; 
                } 
        }
        private string _Metodo;
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.All)]
        [NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
        public string Metodo
        {
            get
            {
                return _Metodo;
            }
            set
            {
                _Metodo = value;
            }
        }
        //Campos para Seleccion de datos
        [Browsable(true)]
        private List<EasyFiltroParamURLws> easyParams;
        [Category("Behavior"),
        Description("Parámetros que utilizara el WebService/Metodo para procesar su ejecución"),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
        Editor(typeof(EasyFiltroCollectionParams), typeof(UITypeEditor)),
        PersistenceMode(PersistenceMode.InnerProperty)
        ]
        [RefreshProperties(RefreshProperties.All)]
        [NotifyParentProperty(true)]
        public List<EasyFiltroParamURLws> UrlWebServicieParams
        {
            get
            {
                if (easyParams == null) {
                    easyParams = new List<EasyFiltroParamURLws>();
                }
                return easyParams;
            }
        }



    }
}
