using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Web;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
 


namespace EasyControlWeb.Form.Controls
{
    [ToolboxData("<{0}:EasyPopupBase runat=server></{0}:EasyPopupBase>")]
    [ParseChildren(true, "Content")]


    public class EasyPopupBase : WebControl, INamingContainer
    {
        #region Variables
        string cmll = EasyUtilitario.Constantes.Caracteres.ComillaDoble;
        #endregion


        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TemplateContainer(typeof(EasyPopupBase))]
        [TemplateInstance(TemplateInstance.Single)]
        public virtual ITemplate Content { get; set; }


        #region Propiedades Simples
            public string Titulo { get; set; }

        /*[Category("Archivo de conexion a formularios")]
        [Browsable(true)]
        [Description("Conectar a Archivos url al que se desea interconectar")]
        [Editor(typeof(UrlEditor), typeof(UITypeEditor))]
        public string Pagina { get; set; }*/
        #endregion

        public enum ModalWindow
        {
            fullscreen,
            Small,
            Medio,
        }

        public enum TipoContenido{
            Contenedor,
            LoadPage,
        }
        public ModalWindow Modal { get; set; }
        public TipoContenido ModoContenedor { get; set; }

        public bool DisplayButtons { get; set; }

        
        public  string fncScriptAceptar {
            get;set;
         }
      
        public bool RunatServer { get; set; }




        /*Event handler*/
        HtmlButton obtnAccion;

        public delegate void _Click();
        public event _Click Click;



        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            //base.RenderBeginTag(writer);
        }

        public override void RenderEndTag(HtmlTextWriter writer)
        {
           // base.RenderEndTag(writer);
        }

        void BootStrapPopupFullScreen(HtmlTextWriter output)
        {
            string sModal = "";
            switch(Modal){
                case ModalWindow.fullscreen:
                    sModal = "modal-dialog modal-lg";
                    break;
                case ModalWindow.Small:
                    sModal = "modal-dialog modal-sm";
                    break;
                case ModalWindow.Medio:
                    sModal = "modal-dialog";
                    break;

            }

            //string scriptBTN = ((this.RunatServer==true) ? "onclick= " + cmll + "javascript:" + this.ClientID + @".ClearonLoad();__doPostBack('" + this.ClientID + "$btnApcetarUnder','');" + cmll : ((fncScriptAceptar == string.Empty) ? "" : "onclick= " + cmll + "javascript:" + this.ClientID + @".ClearonLoad();" + fncScriptAceptar + "();" + cmll));
            // string scriptBTN = ((this.RunatServer == true) ? "onclick= " + cmll + "javascript: SIMA.Utilitario.Helper.Wait('Procesando...', 0, function () { });" + this.ClientID + @".ClearonLoad();__doPostBack('" + this.ClientID + "$btnApcetarUnder','');" + cmll : ((fncScriptAceptar == string.Empty) ? "" : "onclick= " + cmll + "javascript:" + fncScriptAceptar + "(); " + this.ClientID + @".ClearonLoad();" + this.ClientID + @".Close();" + cmll));
            string scriptBTN = "";
            if (this.RunatServer == true) {
                if ((fncScriptAceptar == string.Empty)|| (fncScriptAceptar == null))
                {
                     scriptBTN = "onclick= " + cmll + "javascript: SIMA.Utilitario.Helper.Wait('Procesando...', 0, function () { });" + this.ClientID + @".ClearonLoad();__doPostBack('" + this.ClientID + "$btnApcetarUnder','');" + cmll;
                }
                else {
                    scriptBTN = @"onclick= " + cmll + "javascript:  if(" + fncScriptAceptar + "()==true){ SIMA.Utilitario.Helper.Wait('Procesando...', 0, function () {  " + this.ClientID + @".ClearonLoad();__doPostBack('" + this.ClientID + "$btnApcetarUnder','');});}" + cmll;
                }
            }
            else {
                if ((fncScriptAceptar == string.Empty) || (fncScriptAceptar == null))
                {
                    scriptBTN = "onclick= " + cmll + "javascript:if(" + this.ClientID   + ".fncScriptAceptar()==true){" + this.ClientID + @".ClearonLoad();" + this.ClientID + @".Close();}" + cmll;
                    //scriptBTN = "onclick= " + cmll + "javascript:if(" + this.ClientID + "." + fncScriptAceptar +"()==true){ " + this.ClientID + @".ClearonLoad();" + this.ClientID + @".Close();}" + cmll;
                }
                else
                {
                    scriptBTN = "onclick= " + cmll + "javascript:if(" + fncScriptAceptar + "()==true){ " + this.ClientID + @".ClearonLoad();" + this.ClientID + @".Close();}" + cmll;
                }
            }

            bool Si_No = true;


            /* string HtmlProgress = "<div id='PanelProgress_" + this.ClientID + "' style ='width:80%;height: 25px;position: fixed;right: 0; padding-right: 40px;'>"
                                 + "  <div id='" + this.ClientID + "_ContentProgress' class='progress progress-striped active' style='margin-bottom:0;display:none;width: 70%;height: 100%;float: right;'>"
                                 + "     <div  id='" + this.ClientID + "_Progress' class='progress-bar' style='width: 100%;height: 100%;'>Load..</div>"
                                 + " </div>"
                                 + "</div>";*/


            string HtmlProgress = "  <div id='" + this.ClientID + "_ContentProgress' class='progress progress-striped active' style='margin-left:0;margin-bottom:0;display:none;width: 100%;height: 100%;'>"
                                + "     <div  id='" + this.ClientID + "_Progress' class='progress-bar' style='width: 100%;height: 100%;'>Load..</div>"
                                + " </div>";
                                 


            string BorderDrag = "style =" + cmll + "border- width:2px;border-style:dotted; border-color:black;" + cmll;
            string PrintBorder = ((IsDesign() == Si_No) ? BorderDrag : "");
            string ClaseModal = ((IsDesign() == Si_No) ? "ModaVisible" : "modal");
            string TextHolder = ((IsDesign() == Si_No) ? "Arrastre Aqui el Control EasyFormDesign...." : "");
            output.Write("<div id=" + cmll + this.ClientID + cmll + " class=" + cmll + ClaseModal + " fade " + cmll + " role ='dialog' >\n");
           // output.Write("            <div class=" + cmll + "modal-dialog" + cmll + ">\n");
            output.Write("            <div class=" + cmll + sModal  + cmll + ">\n");
            output.Write("                <div class=" + cmll + "modal-content" + cmll + " >\n");
            output.Write("                    <div id='Header_" + this.ClientID + "' class=" + cmll + "modal-header" + cmll + ">\n");
            output.Write("                        <h4 id= " + cmll +"Title_" + this.ClientID + cmll + " class=" + cmll + "modal-title" + cmll + " > " + Titulo + "</h4>\n");
            output.Write("                              <div id='PanelProgress_" + this.ClientID + "' style ='width:80%;height: 25px;position: fixed;right: 0; padding-right: 40px;'>");
            output.Write(HtmlProgress);
            output.Write("                              </div>");
            output.Write("                        <button type = " + cmll + "button" + cmll + " class=" + cmll + "close" + cmll + " data-dismiss=" + cmll + "modal" + cmll + " aria-hidden=" + cmll + "true" + cmll + " onclick='javascript:" + ClientID + @".ClearonLoad();'> &times;</button>");
            output.Write("                    </div>\n");
            output.Write("                    <div id=" + cmll + ClientID +"_body" + cmll + " class=" + cmll + "modal-body" + cmll + PrintBorder + ">" + TextHolder + "\n");
            this.RenderChildren(output);
            if (this.ModoContenedor == TipoContenido.LoadPage)
            {
                output.Write("                      <div id=" + cmll + ClientID + "_LoadPage" + cmll + "  style='height: 100%; width: 100%;'>\n ");
                output.Write("                      </div>\n ");
            }
            output.Write("                    </div>\n");
           // output.Write("                    </div>\n");
            output.Write("                    <div  id='Footer_" + this.ClientID + "' class=" + cmll + "modal-footer" + cmll + ">\n");
            output.Write("                    <div  id='FooterContent_" + this.ClientID + "' style='width:50%;height: 30px;position: fixed;left: 0;margin-left:10px;padding-left: 0px; border-style: solid;border-color: #F0F0F0; border-width: 1px;'></div>\n");
            if (DisplayButtons)
            {
                output.Write("                          <button id= '" + this.ClientID + "btnAceptar' type = " + cmll + "button" + cmll + " class=" + cmll + "btn btn-primary" + cmll + scriptBTN + "> Aceptar</button>\n");
                output.Write("                          <button id= '" + this.ClientID + "btnClose' type = " + cmll + "button" + cmll + " class=" + cmll + "btn btn-default" + cmll + " data-dismiss=" + cmll + "modal" + cmll + " onclick=" + cmll + "javascript:" + this.ClientID + @".ClearonLoad();" + cmll + "> Cancelar</button>\n");
            }
            output.Write("                    </div>\n");
            output.Write("                </div>\n");
            output.Write("              </div>\n");
            output.Write("          </div>\n");
        }

        // 

        protected override void RenderContents(HtmlTextWriter output)
        {
            //Renderiza el Control
            BootStrapPopupFullScreen(output);

        }

        protected override void OnInit(System.EventArgs e)
        {
            base.OnInit(e);

            // Initialize all child controls.
            this.CreateChildControls();
            this.ChildControlsCreated = true;
        }

        protected override void CreateChildControls()
        {
            // Remove any controls
            this.Controls.Clear();

            // Add all content to a container.
            var container = new Control();
            this.Content.InstantiateIn(container);

            // Add container to the control collection.
            if (container != null)
            {
                obtnAccion = new HtmlButton();
                obtnAccion.ID = "btnApcetarUnder";
                obtnAccion.Attributes.Add("runat", "server");
                obtnAccion.ServerClick += btn_onClick;
                obtnAccion.Style["display"] = "none";

                //container.Controls.Add(obtnAccion);//Agregado 16-12-2022
                this.Controls.Add(container);
                this.Controls.Add(obtnAccion);//Agregado 16-12-2022
            }
        }
       protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
            if (!DesignMode)
            {
                //Referencia: https://www.w3schools.com/bootstrap/tryit.asp?filename=trybs_ref_js_modal_backdrop&stacked=h
                string NameProgress = "jNet.get('" + this.ClientID + @"_ContentProgress');";
                string Script = @"<script> 
                                    " + ClientID + @".Titulo ='';
                                    " + ClientID + @".FormContextName = null;                                  
                                    " + ClientID + @".Show=function(Modo){
                                                    if(" + ClientID + @".Titulo.length>0){
                                                        var IdTitle = " + cmll + "Title_" + ClientID + cmll + @";
                                                        jNet.get(IdTitle).innerHTML=" + ClientID + @".Titulo;
                                                    }
                                                $('#" + ClientID + @"').modal(Modo);  
                                        }
                                    " + ClientID + @".Close=function(){
                                         $('#" + ClientID + @"btnClose').click();
                                    }
                                    " + ClientID + @".Param=SIMA.Param;
                                    " + ClientID + @".UrlReload='';
                                    " + ClientID + @".ParamReload=null;
                                    " + ClientID + @".ParamCollection=SIMA.ParamCollections;
                                    " + ClientID + @".Reload=function(){
                                            " + ClientID + @".Load(" + ClientID + @".UrlReload," + ClientID + @".ParamReload,false);
                                    }
                                    " + ClientID + @".Load=function(UrlPagina,ParamCollection,LoadjNet){
                                                  " + ClientID + @".FormContextName = document.forms[0].id;
                                                  var LstParams='';
                                                  if(ParamCollection!=undefined){
                                                    ParamCollection.getCollection().forEach(function(oParamItem,i){
                                                        LstParams += ((i==0)?'':'&') + oParamItem.Nombre + '=' + oParamItem.Valor;
                                                    });
                                                  }
                                             //Para efectos del reload
                                              " + ClientID + @".UrlReload=UrlPagina;
                                              " + ClientID + @".ParamReload=ParamCollection;

                                              var UrlPaginayParams= UrlPagina  + (((UrlPagina.indexOf('?')==-1)&&(LstParams.length>0))?'?':'') + LstParams;

                                                if((LoadjNet==undefined)||(LoadjNet==false)){
                                                            jQuery.ajax({
                                                                        url: UrlPaginayParams,
                                                                        type: 'get',
                                                                        dataType: 'html',
                                                                        beforeSend:function(){
                                                                             " + ClientID + @".ProgressBar.Position('Footer');
                                                                              " + ClientID + @".ProgressBar.Show('Procesando Pagina..');
                                                                        },
                                                                        success: function (data) {
                                                                            var _html = jQuery(data);
                                                                            jQuery('#" +  ClientID + "_LoadPage" + @"').html(_html);
                                                                            " + ClientID + @".ProgressBar.Hide();
                                                                        },
                                                                        error: function (jqXHR, textStatus, errorThrown) {
                                                                            alert('Error');
                                                                            var msg = '';
                                                                            if (jqXHR.status == 404) {msg = 'No encontrado';} 
                                                                            else if (jqXHR.status == 500) {msg = 'Error ejecutando';}
                                                                            " + ClientID + @".ProgressBar.Hide();
                                                                        }
                                                            });
                                                    }
                                                    else{
                                                        jNet.get('" + ClientID + "_LoadPage" + @"').load(UrlPagina,LstParams,function(){});
                                                        
                                                    }

                                          " + ClientID + @".Show({backdrop: false});
                                        }

                                        " + ClientID + @".ClearonLoad=function(){
                                                if(" + ClientID + @".FormContextName!=null){
                                                    jQuery('#" + ClientID + "_LoadPage" + @"').empty();
                                                    theForm = document.forms[" + ClientID + @".FormContextName]; 
                                                }
                                        }
                                        " + ClientID + @".ProgressBar={};

                                        " + ClientID + @".ProgressBar.Show=function(TextWait){
                                            " + ClientID + @".ProgressBar.Visibility(TextWait,true);
                                        }
                                        " + ClientID + @".ProgressBar.Hide=function(){
                                            " + ClientID + @".ProgressBar.Visibility('',false);
                                        }
                                         " + ClientID + @".ProgressBar.Position=function(Ubicacion){
                                                var PanelPrgress = jNet.get('" + this.ClientID + @"_ContentProgress');
                                                var ObjDestino=null;
                                                switch(Ubicacion){
                                                    case 'Header':
                                                        ObjDestino= jNet.get('PanelProgress_" + this.ClientID + @"');
                                                        PanelPrgress.css('float','right');
                                                        break;
                                                    case 'Footer':
                                                        ObjDestino= jNet.get('FooterContent_" + this.ClientID + @"');
                                                        PanelPrgress.css('float','left');
                                                        break;
                                                }
                                                ObjDestino.insert(PanelPrgress);
                                        }
                                        " + ClientID + @".Task={};
                                        " + ClientID + @".Task.Excecute=function(Titulo,fncTarea){
                                                                            " + ClientID + @".ProgressBar.Show(Titulo);
                                                                            var intPrc = window.setTimeout(fncTarea, 1000);
                                                                        };
                                        " + ClientID + @".ProgressBar.Visibility=function(TextWait,Show){
                                              var ShowHide = ((Show==true)?'block':'none');
                                              var bContentProgress = jNet.get('" + this.ClientID + @"_ContentProgress');
                                                 bContentProgress.css('display',ShowHide);
                                              var bProgress =  jNet.get('" + this.ClientID + @"_Progress');
                                               bProgress.innerText=TextWait;
                                        }
                                  </script>
                                    ";
                (new LiteralControl(Script)).RenderControl(writer);

                /*atributos añadidos
                writer.AddStyleAttribute("width", "600px");
                writer.RenderBeginTag(HtmlTextWriterTag.Div);

                writer.AddStyleAttribute("float", "left");
                writer.AddStyleAttribute("width", "280px");
                writer.AddStyleAttribute("padding", "10px");
               */

            }
        }




        private bool IsDesign()
        {
            if (this.Site != null)
                return this.Site.DesignMode;
            return false;
        }

        #region Eventos internos
        public void btn_onClick(object sender, EventArgs e)
        {
            string Argument = ((System.Web.UI.Page)HttpContext.Current.Handler).Request["__EVENTARGUMENT"];
            if (Click != null)//verifica si esta asociado en la pagina con el evento
            {
                //EasyControlWeb.Form.Controls.EasyButton oEasyButton = new EasyButton();
                //oEasyButton.Texto = Argument;

                    Click?.Invoke();
              
            }

        }
        #endregion
    }
}
