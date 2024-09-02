using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls; 
using System.Data;
using System.Security.Permissions;
using System.Drawing.Design;
using System.Web.UI.HtmlControls;
using System.Web.UI.Design;
using EasyControlWeb.Form.Controls;
using EasyControlWeb.Form.Templates;
using EasyControlWeb.InterConecion;
using System.Globalization;

/*
[assembly: TagPrefix("EasyGestorFiltro", "SIMA_CTRL")]
[assembly: WebResource("GenFiltro.gif", "image/")]
*/
namespace EasyControlWeb.Filtro
{
    
    [
        AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal),
        AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal),
        DefaultProperty("EasyFiltroCampos"),
        ParseChildren(true, "EasyFiltroCampos"),
        ToolboxData("<{0}:EasyGestorFiltro runat=server></{0}:EasyGestorFiltro")
    ]

   /* [
    ParseChildren(true, "Titulo"),
    ToolboxData("<{0}:EasyGestorFiltro runat=server></{0}:EasyGestorFiltro")
    ]
    */
    /*[Serializable]*/
    public class EasyGestorFiltro : CompositeControl
    {
        #region Constantes
            private const string ITEM_COLOR_SELECT = "ItemColorSelect";
            private const string ITEM_COLOR_MOUSEMOVE = "ItemColorMouseMove";
            private const string IMG_FILTRO_GRUPO = "ImgFiltroGrupo";

            private const string IMG_FILTRO_HEADER = "ImagenFiltroHead";
            private const string IMG_FILTRO_ADD = "ImagenFiltroAdd";
            private const string IMG_FILTRO_DEL = "ImagenFiltroDelete";
        #endregion

        #region Enumerados
        enum SubFijo
        {
            Crit,
            Gen
        }
        enum VariablesViewState
        {
            DataCriterios
        }
        public enum ModoEditFiltro
        {
            Delete,
            Add,
            Modify,
            ApplySoloItem
        }
      
        public enum eventJScript
        {
            onClick,
        }
        public enum MetodoBase
        {
            _OpenWinModal,
            _OnSelected,
        }

        const string cmll = "\"";
        const string bsl = @"\";
        #endregion


        //Eventos que completan la operacion de generar los criterios de filtros
        public delegate void FilterBound(string FiltroResultante, List<EasyControlWeb.Filtro.EasyFiltroItem> lstEasyFiltroItem);
        public event FilterBound ProcessCompleted;


        //Eventos que completan la operacion de generar los criterios de filtros
        public delegate void FilterItemCiterio(ModoEditFiltro Modo, EasyFiltroItem oEasyFiltroItem);
        public event FilterItemCiterio ItemCriterio;


        #region Declaraciones de objetos a ser usados
            Table tblBase;
            Table tblBaseGestor;
            Table tblSubCriterio;
            TableRow tr;
            TableCell tc;
 

            DropDownList ddlCriterio;
            DropDownList ddlOperador;
            DropDownList ddlCampo;
            List<Control> AllCtrlValue;
            TextBox txtIdFiltro;
            TextBox txtidFiltroDel;


            //boton para agregr menu
            HtmlImage oimgAdd;
            HtmlImage oImgSubItemAdd;
            HtmlImage oImagenDel;
            //
            System.Web.UI.HtmlControls.HtmlButton btnFAceptar;
            //para las 2 ventanas de filtos
            HtmlGenericControl wPopupCriterios;
            HtmlGenericControl wPopupGestor;
            HtmlGenericControl wPopupConfirmDelete;
            //para mensajes
            HtmlGenericControl aContext;
            //Boton por defecto
            HtmlButton btnInicio;
        //Boton de eliminacion de filtro
        HtmlButton btnDelete;

        string[,] strCriterio = new string[2, 9]{
                                      {"Contenga","Inicie con","Finalize con","Igual","No sea Igual","Mayor que","Menor que","Mayor o Igual que","Menor o Igual que" },
                                      {"LIKE @*[VALOR]*@","LIKE @*[VALOR]@","LIKE @[VALOR]*@","=@[VALOR]@","=@[VALOR@]",">@[VALOR]@","<@[VALOR]@",">=@[VALOR]@","<=@[VALOR]@"}
                                      };
        string[,] TitHeader = new string[3, 4] { { "OPERADOR", "CAMPO", "SIG COMPARACION", "VALOR"},
                                                { "ddlOperador", "ddlCampo", "ddlCriterio", "txtValor"},
                                                { "5%", "40%", "20%", "35%"}
                                               };

        string strValor = "";//Valor de nuevo criterio
        string strTexto = "";//texto de nuevo criterio
        //Para Almacenar los Script
        #region Objetos de Colleccion para los scripts en JS
        List<LiteralControl> CollecctionScript = new List<LiteralControl>();
        #endregion

      
        #endregion

        #region Nombre de control
        string IdCtrl;

        #endregion

        #region Propiedades
        
        public string Titulo
        {
            get
            {
                object val = this.ViewState["FiltroTitulo"];
                return (string)val;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value", "No se ha ingresado titulo alguno");

                this.ViewState["FiltroTitulo"] = value;
            }
        }
        public string ClassHeader
        {
            get
            {
                object val = this.ViewState["FiltroClaseHeader"];
                return (string)val;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value", "Establecer un valor de estilo para la cabecera");

                this.ViewState["FiltroClaseHeader"] = value;
            }
        }
        public string ClassItem
        {
            get
            {
                object val = this.ViewState["FiltroClaseItem"];
                return (string)val;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value", "Establecer un valor de estilo para la cabecera");

                this.ViewState["FiltroClaseItem"] = value;
            }
        }
        public string ClassItemAlternating
        {
            get
            {
                object val = this.ViewState["FiltroClaseItemAlternating"];
                return (string)val;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value", "Establecer un valor de estilo para la cabecera");

                this.ViewState["FiltroClaseItemAlternating"] = value;
            }
        }

       
        [Category("Appearance")]
        [Bindable(BindableSupport.No)]
        [DefaultValue("true")]
        public bool DisplayButtonInterface
        {
            get {
                if (this.ViewState["VerBotonFiltro"] == null)
                {
                    this.ViewState["VerBotonFiltro"] = true;
                }
                   return (bool)this.ViewState["VerBotonFiltro"]; 
            }
            set { this.ViewState["VerBotonFiltro"] = value; }
        }

        #region  Definicion de extensiones
        /*

        EasyGridExtended oEasyGridExt = new EasyGridExtended();
        [Category("Editor"), Description("Define el comportamiento de colores de cada fila"),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public EasyGridExtended EasyExtended
        {
            get
            {
                if (oEasyGridExt == null)
                {
                    oEasyGridExt = new EasyGridExtended();
                }
                return oEasyGridExt;
            }
            set
            {
                oEasyGridExt = value;
            }
        }
        */
        #endregion





        [Category("Appearance")]
        [Bindable(BindableSupport.No)]
        [DefaultValue("#ffcc66")]
        public string ItemColorSeleccionado
        {
            get
            {
                if (this.ViewState[ITEM_COLOR_SELECT] == null)
                {
                    this.ViewState[ITEM_COLOR_SELECT] = "#ffcc66";
                }
                return (string)this.ViewState[ITEM_COLOR_SELECT];
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value", "Establecer un valor de estilo para la cabecera");

                this.ViewState[ITEM_COLOR_SELECT] = value;
            }
        }
        [Category("Appearance")]
        [Bindable(BindableSupport.No)]
        [DefaultValue("")]
        public string ItemColorMouseMove
        {
            get
            {
                if (this.ViewState[ITEM_COLOR_MOUSEMOVE] == null)
                {
                    this.ViewState[ITEM_COLOR_MOUSEMOVE] = "#CDE6F7";
                }
                return (string)this.ViewState[ITEM_COLOR_MOUSEMOVE];
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value", "Establecer un valor de estilo para la cabecera");

                this.ViewState[ITEM_COLOR_MOUSEMOVE] = value;
            }
        }

        #endregion


    



        #region Para la lista de criterios


        //iMAGEN DE FILRO grupal
        [Category("Appearance")]
        [DefaultValue(true)]
        [Bindable(BindableSupport.No)]
        private List<EasyFiltroItem> easyCriterioList;

        [
        Category("Behavior"),
        Description("Coleccion de Criterios"),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
        Editor(typeof(EasyFiltroCollectionCriterio), typeof(UITypeEditor)),
        PersistenceMode(PersistenceMode.InnerDefaultProperty)
        ]
        public List<EasyFiltroItem> EasyFiltroItems
        {
            get
            {
                InicializaListaCtrl();
                return easyCriterioList;
            }
        }
      
        #endregion

        #region Para la lista de campos de bd
        private List<EasyFiltroCampo> easyCamposBDList;
        [
        Category("Behavior"),
        Description("Coleccion de campos"),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
        Editor(typeof(EasyFiltroCollectionCampo), typeof(UITypeEditor)),
        PersistenceMode(PersistenceMode.InnerDefaultProperty)
        ]
        public List<EasyFiltroCampo> EasyFiltroCampos
        {
            get
            {
                InicializaListaCtrl();
                return easyCamposBDList;
            }
        }

        #endregion

        


        #region Inicializa arrays
        void InicializaListaCtrl()
            {
                if (easyCriterioList == null)
                {
                    easyCriterioList = new List<EasyFiltroItem>();
                }

                if (easyCamposBDList == null)
                {
                    easyCamposBDList = new  List<EasyFiltroCampo>();
                }
            }
        #endregion
        void InicializaControles()
        {
          
            ddlOperador = new DropDownList();
            ddlOperador.ID = "ddlOperador";

            ddlOperador.Items.Add(new ListItem(" ", " "));
            ddlOperador.Items.Add(new ListItem("AND", "AND"));
            ddlOperador.Items.Add(new ListItem("OR", "OR"));

            //CAMPOS
            ddlCampo = new DropDownList();
            ddlCampo.ID = "ddlCampo";
            try
            {
                AllCtrlValue = new List<Control>();//Array en donde se guardaran los objeto para luego se pintados en el formulario
                if ((easyCamposBDList != null) && (easyCamposBDList.Count > 0))
                {
                    int NroCampos = easyCamposBDList.Count;
                    ddlCampo.Items.Add(new ListItem("[Seleccionar...]", " "));
                    string LstFields = "";
                    int idx = 0;
                   foreach (EasyFiltroCampo item in easyCamposBDList)
                    {
                         EasyFiltroCampo oEasyCampo = item as EasyFiltroCampo;
                        if (oEasyCampo != null)
                        {
                            string Describ = (((oEasyCampo.Descripcion.Replace(" ","") == null) ||(oEasyCampo.Descripcion.Replace(" ", "").Length == 0)) ? "[" + oEasyCampo.Nombre +"]" : oEasyCampo.Descripcion);
                            ddlCampo.Items.Add(new ListItem(Describ, oEasyCampo.Nombre));
                            //Creacion de los controles de campos valor
                            if (oEasyCampo.EasyControlAsociado.TemplateType.Equals("EasyITemplateTextBox"))
                            {
                                EasyITemplateTextBox oEasyITemplateTextBox = (EasyITemplateTextBox)oEasyCampo.EasyControlAsociado;
                                EasyTextBox oEasyTextBox = new EasyTextBox();
                                oEasyTextBox.Attributes["TemplateType"] = oEasyCampo.EasyControlAsociado.TemplateType;
                                oEasyTextBox.ID = oEasyCampo.Nombre;
                                oEasyTextBox.Attributes.Add("Placeholder", oEasyCampo.Descripcion);
                                oEasyTextBox.Attributes.Add("Nombre", oEasyCampo.Nombre);
                                oEasyTextBox.Attributes.Add("TipodeDato", oEasyCampo.TipodeDato.ToString());
                                AllCtrlValue.Add(oEasyTextBox);
                            }
                            else if (oEasyCampo.EasyControlAsociado.TemplateType.Equals("EasyITemplateDatepicker") )
                            {
                                EasyITemplateDatepicker ndpk= (EasyITemplateDatepicker)oEasyCampo.EasyControlAsociado;
                                EasyDatepicker oEasyDatepicker = new EasyDatepicker();
                                oEasyDatepicker.Attributes["TemplateType"] = oEasyCampo.EasyControlAsociado.TemplateType;
                                oEasyDatepicker.FormatInPut = ndpk.FormatInPut;
                                oEasyDatepicker.FormatOutPut = ndpk.FormatOutPut;
                                oEasyDatepicker.ID = oEasyCampo.Nombre;
                                oEasyDatepicker.Attributes.Add("Placeholder", oEasyCampo.Descripcion);
                                oEasyDatepicker.Attributes.Add("Nombre", oEasyCampo.Nombre);
                                oEasyDatepicker.Attributes.Add("TipodeDato", oEasyCampo.TipodeDato.ToString());
                                AllCtrlValue.Add(oEasyDatepicker);
                            }
                            else if (oEasyCampo.EasyControlAsociado.TemplateType.Equals("EasyITemplateNumericBox"))
                            {
                                EasyITemplateNumericBox nbox = (EasyITemplateNumericBox)oEasyCampo.EasyControlAsociado;
                                EasyNumericBox oEasyNumericBox = new EasyNumericBox();
                                oEasyNumericBox.Attributes["TemplateType"] = oEasyCampo.EasyControlAsociado.TemplateType;
                                oEasyNumericBox.ID = oEasyCampo.Nombre;
                                oEasyNumericBox.Attributes.Add("Placeholder", oEasyCampo.Descripcion);
                                oEasyNumericBox.Attributes.Add("Nombre", oEasyCampo.Nombre);
                                oEasyNumericBox.Attributes.Add("TipodeDato", oEasyCampo.TipodeDato.ToString());
                                AllCtrlValue.Add(oEasyNumericBox);

                            }
                            else if (oEasyCampo.EasyControlAsociado.TemplateType.Equals("EasyITemplateDropdownList"))
                            {
                                EasyITemplateDropdownList ddl = (EasyITemplateDropdownList)oEasyCampo.EasyControlAsociado;
                                EasyDropdownList oEasyDropdownList = new EasyDropdownList();
                                oEasyDropdownList.Attributes["TemplateType"] = oEasyCampo.EasyControlAsociado.TemplateType;
                                oEasyDropdownList.ID = oEasyCampo.Nombre;
                                oEasyDropdownList.DataTextField = ddl.TextField;
                                oEasyDropdownList.DataValueField = ddl.ValueField;
                                oEasyDropdownList.Attributes.Add("Placeholder", oEasyCampo.Descripcion);
                                oEasyDropdownList.Attributes.Add("Nombre", oEasyCampo.Nombre);
                                oEasyDropdownList.Attributes.Add("TipodeDato", oEasyCampo.TipodeDato.ToString());
                                int OrdParam = 0;
                                if ((oEasyCampo.DataInterconect.UrlWebServicieParams != null) && (oEasyCampo.DataInterconect.UrlWebServicieParams.Count>0)) {
                                    oEasyDropdownList.DataInterconect = oEasyCampo.DataInterconect;

                                    object[] args = new object[oEasyCampo.DataInterconect.UrlWebServicieParams.Count];

                                    foreach (EasyFiltroParamURLws oEasyFiltroParam in oEasyCampo.DataInterconect.UrlWebServicieParams) {
                                        string ParamValor = "";//Obtener el valor
                                        switch (oEasyFiltroParam.ObtenerValor)
                                        {
                                            case EasyFiltroParamURLws.TipoObtenerValor.Fijo:
                                                ParamValor = oEasyFiltroParam.Paramvalue;
                                                break;
                                            case EasyFiltroParamURLws.TipoObtenerValor.DinamicoPorURL:
                                                ParamValor = ((System.Web.UI.Page)HttpContext.Current.Handler).Request.Params[oEasyFiltroParam.Paramvalue];//Aqui el valor contenido es el nombre del parámetro
                                                break;
                                        }

                                        switch (oEasyFiltroParam.TipodeDato)//estabñlece el tipo del parámetro
                                        {

                                            case EasyUtilitario.Enumerados.TiposdeDatos.String: //EasyFiltroParamURLws.TiposdeDatos.String:
                                                args.SetValue(ParamValor, OrdParam);
                                                break;
                                            case EasyUtilitario.Enumerados.TiposdeDatos.Int:
                                                args.SetValue(Convert.ToInt32(ParamValor), OrdParam);
                                                break;
                                            case EasyUtilitario.Enumerados.TiposdeDatos.Date:
                                                args.SetValue(Convert.ToDateTime(ParamValor), OrdParam);
                                                break;
                                            case EasyUtilitario.Enumerados.TiposdeDatos.Double:
                                                args.SetValue(Convert.ToDouble(ParamValor), OrdParam);
                                                break;
                                        }
                                        OrdParam++;
                                    }
                                    /*args.SetValue(1, 0);
                                    args.SetValue(86, 1);
                                    args.SetValue("VACIO", 2);*/
                                    // DataTable dt = EasyWebServieHelper.InvokeWebService("http://localhost:8081/Seguridad/Seguridad.asmx", "", "GetOptionsByProfile", args) as DataTable;

                                  /*  DataTable dt = new DataTable();
                                     if (oEasyCampo.DataInterconect.MetodoConexion == InterConeccion.EasyDataInterConect.MetododeConexion.PaginaASPX)
                                     {
                                         dt = EasyWebServieHelper.InvokeWebService(oEasyCampo.DataInterconect.UrlWebService, "","", args) as DataTable;
                                     }
                                     else
                                     {
                                         dt = EasyWebServieHelper.InvokeWebService(oEasyCampo.DataInterconect.UrlWebService, "", oEasyCampo.DataInterconect.Metodo, args) as DataTable;
                                     }

                                     oEasyDropdownList.DataSource = dt;
                                     oEasyDropdownList.DataBind();
                                     */
                                    oEasyDropdownList.CargaInmediata = true;
                                    oEasyDropdownList.LoadData();

                                }

                                /*object[] args = new object[1];
                                args.SetValue("1", 0);
                                string pathApp= ((System.Web.UI.Page)HttpContext.Current.Handler).Request.ApplicationPath;
                                string url = "http://localhost" + pathApp + "/FiltrosOnSucced.asmx";
                                DataTable dt = EasyWebServieHelper.InvokeWebService(url, "", "Listar", args) as DataTable;
                                */
                                AllCtrlValue.Add(oEasyDropdownList);

                            }
                            else if (oEasyCampo.EasyControlAsociado.TemplateType.Equals("EasyITemplateAutoCompletar"))
                            {
                                EasyITemplateAutoCompletar acpl = (EasyITemplateAutoCompletar)oEasyCampo.EasyControlAsociado;
                                EasyAutocompletar oEasyAutocompletar = new EasyAutocompletar();
                                oEasyAutocompletar.Attributes["TemplateType"] = oEasyCampo.EasyControlAsociado.TemplateType;
                                oEasyAutocompletar.DisplayText = acpl.TextField;//Campos que muestra la busqueda
                                oEasyAutocompletar.ValueField = acpl.ValueField;//Campo disponible para se usado en el filtro
                                oEasyAutocompletar.fncTempaleCustom = acpl.fncTempaleCustom;
                                                                                //oEasyAutocompletar.DisplayText = oEasyCampo.Nombre;
                                                                                // oEasyAutocompletar.DisplayValue = acpl.ValueField;//Campo disponible para se usado en el filtro
                                oEasyAutocompletar.DataInterconect = oEasyCampo.DataInterconect;
                                oEasyAutocompletar.ID = oEasyCampo.Nombre;
                                oEasyAutocompletar.Attributes.Add("Placeholder", oEasyCampo.Descripcion);
                                oEasyAutocompletar.Attributes.Add("Nombre", oEasyCampo.Nombre);
                                oEasyAutocompletar.Attributes.Add("CtrlContext", this.ClientID + "_" + oEasyCampo.Nombre);
                                oEasyAutocompletar.Attributes.Add("TipodeDato", oEasyCampo.TipodeDato.ToString());
                                AllCtrlValue.Add(oEasyAutocompletar);
                            }

                            //LstFields += ((idx==0)?"":",") + oEasyCampo.ToString(true) ;
                            LstFields += ((idx == 0) ? "" : ",") + oEasyCampo.ToCliente();
                        }
                        idx++;
                    }
                    //**************************-----------SCRIPT-----------**********************************************              
                    ddlCampo.Attributes.Add("arrEasyCampo", "[" + LstFields + "]");
                    ddlCampo.Attributes.Add("onchange", this.ClientID.Replace("_","") + "_FindOpciones(this)");

                    RegistrarScriptSelectOpcion();
                }
            }
            catch (Exception ex) {
                //this.txtvalor.Text = ex.Message.ToString();
            }
                //criterios
                ddlCriterio = new DropDownList();
                ddlCriterio.ID = "ddlCriterio";
                int lengh = strCriterio.GetLength(1);
                ddlCriterio.Items.Add(new ListItem("[Seleccionar]", " "));
                for (int C = 0; C <= lengh - 1; C++)
                {
                    ListItem lItemCriterio = new ListItem(strCriterio[0, C], strCriterio[1, C]);
                    //lItemCriterio.Attributes["style"] = "display:none";
                    ddlCriterio.Items.Add(lItemCriterio);
                }
        }


        void RegistrarScriptSelectOpcion()
        {
            //IdCtrl = ((this.ClientID == null) ? this.ID : this.ClientID.Replace("_", ""));
            IdCtrl = this.ClientID.Replace("_", "");
            /*----------------------------------------------------------------------------------*/
            string ScripOnSelect = "function " + IdCtrl + @"_FindOpciones(e){
                                            var arrEasyCampo = eval(e.getAttribute(" + cmll + "arrEasyCampo" + cmll + @"));
                                                arrEasyCampo.forEach(function(oEasyCampoBE) {
                                                                        var strNombreFila = '" + this.ClientID + @"_tr_' + oEasyCampoBE.Nombre;
                                                                        if (oEasyCampoBE.Nombre == $(e).val()) {
                                                                            $('#' + strNombreFila).show();//Muestra la fila con el control segun el campo seleccionado

                                                                             var ddlCriterio = jNet.get('" + this.ClientID + @"_ddlCriterio');
                                                                                 for(var i=1;i<= ddlCriterio.options.length-1;i++){
                                                                                     ddlCriterio.options[i].style['display']='block';
                                                                                 }
                                                                              var arrNotCrit = oEasyCampoBE.NotCriterio.split(',')
                                                                              arrNotCrit.forEach(function(value,idx){
                                                                                                    var position = (parseInt(value)+1);
                                                                                                    ddlCriterio.options[position].style['display']='none';
                                                                                                }                                                                                
                                                                              );

                                                                        }
                                                                        else{
                                                                            $('#' + strNombreFila).hide();//Oculta la fila que sean diferentes al campo seleccionado
                                                                        }
                                                });
                                            
                                           
                                    }";

            /*-----------------------------------------------------------------------------------*/
            CollecctionScript.Add(new LiteralControl("<script>\n" + ScripOnSelect + "</script>"));
          
        }


        void CrearTablaParaGeneradordeCriterios(){
            string MetodoScript = this.ClientID.Replace("_","") + MetodoBase._OpenWinModal.ToString();
            try
            {
                tblBase = new Table();
                tblBase.ID = "tblCriterio";
                tblBase.Attributes.Add("ItemColorSeleccionado", ItemColorSeleccionado);
                tblBase.Attributes.Add("ItemColorMouseMove", ItemColorMouseMove);

                tr = new TableRow();
                tc = new TableCell();
                //Toolbar para los criterios de filtro
                tc.ColumnSpan = 6;
                oimgAdd = new HtmlImage();
                oimgAdd.Src = EasyUtilitario.Constantes.ImgDataURL.IconFiltroAdd;//this.ImagenFiltroAdd;
                string NombreWinGen = this.ClientID + "_Gen";//no debe de ser reemplzado el guion
                oimgAdd.Attributes.Add("onclick", MetodoScript + "('" + NombreWinGen + "');");
                tc.Controls.Add(oimgAdd);
                tc.Attributes.Add("align", "Right");
                tr.Controls.Add(tc);
                tblBase.Controls.Add(tr);

                tr = new TableRow();
                tr.Height = 35;
                tr.CssClass = this.ClassHeader;
                int lengh = TitHeader.GetLength(1);
                for (int c = 0; c <= lengh - 1; c++)
                {
                    tc = new TableCell();
                    tc.Text = TitHeader[0, c].Replace("OPERADOR","OPER");
                    tc.Attributes.Add("width",TitHeader[2, c]);
                    tr.Controls.Add(tc);
                }

                tc = new TableCell();
                tc.Text = "AF";
                tr.Controls.Add(tc);
                tblBase.Controls.Add(tr);

                tc = new TableCell();
                tc.Text = "DF";
                tr.Controls.Add(tc);
                tblBase.Controls.Add(tr);

                //tblBase.Attributes.Add("border", "0px");
                tblBase.Attributes.Add("width", "100%");
             
                //listado de filtros elaborados si lo hubiera
                ViewCriteriosGenerados();

                this.Controls.Add(tblBase);//Aplicar aqui el manejo de cada atributo
                
                //tblBase.Attributes.Add("border", "3px");
                tblBase.CssClass = this.CssClass;//"table table-dark";

            }
            catch (Exception ex)
            {
                this.Controls.Add(new LiteralControl(ex.Message.ToString()));
            }
        }
        public void setCollectionCriterios(List<EasyFiltroItem> lstEasyFiltroItem)
        {
            this.ViewState[VariablesViewState.DataCriterios.ToString()]= lstEasyFiltroItem;
        }

        public List<EasyFiltroItem> getCollectionCriterios() {
            List<EasyFiltroItem> lstEasyFiltroItem = (List<EasyFiltroItem>)this.ViewState[VariablesViewState.DataCriterios.ToString()];
            return lstEasyFiltroItem;
        }

        void ViewCriteriosGenerados() {
            string cmll = EasyUtilitario.Constantes.Caracteres.ComillaDoble;
            string MetodoScript = this.ClientID.Replace("_", "") + MetodoBase._OpenWinModal.ToString();
            List<EasyFiltroItem> lstEasyFiltroItem = getCollectionCriterios();
            if ((lstEasyFiltroItem != null) && (lstEasyFiltroItem.Count > 0))
            {
                //Eliminar Todas la filas de la tabla general
                int NroItems = tblBase.Rows.Count;
                for (int r = 2; r < NroItems; r++)
                {
                    if (r >= 2)
                    {
                        tblBase.Rows.RemoveAt(2);
                    }
                }
             
                NroItems = 0;
                foreach (EasyFiltroItem oEasyFiltroItem in lstEasyFiltroItem)
                {
                    tr = new TableRow();
                    tr = CrearRowCriterio();
                    if (oEasyFiltroItem.IdPadre != "0")
                    {
                        tr.Cells[0].Text = "";
                        tr.Cells[1].Controls.Add(CrearSubFiltro(oEasyFiltroItem));
                        tr.Cells[3].ColumnSpan = 2;
                        tr.Cells[4].Visible = false;
                    }
                    else
                    {
                        tr.Cells[0].Text = oEasyFiltroItem.Operador;
                        tr.Cells[1].Text = oEasyFiltroItem.CampoDescripcion;
                        if (oEasyFiltroItem.NroHijos > 0)
                        {
                            oImgSubItemAdd = new HtmlImage();
                            oImgSubItemAdd.Src = EasyUtilitario.Constantes.ImgDataURL.IconFiltroGrupo;//this.ImagenFitroGrupo;
                            tr.Cells[0].Controls.Add(oImgSubItemAdd);
                            tr.Cells[1].Text = oEasyFiltroItem.Operador + " " + oEasyFiltroItem.CampoDescripcion;

                            tr.Cells[2].Style.Add("text-transform", "uppercase");
                            tr.Cells[3].Style.Add("text-transform", "uppercase");
                        }

                        tr.Cells[1].Style.Add("text-transform", "uppercase");
                        //imagen de sub filtro
                        oImgSubItemAdd = new HtmlImage();
                        oImgSubItemAdd.Src = EasyUtilitario.Constantes.ImgDataURL.IconFiltroAdd;
                        string NombreWinGen = this.ClientID.Replace("_", "") + "_Gen";
                        oImgSubItemAdd.Attributes.Add(eventJScript.onClick.ToString(), MetodoScript + "('" + NombreWinGen + "','" + oEasyFiltroItem.Id + "','" + oEasyFiltroItem.Campo + "');");
                        tr.Cells[4].Controls.Add(oImgSubItemAdd);

                    }
                    tr.Cells[2].Text = oEasyFiltroItem.CriterioDescripcion;
                    tr.Cells[3].Text = (((oEasyFiltroItem.TemplateType== "EasyITemplateDropdownList") ||(oEasyFiltroItem.TemplateType == "EasyITemplateAutoCompletar") || (oEasyFiltroItem.TemplateType == "EasyITemplateDatepicker")) ? oEasyFiltroItem.TextField :  oEasyFiltroItem.ValueField);

                    oImagenDel = new HtmlImage();
                    oImagenDel.Src = EasyUtilitario.Constantes.ImgDataURL.IconFiltroDelete;
                    string onSeleted = this.ClientID.Replace("_", "") + MetodoBase._OnSelected.ToString() + "(" + oEasyFiltroItem.ToString(true) + ");";
                    oImagenDel.Attributes.Add("onclick", onSeleted);
                    tr.Cells[5].Controls.Add(oImagenDel);

                    if (Mod(NroItems, 2) == 0)
                    {
                        tr.CssClass = this.ClassItem;
                    }
                    else
                    {
                        tr.CssClass = this.ClassItemAlternating;
                    }

                    //Eventos de lado del Cliente
                    tr.Attributes.Add("onmouseover", "SIMA.GridView.Extended.OnEventMouseInOutChangeColor(this, true);");
                    tr.Attributes.Add("onmouseout", "SIMA.GridView.Extended.OnEventMouseInOutChangeColor(this, false);");

                    //tr.Attributes.Add("onclick", "SIMA.GridView.Extended.OnEventClickChangeColor(this);" + onSeleted);
                    tr.Attributes.Add("onclick", "SIMA.GridView.Extended.OnEventClickChangeColor(this);");
                    NroItems++;
                    //Agrega la fila creada  al a tabla

                    tblBase.Controls.Add(tr);

                }
            }
            else {
                if (tblBase.Rows.Count >= 3) { tblBase.Rows.RemoveAt(2); }
            }
        }


        HtmlGenericControl CrearBarradeFiltros() {
            string onSeleted = this.ClientID.Replace("_", "") + MetodoBase._OnSelected.ToString();//Nombre del metodo relaciodo para eliminar un filtro
            //string onSeleted = this.ClientID.Replace("_", "") + "_OnDelete";//Nombre del metodo relaciodo para eliminar un filtro

            HtmlGenericControl dvToolBarFilter = EasyUtilitario.Helper.HtmlControlsDesign.CrearControl("div");
            dvToolBarFilter.ID = this.ClientID +  "_BarraFiltro";
            dvToolBarFilter.Attributes.Add("class", "form-multi-select form-multi-select-multiple form-multi-select-selection-tags form-multi-select-with-cleaner show");
            dvToolBarFilter.Style.Add("font-weight", "bold");
            dvToolBarFilter.Style.Add("display", "none");
            dvToolBarFilter.Style.Add("overflow-x","auto");
            dvToolBarFilter.Style.Add("overflow-y","hidden");

            List <EasyFiltroItem> lstEasyFiltroItem;
            lstEasyFiltroItem = new List<EasyFiltroItem>();
           
            if (this.ViewState[VariablesViewState.DataCriterios.ToString()] != null)
            {
                lstEasyFiltroItem = getCollectionCriterios();
                List<EasyFiltroItem> LstItemPrincipal = lstEasyFiltroItem.Where(item => item.IdPadre == "0" && item.Definitivo==true).ToList();
                foreach (EasyFiltroItem itemPrincipal in LstItemPrincipal)
                {

                    if (itemPrincipal.NroHijos > 0)
                    {
                        dvToolBarFilter.Controls.Add(new LiteralControl(itemPrincipal.Operador));

                        HtmlGenericControl MultiSelected = EasyUtilitario.Helper.HtmlControlsDesign.CrearControl("span", "form-multi-select-selection");
                        MultiSelected.Style.Add("border-color", "red");
                        MultiSelected.Style.Add("border-style", "dotted");
                        MultiSelected.Style.Add("border-width", "1px");
                        MultiSelected.Style.Add("border-radius", ".25rem");

                        MultiSelected.Controls.Add(itemPrincipal.Render(EasyFiltroItem.btnTipo.CampoyValor, this.ClientID, onSeleted));

                        List<EasyFiltroItem> LstItemChild = lstEasyFiltroItem.Where(item => item.IdPadre == itemPrincipal.Id && item.Definitivo == true).ToList();
                        foreach (EasyFiltroItem ItemChild in LstItemChild)
                        {
                            if (itemPrincipal.Campo == ItemChild.Campo)
                            {
                                MultiSelected.Controls.Add(new LiteralControl(ItemChild.Operador));
                                MultiSelected.Controls.Add(ItemChild.Render(EasyFiltroItem.btnTipo.Valor, this.ClientID, onSeleted));
                            }
                            else {
                                MultiSelected.Controls.Add(new LiteralControl(ItemChild.Operador));
                                MultiSelected.Controls.Add(ItemChild.Render(EasyFiltroItem.btnTipo.CampoyValor, this.ClientID, onSeleted));
                            }
                           
                        }
                        dvToolBarFilter.Controls.Add(MultiSelected);
                    }
                    else
                    {
                        dvToolBarFilter.Controls.Add(new LiteralControl(itemPrincipal.Operador));
                        dvToolBarFilter.Controls.Add(itemPrincipal.Render(EasyFiltroItem.btnTipo.CampoyValor, this.ClientID, onSeleted));
                    }
                }
            }
            return dvToolBarFilter;
        }


        TableRow CrearRowCriterio() {
            TableRow _tr = new TableRow();
            int Columnas = (TitHeader.GetLength(1)+2);
            for (int c=0;c<= Columnas; c++)
            {
                TableCell _cell = new TableCell();
                _cell.Attributes.Add("align", "left");
                _tr.Controls.Add(_cell);
            }
            _tr.Height = 25;
            return _tr;
        }

        decimal Mod(int Nro, int nbase) {
            decimal r = (decimal)Nro;
            decimal resultado = (r / nbase) % nbase;
            return resultado;
        }
        Table CrearSubFiltro(EasyFiltroItem oEasyFiltroItemBE) {
            tblSubCriterio = new Table();
            TableRow trs = new TableRow();
            TableCell tcs = new TableCell();
            tcs.Attributes.Add("width", "10%");
            tcs.Text = oEasyFiltroItemBE.Operador;
            trs.Controls.Add(tcs);
            tcs = new TableCell();
            tcs.Attributes.Add("width", "90%");
            tcs.Attributes.Add("align", "left");
                                
            tcs.Text = oEasyFiltroItemBE.CampoDescripcion;
            trs.Controls.Add(tcs);

            tblSubCriterio.Controls.Add(trs);

            //tblSubCriterio.Attributes.Add("border", "5px");
            tblSubCriterio.Attributes.Add("width", "100%");
            return tblSubCriterio;
        }

        void CrearTablaParaGeneradordeFiltro()
        {
            tblBaseGestor = new Table();
           // tblBaseGestor.Attributes.Add("border","2px");
            tblBaseGestor.Style.Add("width", "100%");

            int lengh = TitHeader.GetLength(1);
            for (int c = 0; c <= lengh - 1; c++)
            {
                tr = new TableRow();
                tc = new TableCell();
                tc.Attributes.Add("width", "20%");
                
                HtmlGenericControl dv = new HtmlGenericControl("div");
                dv.Attributes.Add("class", "form-group");
                HtmlGenericControl lbl = new HtmlGenericControl("label");
                lbl.InnerText= TitHeader[0, c];
                dv.Controls.Add(lbl);
                tc.Controls.Add(dv);
                tr.Controls.Add(tc);

                tc = new TableCell();
                tc.Attributes.Add("width", "70%");
                string NomCtrl = TitHeader[1, c];
                switch (c) {
                    case 0:
                        ddlOperador.Attributes.Add("class","form-control form-control-sm");
                        tc.Controls.Add(ddlOperador);
                        break;
                    case 1:
                        ddlCampo.Attributes.Add("class", "form-control form-control-sm");
                        tc.Controls.Add(ddlCampo);
                        break;
                    case 2:
                        ddlCriterio.Attributes.Add("class", "form-control form-control-sm");
                        tc.Controls.Add(ddlCriterio);
                        break;
                    case 3:
                        Table tblField = new Table();
                        //tblField.Attributes.Add("border", "3px");
                        TableRow trField;
                        TableCell tcField;
                        //Crea los controles segun su camporelacionado
                        string attCampo = "";
                        foreach (object ctrl in AllCtrlValue) {
                            dv = new HtmlGenericControl("div");
                            dv.Attributes.Add("class", "form-group");
                            if (ctrl.GetType() == typeof(EasyTextBox))
                            {
                                EasyTextBox txtv = (EasyTextBox)ctrl;
                                txtv.Attributes.Add("class", "form-control");
                                txtv.Style.Add("width", "100%");
                                txtv.Attributes.Add("autocomplete", "off");
                                dv.Controls.Add(txtv);
                                attCampo = txtv.Attributes["Nombre"];
                            }
                            else if (ctrl.GetType() == typeof(EasyDatepicker))
                            {
                                EasyDatepicker dp = (EasyDatepicker)ctrl;
                                dp.Attributes.Add("autocomplete", "off");
                                dp.Attributes.Add("class", "form-control");
                                dp.Style.Add("width", "100%");
                                dv.Controls.Add(dp);
                                attCampo = dp.Attributes["Nombre"];
                            }
                            else if (ctrl.GetType() == typeof(EasyNumericBox))
                            {
                                EasyNumericBox nb = (EasyNumericBox)ctrl;
                                nb.Attributes.Add("autocomplete", "off");
                                nb.Attributes.Add("class", "form-control");
                                nb.Style.Add("width", "100%");
                                dv.Controls.Add(nb);
                                attCampo = nb.Attributes["Nombre"];
                            }
                            else if (ctrl.GetType() == typeof(EasyDropdownList))
                            {
                                EasyDropdownList ddl = (EasyDropdownList)ctrl;
                                ddl.Attributes.Add("class", "form-control");
                                ddl.Style.Add("width", "100%");
                                dv.Controls.Add(ddl);
                                attCampo = ddl.Attributes["Nombre"];
                            }
                            else if (ctrl.GetType() == typeof(EasyAutocompletar))
                            {
                                EasyAutocompletar aCPL = (EasyAutocompletar)ctrl;
                                aCPL.Attributes.Add("autocomplete", "off");
                                aCPL.Attributes.Add("class", "form-control");
                                aCPL.Style.Add("width", "100%");
                                dv.Controls.Add(aCPL);
                                attCampo = aCPL.Attributes["Nombre"];
                            }
                            tcField = new TableCell();
                            tcField.Controls.Add(dv);
                            tcField.Style.Add("width", "100%");
                            trField = new TableRow();
                            trField.ID = "tr_" + attCampo;
                            trField.Style.Add("display", "none");
                            trField.Controls.Add(tcField);
                            tblField.Controls.Add(trField);
                        }
                        tblField.Style.Add("width", "100%");
                        tc.Controls.Add(tblField);

                        break;
                }
               
                tr.Controls.Add(tc);
                tc = new TableCell();
                tc.Attributes.Add("width", "10%");
                tc.Style.Add("color", "red");
                // tc.Text = c.ToString();
                tr.Controls.Add(tc);
                tblBaseGestor.Controls.Add(tr);
              
            }
            tr = new TableRow();
            tc = new TableCell();
            tc.ColumnSpan = 3;
            aContext = new HtmlGenericControl("div");
            aContext.Attributes.Add("class", "warning");
            aContext.Style.Add("display", "none");
            tc.Controls.Add(aContext);
            tr.Controls.Add(tc);
            tblBaseGestor.Controls.Add(tr);

            string cmll = "\"";
            string javaScript =
              "function " + this.ClientID.Replace("_", "") + MetodoBase._OpenWinModal.ToString() + "(NombreWindow, IdFiltroSelect, NombreCampo){\n"
                 + "        $(" + cmll + "#" + this.ClientID + "_txtIdSelect" + cmll + ").val(0);" + "\n"
                 + "        if (NombreCampo != undefined){" + "\n"
                 + "            $( " + cmll + "#" + this.ClientID + "_ddlCampo" + cmll + ").val(NombreCampo);" + "\n"
                 + "               " + this.ClientID.Replace("_", "") + "_FindOpciones(document.getElementById('" + this.ClientID + "_ddlCampo" + "'));\n"
                 + "            $(" + cmll + "#" + this.ClientID + "_txtIdSelect" + cmll + ").val(IdFiltroSelect + '@' + NombreCampo);" + "\n"
                 + "        }" + "\n"
                 + "    $(" + cmll + "#" + cmll + " + NombreWindow).modal();" + "\n"
                + "}" + "\n";

            string txtIdDel = this.ClientID.Replace("_", "") + "_txtIdCriterioDel";
            String onSelect = "function " + this.ClientID.Replace("_", "") + MetodoBase._OnSelected.ToString() + "(EasyFiltroItemBE){" + "\n"
                              + "    $(" + cmll + "#" + txtIdDel + cmll + ").val(EasyFiltroItemBE.Id);" + "\n"
                                + @"  $.confirm({title: 'Desea eliminar este filtro ahora?',
                                                            content: null,
                                                            icon: 'fa fa-filter fa fa-chain-broken',
                                                            animation: 'scale',
                                                            closeAnimation: 'scale',
                                                            opacity: 0.5,
                                                            buttons:
                                                                    {'confirm': {
                                                                                    text: 'Aceptar',
                                                                                    btnClass: 'btn-blue',
                                                                                    action: function() {
                                                                                                      __doPostBack('" + this.ClientID.Replace("_", "") + @"$Delete','" + ModoEditFiltro.Delete.ToString() + "@'" + @" + EasyFiltroItemBE.Id);
                                                                                                }
                                                                                    },
                                                                                    cancel: function() {},
                                                                                    }
                                                                    });"

                              + "}" + "\n";

            CollecctionScript.Add(new LiteralControl("<script>\n" + javaScript + "\n" + onSelect + "</script>"));

           

            String onFiltroOnlyItem = "function " + this.ClientID.Replace("_", "") + "ApplyItemSelect(EasyFiltroItemBE){" + "\n"
                              + "    $(" + cmll + "#" + txtIdDel + cmll + ").val(EasyFiltroItemBE.Id);" + "\n"
                                + @"  $.confirm({title: 'Desea Aplicar solo este FILTRO ahora?',
                                                            content: null,
                                                            icon: 'fa fa-filter',
                                                            animation: 'scale',
                                                            closeAnimation: 'scale',
                                                            opacity: 0.5,
                                                            buttons:
                                                                    {'confirm': {
                                                                                    text: 'Aceptar',
                                                                                    btnClass: 'btn-blue',
                                                                                    action: function() {
                                                                                                      __doPostBack('" + this.ClientID.Replace("_", "") + @"$Delete','"+ ModoEditFiltro.ApplySoloItem.ToString() + "@'" + @" + EasyFiltroItemBE.Id);
                                                                                                }
                                                                                    },
                                                                                    cancel: function() {},
                                                                                    }
                                                                    });"

                              + "}" + "\n";

            CollecctionScript.Add(new LiteralControl("<script>\n" + javaScript + "\n" + onFiltroOnlyItem + "</script>"));



        }

        HtmlGenericControl CrearWindowsPopup(Table tbl,string Subfijo) {
            string MiId=this.ClientID.Replace("_", "");
            HtmlGenericControl ModalBody = new HtmlGenericControl("div");
            ModalBody.Attributes.Add("class", "modal-body");
          //  ModalBody.Style.Add("width", "980px");
            ModalBody.Controls.Add(tbl);
            /*-----------------------------------------------------------------*/
            HtmlGenericControl H5Titulo = new HtmlGenericControl("div");
            H5Titulo.Attributes.Add("class", "modal-title");
            H5Titulo.ID = "Title" + '_' + Subfijo;
            if (Subfijo == SubFijo.Crit.ToString())
            {
                H5Titulo.InnerText = this.Titulo;
            }
            else {
                HtmlImage oimg = new HtmlImage();
                oimg.Src = EasyUtilitario.Constantes.ImgDataURL.IconFiltroGen;
                Table tbltit = new Table();
                TableRow trow = new TableRow();
                TableCell tcell = new TableCell();
                tcell.Controls.Add(oimg);
                trow.Controls.Add(tcell);
                tcell = new TableCell();
                tcell.Text = "ELABORAR FILTRO";
                trow.Controls.Add(tcell);
                tbltit.Controls.Add(trow);
                H5Titulo.Controls.Add(tbltit);
            }
            /*-----------------------------------------------------------------*/
            HtmlGenericControl Mispan = new HtmlGenericControl("span");
            Mispan.Attributes.Add("aria-hidden", "true");
            Mispan.InnerHtml = "&times;";
            /*-----------------------------------------------------------------*/
            HtmlButton btnClose = new HtmlButton();
            btnClose.Attributes.Add("class", "close");
            btnClose.Attributes.Add("data-dismiss", "modal");
            btnClose.Attributes.Add("aria-label", "Close");
            btnClose.Controls.Add(Mispan);
            /*-----------------------------------------------------------------*/
            HtmlGenericControl ModalHeader = new HtmlGenericControl("div");
            ModalHeader.Attributes.Add("class", "modal-header");
            ModalHeader.Controls.Add(H5Titulo);
            ModalHeader.Controls.Add(btnClose);
            /*-----------------------------------------------------------------*/

            /*-----------------------------------------------------------------*/
            HtmlButton btnFClose = new HtmlButton();
            btnFClose.Attributes.Add("class", "btn btn-secondary");
            btnFClose.Attributes.Add("data-dismiss", "modal");
            btnFClose.InnerText = "Cerrar";

            btnFAceptar = new HtmlButton();
            btnFAceptar.InnerText = "Aceptar";
            btnFAceptar.ID = "btn_" + Subfijo;
            btnFAceptar.Attributes.Add("class", "btn btn-primary");
            if (Subfijo == SubFijo.Gen.ToString())
            {
                btnFAceptar.Attributes.Add("runat", "server");
                //btnFAceptar.Attributes.Add("data-dismiss", "modal");
            }
            else {
                btnFAceptar.Attributes.Add("runat", "server");
            }
            btnFAceptar.ServerClick += new System.EventHandler(EasyFiltro_Click);
            /*-----------------------------------------------------------------*/
            //footer
            HtmlGenericControl Modalfooter = new HtmlGenericControl("div");
            Modalfooter.Attributes.Add("class", "modal-footer");
            Modalfooter.Controls.Add(btnFAceptar);
            Modalfooter.Controls.Add(btnFClose);
            
            /*-----------------------------------------------------------------*/
            //< div class="modal-content">
            HtmlGenericControl Modalcontent = new HtmlGenericControl("div");
            Modalcontent.Attributes.Add("class", "modal-content");
            Modalcontent.Controls.Add(ModalHeader);
            Modalcontent.Controls.Add(ModalBody);
            Modalcontent.Controls.Add(Modalfooter);

            /*-----------------------------------------------------------------*/
            HtmlGenericControl ModalDialog = new HtmlGenericControl("div");
            if (Subfijo == SubFijo.Crit.ToString())
            {
                //ModalDialog.Attributes.Add("class", "modal-dialog modal-lg modal-dialog-centered");
                ModalDialog.Attributes.Add("class", "modal-dialog modal-lg modal-dialog-scrollable");
            }
            else {
                //ModalDialog.Attributes.Add("class", "modal-dialog modal-dialog-scrollable");
                ModalDialog.Attributes.Add("class", "modal-dialog");
            }
            ModalDialog.Attributes.Add("role", "document");
            ModalDialog.Controls.Add(Modalcontent);

            /*-----------------------------------------------------------------*/
            HtmlGenericControl ModalFade = new HtmlGenericControl("div");
            ModalFade.Attributes.Add("class", "modal fade");
            ModalFade.Attributes.Add("tabindex", "-1");
            ModalFade.Attributes.Add("role", "dialog");
            ModalFade.Attributes.Add("aria-labelledby", MiId + "_Title" + '_' + Subfijo);
            ModalFade.Attributes.Add("aria-hidden", "true");
            ModalFade.ID =  Subfijo ;
            ModalFade.Controls.Add(ModalDialog);
            
       
            return ModalFade;
        }

     
        protected override void CreateChildControls()
        {
      
            Controls.Clear();
            this.InicializaControles();

            this.CrearTablaParaGeneradordeCriterios();
            this.CrearTablaParaGeneradordeFiltro();
    
            wPopupCriterios = CrearWindowsPopup(tblBase, SubFijo.Crit.ToString());
            this.Controls.Add(wPopupCriterios);

            wPopupGestor = CrearWindowsPopup(tblBaseGestor, SubFijo.Gen.ToString());
            this.Controls.Add(wPopupGestor);

            /*wPopupConfirmDelete = WindowsConfirm();
            this.Controls.Add(wPopupConfirmDelete);*/

            btnDelete = new HtmlButton();
            btnDelete.ID = "Delete";
            btnDelete.Attributes.Add("class", "btn btn-danger");
            btnDelete.Style.Add("display", "none");
            btnDelete.InnerText = "Eliminar";
            btnDelete.Attributes.Add("runat", "server");
            btnDelete.ServerClick += new System.EventHandler(EasyFiltro_Click);
            this.Controls.Add(btnDelete);

            txtidFiltroDel = new TextBox();
            txtidFiltroDel.ID = "txtIdCriterioDel";
            txtidFiltroDel.Style.Add("display", "NONE");
            this.Controls.Add(txtidFiltroDel);


            //Control visible para autoinvocarse
            btnInicio = new HtmlButton();
            btnInicio.InnerText = "Elaborar Filtro";

            btnInicio.Attributes.Add(eventJScript.onClick.ToString(), this.ClientID.Replace("_", "") + "_Init();");

            btnInicio.Attributes.Add("type","button");

            txtIdFiltro = new TextBox();
            txtIdFiltro.ID = "txtIdSelect";
            txtIdFiltro.Style.Add("display", "none");
            this.Controls.Add(txtIdFiltro);

        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (!DesignMode)
            {
                wPopupCriterios.RenderControl(writer);
                wPopupGestor.RenderControl(writer);
                btnDelete.RenderControl(writer);
                // wPopupConfirmDelete.RenderControl(writer);
                //Toolbar de filtros

                CrearBarradeFiltros().RenderControl(writer);

                string idCli = this.ClientID.Replace("_", "");
                string winCriterio = idCli + "_OpenWinModal('" + idCli + "_" + SubFijo.Crit.ToString() + "' );";
                string winGenerador = idCli + "_OpenWinModal('" + idCli + "_" + SubFijo.Gen.ToString() + "'); ";

                string fncIni = "";
               /* List<EasyFiltroItem> lstEasyFiltroItem = getCollectionCriterios();
                if ((lstEasyFiltroItem != null) && (lstEasyFiltroItem.Count > 0))
                {*/
                    fncIni = @"function " + idCli + @"_Init(){
                            " + winCriterio + winGenerador + @"
                          }";
                /*}
                else
                {
                    fncIni = @"function " + idCli + @"_Init(){
                            " + winCriterio + @"
                          }";
                }*/
                CollecctionScript.Add(new LiteralControl("<script>\n" + fncIni + "</script>"));




                /******-------Creacion de los Script en la pagina--------*******/
                foreach (LiteralControl lcScript in CollecctionScript)
                {
                    lcScript.RenderControl(writer);
                }
            }
            else//if (this.DisplayButtonInterface)
            {
                btnInicio.RenderControl(writer);
            }
            txtIdFiltro.RenderControl(writer);
        }

        bool VerificaSelecciondeCriterios(int NroFiltros) {
            strValor = "";
            bool retorno = true;
            TableRow trAlert;
            ListItem itemCtrl;
            itemCtrl = new ListItem();
            itemCtrl = ddlOperador.SelectedItem;
            Control parent;

            parent = ddlOperador.Parent.Parent;
            trAlert = (TableRow)parent;
            if (NroFiltros > 0) {

                if (itemCtrl.Value == " ")
                {
                    trAlert.Cells[2].Text = "*";
                    retorno = false;
                }
                else {
                    trAlert.Cells[2].Text = "";
                    retorno = true;

                }
            }
            else {
                trAlert.Cells[2].Text = "";
                retorno = true;
            }
                //Verifica el ddl campo
                itemCtrl = ddlCampo.SelectedItem;
                parent = ddlCampo.Parent.Parent;
                trAlert = (TableRow)parent;
                if (itemCtrl.Value == " ")
                {
                    trAlert.Cells[2].Text = "*";
                    retorno = ((retorno == true) ? false : retorno);
                }
                else {
                    trAlert.Cells[2].Text = "";
                }
                //Verifica el ddl campo
                itemCtrl = ddlCriterio.SelectedItem;
                parent = ddlCriterio.Parent.Parent;
                trAlert = (TableRow)parent;

                if (itemCtrl.Value == " ")
                    {
                        trAlert.Cells[2].Text = "*";
                        retorno = ((retorno == true) ? false : retorno);
                    }
                else
                {
                    trAlert.Cells[2].Text = "";
                }
            //Busca en la coleccion de controles por campo y valida su contenido
            string IdControl = ddlCampo.SelectedItem.Value;
            Control ctrl = AllCtrlValue.Find(x => x.ID == IdControl);//Busca en la matriz el control seleccionado
            if (ctrl != null) {
                if ((ctrl.GetType() == typeof(EasyTextBox))|| (ctrl.GetType() == typeof(EasyDatepicker))|| (ctrl.GetType() == typeof(EasyNumericBox)))
                {
                    strValor = ((TextBox)ctrl).Text;
                }
                else if (ctrl.GetType() == typeof(EasyDropdownList))
                {
                    strValor = ((EasyDropdownList)ctrl).SelectedValue;
                }
                else if (ctrl.GetType() == typeof(EasyAutocompletar))
                {
                    strValor = ((EasyAutocompletar)ctrl).GetValue();
                }
                //Varifica si tiene valor ingresado
                if (strValor.Length == 0)
                {
                    tblBaseGestor.Rows[3].Cells[2].Text = "*";
                    retorno = false;
                }
            }
           
          
            //Seccion de mensajes de error   
            HtmlGenericControl _strong  = new HtmlGenericControl("strong");
            _strong.InnerText = "NOTA:";
            aContext.Controls.Add(_strong);
            aContext.Controls.Add(new LiteralControl(" Por favor ingrese los valores en los campos remarcados con asterisco(*)"));
            aContext.Style.Add("display", "block");
            if (ddlCampo.SelectedValue != " ") {//Se considera esta rutina luego de presionar el boton aceptar de generado de filtro y si el campo seleccionado contiene configuracion de busqueda pueda vovlver a configurarse el objeto de ingreso de valor
                string ScriptExecFindOpciones = this.ClientID.Replace("_", "") + "_FindOpciones(document.getElementById('" + this.ClientID +"_ddlCampo" + "'));\n";
                //**************************-----------SCRIPT-----------**********************************************
                CollecctionScript.Add(new LiteralControl("<script>\n" + ScriptExecFindOpciones + "</script>"));
            }

            return retorno;
        }
     
        #region Eventos Locales y remotos invocados por el enlace
        protected virtual void EasyFiltro_Click(object sender, EventArgs e)
        {
            List<EasyFiltroItem> lstEasyFiltroItem;
            lstEasyFiltroItem = new List<EasyFiltroItem>();
            if (this.ViewState[VariablesViewState.DataCriterios.ToString()] != null)
            {
                lstEasyFiltroItem = getCollectionCriterios();
            }
            string idItemCriterioSeleccionado = txtIdFiltro.Text.Split('@')[0];

            string strBtnID = ((HtmlButton)sender).ClientID;

            if (strBtnID.IndexOf(SubFijo.Gen.ToString()) > 0)//Cuando se presiona el boton aceptar de la ventana de generacion de filtro
            {
                if ((idItemCriterioSeleccionado.Length==0)||(idItemCriterioSeleccionado=="0"))
                {
                    OnItemCriterio(ModoEditFiltro.Add, null);
                }
                else
                {
                    EasyFiltroItem oEasyFiltroItem = new EasyFiltroItem();
                    oEasyFiltroItem.IdPadre = idItemCriterioSeleccionado;
                    OnItemCriterio(ModoEditFiltro.Add, oEasyFiltroItem);
                }
            }
            else if (strBtnID.IndexOf(SubFijo.Crit.ToString()) > 0)//Cuando se presiona el boton aceptar de la ventana criterios
            {
                if (this.ViewState[VariablesViewState.DataCriterios.ToString()] != null)
                {
                    lstEasyFiltroItem = getCollectionCriterios();
                    List<EasyFiltroItem> LstItemPrincipal = lstEasyFiltroItem.Where(item => item.Definitivo==false).ToList();
                    foreach (EasyFiltroItem itemPrincipal in LstItemPrincipal)
                    {
                        itemPrincipal.Definitivo = true;
                    }
                }

                OnProcessCompleted(lstEasyFiltroItem);
            }
            else {//Proceso de eliminación de filtro

                //string idDel = txtidFiltroDel.Text;
                //Obtener valor del argumento 
                HttpRequest ContextRequest = ((System.Web.UI.Page)HttpContext.Current.Handler).Request;
                string []arrModoValor = ContextRequest["__EVENTARGUMENT"].ToString().Split('@');
                string Modo = arrModoValor[0];
                string idDel = arrModoValor[1];

                EasyFiltroItem oEasyFiltroItemBE = new EasyFiltroItem();
                foreach (EasyFiltroItem oEasyFiltroItem in lstEasyFiltroItem)
                {
                    if (idDel.Equals(oEasyFiltroItem.Id))
                    {
                        oEasyFiltroItemBE = oEasyFiltroItem;
                        break;
                    }
                }

                switch ((ModoEditFiltro)System.Enum.Parse(typeof(ModoEditFiltro), Modo))
                {
                    case ModoEditFiltro.Delete:
                        OnItemCriterio(ModoEditFiltro.Delete, oEasyFiltroItemBE);
                        //buscar el boton en el formulario
                        HtmlButton btnAceptarCrit = (HtmlButton)this.FindControl("btn_Crit");
                        if (btnAceptarCrit != null)
                        {
                            EasyFiltro_Click(btnAceptarCrit, e);
                        }
                        break;
                    case ModoEditFiltro.ApplySoloItem:
                        // OnItemCriterio(ModoEditFiltro.ApplySoloItem, oEasyFiltroItemBE);
                        string strCriterio = oEasyFiltroItemBE.Campo + oEasyFiltroItemBE.Criterio.Replace("@","'").Replace("[VALOR]", oEasyFiltroItemBE.ValueField);
                        OnProcessCompleted(strCriterio, lstEasyFiltroItem);
                        break;
                }
               

            }

        }

        protected virtual void OnItemCriterio(ModoEditFiltro Modo,EasyFiltroItem oEasyFiltroItem)
        {
            //*****************************************************************************************************
           
            string MetodoScript = this.ClientID.Replace("_","") + MetodoBase._OpenWinModal.ToString();
            List<EasyFiltroItem> lstEasyFiltroItem;
            int NroFiltros = 0;
            bool Verifica = false;
            string LanzaGenerador="";
            lstEasyFiltroItem = new List<EasyFiltroItem>();

             if (this.ViewState[VariablesViewState.DataCriterios.ToString()] != null)
             {
                lstEasyFiltroItem = getCollectionCriterios();
                NroFiltros = lstEasyFiltroItem.Count;
             }

            switch (Modo)
            {
                case ModoEditFiltro.Add:
                    //Elabora un nuevo criterios
                    Verifica = VerificaSelecciondeCriterios(NroFiltros);
                    NroFiltros = NroFiltros + 1;
                    //Verificar en el viewstate si existe registro alguno de los critrios aplicados previamemnte
                    string NWindGen = this.ClientID + "_Gen";
                    string WinModalGen = ((oEasyFiltroItem != null) ? MetodoScript + "('" + NWindGen + "','" + txtIdFiltro.Text.Split('@')[0] + "','" + txtIdFiltro.Text.Split('@')[1] + "');\n" : MetodoScript + "('" + NWindGen + "');\n");

                    LanzaGenerador = ((Verifica == false) ? WinModalGen : "");
                    if (Verifica == true)
                    { //guarda el filtro elaborado
                        EasyFiltroItem oEasyFiltroItemBE = new EasyFiltroItem();
                        ListItem item = ddlOperador.SelectedItem;

                        oEasyFiltroItemBE.Id = NroFiltros.ToString();
                        oEasyFiltroItemBE.IdPadre = ((oEasyFiltroItem == null) ? "0" : oEasyFiltroItem.IdPadre);
                        oEasyFiltroItemBE.Operador = item.Value;
                        ddlOperador.SelectedIndex = 0;

                        item = ddlCampo.SelectedItem;
                        oEasyFiltroItemBE.Campo = item.Value;
                        oEasyFiltroItemBE.CampoDescripcion = item.Text;


                        item = ddlCriterio.SelectedItem;
                        oEasyFiltroItemBE.Criterio = item.Value;
                        oEasyFiltroItemBE.CriterioDescripcion = item.Text;
                        ddlCriterio.SelectedIndex = 0;
                        //Obtiene el valor ingresado del campo
                        EasyUtilitario.Enumerados.TiposdeDatos oTipodeDato;
                        string IdControl = ddlCampo.SelectedItem.Value;
                        Control ctrl = AllCtrlValue.Find(x => x.ID == IdControl);//Busca en la matriz el control seleccionado
                        if (ctrl != null)
                        {
                            if ((ctrl.GetType() == typeof(EasyTextBox))|| (ctrl.GetType() == typeof(EasyDatepicker))|| (ctrl.GetType() == typeof(EasyNumericBox)))
                            {
                                TextBox oTextBox = ((TextBox)ctrl);
                                strValor = ((TextBox)ctrl).Text;
                                oTipodeDato = (EasyUtilitario.Enumerados.TiposdeDatos)System.Enum.Parse(typeof(EasyUtilitario.Enumerados.TiposdeDatos), oTextBox.Attributes["TipodeDato"]);
                                //Modficado 18-03-2024
                                if (ctrl.GetType() == typeof(EasyDatepicker)) {
                                    EasyDatepicker oDP = ((EasyDatepicker)ctrl);
                                    DateTime ChangesOnTimeOfOfferChange = DateTime.ParseExact(strValor, oDP.FormatInPut, CultureInfo.InvariantCulture);
                                    strTexto = strValor;
                                    strValor = ChangesOnTimeOfOfferChange.ToString(oDP.FormatOutPut);
                                }

                               
                               // strTexto = strValor;
                                oEasyFiltroItemBE.TipodeDatos = oTipodeDato;
                                oEasyFiltroItemBE.TemplateType = ((TextBox)ctrl).Attributes["TemplateType"];
                                ((TextBox)ctrl).Text="";
                            }
                            else if (ctrl.GetType() == typeof(EasyDropdownList))
                            {
                                EasyDropdownList oEasyDropdownList = ((EasyDropdownList)ctrl);
                                oTipodeDato = (EasyUtilitario.Enumerados.TiposdeDatos)System.Enum.Parse(typeof(EasyUtilitario.Enumerados.TiposdeDatos), oEasyDropdownList.Attributes["TipodeDato"]);
                                strValor = oEasyDropdownList.SelectedValue;
                                strTexto = oEasyDropdownList.SelectedItem.Text;
                                oEasyFiltroItemBE.TipodeDatos = oTipodeDato;
                                oEasyFiltroItemBE.TemplateType = oEasyDropdownList.Attributes["TemplateType"];
                                oEasyDropdownList.SelectedIndex = 0;
                            }
                            else if (ctrl.GetType() == typeof(EasyAutocompletar))
                            {
                                EasyAutocompletar oEasyAutocompletar = ((EasyAutocompletar)ctrl);
                                oTipodeDato = (EasyUtilitario.Enumerados.TiposdeDatos)System.Enum.Parse(typeof(EasyUtilitario.Enumerados.TiposdeDatos), oEasyAutocompletar.Attributes["TipodeDato"]);
                                strValor = oEasyAutocompletar.GetValue();
                                strTexto = oEasyAutocompletar.GetText();
                                oEasyFiltroItemBE.TipodeDatos = oTipodeDato;
                                oEasyFiltroItemBE.TemplateType = oEasyAutocompletar.Attributes["TemplateType"];
                                oEasyAutocompletar.SetValue("","");
                            }
                        }

                        oEasyFiltroItemBE.ValueField = strValor;
                        oEasyFiltroItemBE.TextField = strTexto;

                        ddlCampo.SelectedIndex = 0;

                        //rutina para agregar subItem
                        if (oEasyFiltroItem == null)
                        {
                            lstEasyFiltroItem.Add(oEasyFiltroItemBE);
                        }
                        else
                        {
                            int pos = 0;
                            foreach (EasyFiltroItem oEasyFiltroItemFind in lstEasyFiltroItem)
                            {
                                if (oEasyFiltroItem.IdPadre.ToString().Equals(oEasyFiltroItemFind.Id))//Busca la ubicacion del padre para luego iniciar el conteo de los hijos ubicarse en la ultima posición
                                {
                                    break;
                                }
                                pos++;

                            }

                            int NroHijos = 0;
                            for (int pHijos = (pos + 1); pHijos < lstEasyFiltroItem.Count; pHijos++)
                            {
                                EasyFiltroItem EasyFiltroItemHijo = lstEasyFiltroItem[pHijos];
                                if (oEasyFiltroItem.IdPadre.ToString().Equals(EasyFiltroItemHijo.IdPadre))
                                {
                                    NroHijos++;
                                }
                                else
                                {
                                    break;
                                }
                            }

                            lstEasyFiltroItem.Insert(((pos + NroHijos) + 1), oEasyFiltroItemBE);


                            if (NroHijos == 0)
                            {
                                NroHijos++;
                            }
                            else
                            {
                                NroHijos++;
                            }

                            EasyFiltroItem EasyFiltroItemPadre = lstEasyFiltroItem[pos];
                            EasyFiltroItemPadre.NroHijos = NroHijos;
                            lstEasyFiltroItem[pos] = EasyFiltroItemPadre;
                        }

                        oEasyFiltroItem = oEasyFiltroItemBE;//
                        if (easyCriterioList != null) { 
                            this.easyCriterioList.Clear();
                            foreach (EasyFiltroItem oEasyFiltroItemAdd in lstEasyFiltroItem)
                            {
                                this.easyCriterioList.Add(oEasyFiltroItemAdd);
                            }
                        }
                        //Oculta el msg de alerta
                        aContext.Style.Add("display", "NONE");

                        this.ViewState[VariablesViewState.DataCriterios.ToString()] = lstEasyFiltroItem;
                    }

                    //Crea las filas segun filtros elaborados
                    ViewCriteriosGenerados();
                    //Crear la barra de criterios elaborados
                    string javaScript =
                    "try{\n"
                         + MetodoScript + "('" + this.ClientID.Replace("_", "") + "_" + SubFijo.Crit.ToString() + "');\n" +
                          LanzaGenerador +
                    "}catch(err){\n" +
                       "alert(err);\n" +
                    "};\n";

                    //**************************-----------SCRIPT-----------**********************************************
                    CollecctionScript.Add(new LiteralControl("<script>\n" + javaScript + "</script>"));


                    break;
                case ModoEditFiltro.Delete:
                    bool Encontrado = false;
                    //Busca el IdPadre Para descontar el Nro de Hijos
                    string IdPadre = oEasyFiltroItem.IdPadre;
                    lstEasyFiltroItem.Remove(oEasyFiltroItem);
                    EasyFiltroItem oEasyFiltroItemPadre = new EasyFiltroItem();
                    int idx = 0;
                    foreach (EasyFiltroItem ItemBE in lstEasyFiltroItem)
                    {
                        if (IdPadre.Equals(ItemBE.Id))
                        {
                            oEasyFiltroItemPadre = ItemBE;
                            oEasyFiltroItemPadre.NroHijos--;
                            Encontrado = true;
                            break;
                        }
                        idx++;
                    }
                    if (Encontrado)
                    {
                        lstEasyFiltroItem[idx] = oEasyFiltroItemPadre;
                    }
                    this.ViewState[VariablesViewState.DataCriterios.ToString()] = lstEasyFiltroItem;
                    ViewCriteriosGenerados();
                    break;              
            }
         

            ItemCriterio?.Invoke(Modo,oEasyFiltroItem);//invoca al metodo de lado del servidor en la pagina en donde el control es creado
        }

        public string getFilterString() {
           
            string FiltroElaborado = "";
            List<EasyFiltroItem> lstEasyFiltroItem;
            lstEasyFiltroItem = new List<EasyFiltroItem>();
            if (this.ViewState[VariablesViewState.DataCriterios.ToString()] != null)
            {
                lstEasyFiltroItem = getCollectionCriterios();
                //Elabora el filtro resultante
               
                List<EasyFiltroItem> LstItemPrincipal = lstEasyFiltroItem.Where(item => item.IdPadre == "0" && item.Definitivo == true).ToList();
                foreach (EasyFiltroItem item in LstItemPrincipal)
                {
                    if (item.NroHijos > 0)
                    {
                        FiltroElaborado = FiltroElaborado + " " + CriterioPrimario(item, " (");
                        List<EasyFiltroItem> LstItemChildrens = lstEasyFiltroItem.Where(itemChildFind => itemChildFind.IdPadre == item.Id && item.Definitivo == true).ToList();
                        foreach (EasyFiltroItem itemChild in LstItemChildrens)
                        {
                           
                            FiltroElaborado = FiltroElaborado + " " + CriterioPrimario(itemChild, "");

                        }
                        FiltroElaborado = FiltroElaborado + ")";


                    }
                    else
                    {
                        FiltroElaborado = FiltroElaborado + " " + CriterioPrimario(item,"");                       
                    }
                }

            }
            //Valida sintaxis de filtro
            if (FiltroElaborado.Length > 0)
            {
                FiltroElaborado = FiltroElaborado.TrimStart(' ');
                if (FiltroElaborado.Substring(0, 2).Equals("OR"))
                {
                    FiltroElaborado = FiltroElaborado.Substring(2, FiltroElaborado.Length - 2);
                }
                else if (FiltroElaborado.Substring(0, 3).Equals("AND"))
                {
                    FiltroElaborado = FiltroElaborado.Substring(2, FiltroElaborado.Length - 3);
                }
            }

            return FiltroElaborado;
        }

        string CriterioPrimario(EasyFiltroItem item,string Parentesis) {
            string CaracterComodin = "";
            string ResultStr = "";
            string Negacion = "";
            if (((item.TipodeDatos == EasyUtilitario.Enumerados.TiposdeDatos.Int) || (item.TipodeDatos == EasyUtilitario.Enumerados.TiposdeDatos.Double))
                    && ((item.CriterioDescripcion == strCriterio[0, 3])
                        || (item.CriterioDescripcion == strCriterio[0, 4])
                        || (item.CriterioDescripcion == strCriterio[0, 5])
                        || (item.CriterioDescripcion == strCriterio[0, 6])
                        || (item.CriterioDescripcion == strCriterio[0, 7])
                        || (item.CriterioDescripcion == strCriterio[0, 8])
                        )
                    )
            {
                CaracterComodin = "";
                Negacion = ((item.CriterioDescripcion == strCriterio[0, 4]) ? " NOT " : " ");
                ResultStr = " " + item.Operador  + Parentesis + Negacion + item.Campo + " " + item.Criterio.Replace("@", CaracterComodin)
                                                                                                                        .Replace("[VALOR]", item.ValueField);


            }

            else if ((item.TipodeDatos == EasyUtilitario.Enumerados.TiposdeDatos.Date)
                        && ((item.CriterioDescripcion == strCriterio[0, 3])
                            || (item.CriterioDescripcion == strCriterio[0, 4])
                            || (item.CriterioDescripcion == strCriterio[0, 5])
                            || (item.CriterioDescripcion == strCriterio[0, 6])
                            || (item.CriterioDescripcion == strCriterio[0, 7])
                            || (item.CriterioDescripcion == strCriterio[0, 8])
                            )
                    )
            {
                CaracterComodin = "";
                Negacion = ((item.CriterioDescripcion == strCriterio[0, 4]) ? " NOT " : " ");
                ResultStr = " " + item.Operador + Parentesis  + Negacion + item.Campo + " " + item.Criterio.Replace("@", CaracterComodin)
                                                                                                            .Replace("[VALOR]", "'" + item.ValueField + "'");
                //.Replace("[VALOR]", "#" + item.ValueField + "#");
            }
            else if ((item.TipodeDatos == EasyUtilitario.Enumerados.TiposdeDatos.String)
                && ((item.CriterioDescripcion == strCriterio[0, 0])
                    || (item.CriterioDescripcion == strCriterio[0, 1])
                    || (item.CriterioDescripcion == strCriterio[0, 2])
                    || (item.CriterioDescripcion == strCriterio[0, 3])
                    || (item.CriterioDescripcion == strCriterio[0, 4])
                    )
                )
            {
                CaracterComodin = "'";
                Negacion = ((item.CriterioDescripcion == strCriterio[0, 4]) ? " NOT " : " ");
                ResultStr = " " + item.Operador + Parentesis + Negacion + " Convert(" + item.Campo + ",'System.String') " + item.Criterio.Replace("*", "%")
                                                                                                                .Replace("@", CaracterComodin)
                                                                                                                .Replace("[VALOR]", item.ValueField);
            }
            return ResultStr;
        }


        protected virtual void OnProcessCompleted(string FiltroFinal, List<EasyFiltroItem> lstEasyFiltroItem)
        {
            //Invoca al evento externo
            if (ProcessCompleted != null)
            {
                ProcessCompleted?.Invoke(FiltroFinal, lstEasyFiltroItem);
            }
        }
        protected virtual void OnProcessCompleted( List<EasyFiltroItem> lstEasyFiltroItem)
        {

            //v.RowFilter = string.Concat("CONVERT(", "ColumnName", ",System.String) LIKE '%", InputString, "%'")
            string FiltroFinal = getFilterString();
           
                //Invoca al evento externo
            if (ProcessCompleted != null)
            {
                ProcessCompleted?.Invoke(FiltroFinal, lstEasyFiltroItem);
            }
        }
        #endregion
    }

   
}


