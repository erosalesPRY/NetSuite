﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Windows.Resources;


namespace EasyControlWeb.Form.Controls
{
    [Serializable]
    public  class EasyListAutocompletar:EasyAutocompletar
    {
        TextBox txtLstItems;
        string OldfncOnSelected = "";
        string NewFncOnSelected = "";
          
         

        #region Propiedades
        [Category("FuncionesJScript"), Description("Contructor de Plantillas para los items de la Lista"), DefaultValue("")]
        [RefreshProperties(RefreshProperties.All)]
        [NotifyParentProperty(true)]
        public string fncTempaleCustomItemList { get; set; }

        [Category("FuncionesJScript"), Description("Evento que se desencadena al seleccionar un Item"), DefaultValue("")]
        [RefreshProperties(RefreshProperties.All)]
        [NotifyParentProperty(true)]
        public string fncLstItemOnClick { get; set; }

        [Category("FuncionesJScript"), Description("Evento que se desencadena la eliminacion del Item"), DefaultValue("")]
        [RefreshProperties(RefreshProperties.All)]
        [NotifyParentProperty(true)]
        public string fncLstItemOnDelete { get; set; }

        [Category("Clase estilo Item"), Description("Clase que se una para dar stylo al item"), DefaultValue("")]
        [RefreshProperties(RefreshProperties.All)]
        [NotifyParentProperty(true)]
        public string ClassItem { get; set; }


        [Category("Datos"), Description("Campo que representa el Valor de los items seleccionados"), DefaultValue("")]
        [RefreshProperties(RefreshProperties.All)]
        [NotifyParentProperty(true)]
        public string LstValueField { get; set; }

        #endregion





        public EasyListAutocompletar():base() {
            if (txtLstItems == null) { txtLstItems = new TextBox();  }
        }
      

        HtmlGenericControl ContentItems() {
            HtmlGenericControl dvContent = new HtmlGenericControl("div");
            dvContent.Attributes["id"] = this.ClientID + "_Content";
            dvContent.Style.Add("border", "1px solid grey;");
            dvContent.Style.Add("class", this.CssClass);
            return dvContent;
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }
        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            OldfncOnSelected = this.fnOnSelected;
            NewFncOnSelected = this.ClientID + "_CrearItem";
            if (!IsDesign())
            {
                this.fnOnSelected = NewFncOnSelected;
            }

            txtLstItems.ID = "txtLstItems";
            txtLstItems.Style.Add("display", "none");
            this.Controls.Add(txtLstItems);

        }

       

        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
            ContentItems().RenderControl(writer);
            txtLstItems.RenderControl(writer);
            

            // txtLstItems.RenderControl(writer);

            string cmll = EasyUtilitario.Constantes.Caracteres.ComillaDoble.ToString();
            string fncDefaultTemplate = this.ClientID + "_TemplateDefault";
            string FNTEMPLATE = "";
            //Definicion de un array

            string ScriptArrayLocal = "var " + this.ClientID + "_Collection= new Array();";

            (new LiteralControl("\n <script>\n" + ScriptArrayLocal + "\n" + "</script>\n")).RenderControl(writer);

            /**********************************************************************************************************/

            if ((fncTempaleCustomItemList!=null) &&(fncTempaleCustomItemList.Length > 0))
            {
                //fncDefaultTemplate = fncTempaleCustomItemList;
                FNTEMPLATE = this.fncTempaleCustomItemList + "(oItemBE);";
            }
            else {
                FNTEMPLATE = "oItemBE." + this.DisplayText;
            }
            string ScripTempateDefault = @"function " + fncDefaultTemplate + @"(oItemBE){
                                                    var HTMLCustome=" + FNTEMPLATE + @"
                                                    var cmll =SIMA.Utilitario.Constantes.Caracter.Comilla;
                                                    var objSerialize = '';
                                                    var objS=objSerialize.Serialized(oItemBE).toString().Replace(cmll," + cmll + "'" + cmll + @");
                                                    var tblItem = '<table id=' + cmll + oItemBE." + this.ValueField + " + cmll + ' class=' + cmll + '" + this.ClassItem + @"' + cmll + ' > <tr Data=' + cmll + objS + cmll + ' > <td   style='+ cmll + 'width:100%' + cmll +' onclick='+ cmll + '" + this.ClientID + "_LstItemOnClick(this);" + "' + cmll + ' >' + HTMLCustome + '</td><td><img  onclick='+ cmll + '" + this.ClientID + "_LstItemOnDelete(this);" + @"' + cmll + ' src=' + cmll + SIMA.Utilitario.Constantes.ImgDataURL.ImgClose + cmll +'/></td></tr></table>';
                                                    return tblItem;
                                                }
                                            ";


            (new LiteralControl("\n <script>\n" + ScripTempateDefault + "\n" + "</script>\n")).RenderControl(writer);
            /*------------------------------------------------------------------------------------------------------------------*/
            /*Evento Click del Item*/
            string fnc_Externo_ItemOnCLick = (fncLstItemOnClick == null) ? "" : fncLstItemOnClick + "(oItemBE);";
            string ScriptListItemOnSelected = @"function " + this.ClientID + @"_LstItemOnClick(e){
                                                    var ItemSelect = jNet.get(e.parentNode);//Fila del Control
                                                    var oItemBE = ItemSelect.attr('Data').toString().SerializedToObject();
                                                    var CtrlContent = jNet.get('" + this.ClientID + @"_Content');

                                                     Array.from(CtrlContent.children).forEach(function (oItemTbl) {
                                                                                       var oitem=  jNet.get(oItemTbl);
                                                                                        oitem.attr('class', '" + this.ClassItem + @"');
                                                                                    });

                                                    var tblSelect =ItemSelect.parentNode.parentNode;
                                                    jNet.get(tblSelect).attr('class', 'LstItemSelect');


                                                  " + fnc_Externo_ItemOnCLick + @"  
                                                }
                                            ";

            (new LiteralControl("\n <script>\n" + ScriptListItemOnSelected + "\n" + "</script>\n")).RenderControl(writer);

            /*Evento Eliminar*/
            string fnc_Externo_ItemOnDelete = (fncLstItemOnDelete == null) ? "true;" : fncLstItemOnDelete + "(oItemBE);";
            string ScriptListItemOnDetele = @"function " + this.ClientID + @"_LstItemOnDelete(e){
                                                    var oItemBE = jNet.get(e.parentNode.parentNode).attr('Data').toString().SerializedToObject();

                                                     $.confirm({title: 'Eliminar Item',
                                                            content: 'Desea Eliminar este Item Ahora?',
                                                            icon: 'fa fa-times',
                                                            animation: 'scale',
                                                            closeAnimation: 'scale',
                                                            opacity: 0.5,
                                                            buttons: {
                                                                'confirm': {
                                                                    text: 'Aceptar',
                                                                    btnClass: 'btn-blue',
                                                                    action: function () {
                                                                              var Confirma = " + fnc_Externo_ItemOnDelete + @"
                                                                              if(Confirma){
                                                                                var CtrlItem = jNet.get(oItemBE." + this.ValueField + @");
                                                                                var ctrlContent = jNet.get('" + this.ClientID + @"_Content');
                                                                                ctrlContent.remove(CtrlItem);
                                                                                //Remover desde el array
                                                                                " + this.ClientID + @"_Remove(oItemBE);
                                                                                " + this.ClientID + @"_SetListCollection();
                                                                              }
                                                                            }
                                                                },
                                                                cancel: function () {
                                                                },
                    
                                                            }
                                                        });
                                                }
                                            ";

            (new LiteralControl("\n <script>\n" + ScriptListItemOnDetele + "\n" + "</script>\n")).RenderControl(writer);

            /*------------------------------------------------------------------------------------------------------------------*/
            string ScriptItenmSelected = @"function " + NewFncOnSelected + @"(ItemValue, oItemBE){
                                                //Crear los ItemList
                                                var ItemList  =" + fncDefaultTemplate + @"(oItemBE);
                                                var ObjContent=jNet.get('" + this.ClientID + @"_Content');
                                                
                                                    if(ObjContent.find(oItemBE." + this.ValueField + @")==false){
                                                        ObjContent.insertAdjacentHTML('beforeend',ItemList);
                                                        " + this.ClientID + @"_Collection.Add(oItemBE);

                                                        " + this.ClientID + @"_SetListCollection();

                                                        " + OldfncOnSelected + @"(ItemValue, oItemBE);
                                                        //Limpia los seleccionado
                                                        " + this.ClientID + @".SetValue('0','');
                                                    }
                                                    else{
                                                        var msgConfig = { Titulo: 'Validación', Descripcion: 'El Item ' + oItemBE." + this.DisplayText + @" + ' que desea incluir ya existe'};
                                                        var oMsg = new SIMA.MessageBox(msgConfig);
                                                        oMsg.Alert();
                                                        //Limpia los seleccionado
                                                        " + this.ClientID + @".SetValue('0','');
                                                    }
                                            }
                                            function " + this.ClientID + @"_SetListCollection(){
                                                var Dencript='';
                                                var objTxtLst = jNet.get('" + txtLstItems.ClientID + @"');
                                                    objTxtLst.value = '';
                                                 " + this.ClientID + @"_Collection.forEach(function(oItem,i){
                                                                                        var strBE = Dencript.Serialized(oItem);
                                                                                            objTxtLst.value += ((i==0)?'':'" + EasyUtilitario.Constantes.Caracteres.Separador.ToString() + @"') + strBE;
                                                                                    });
                                            }
                                            function " + this.ClientID + @"_Remove(oItemBE){
                                                    var idxFind= 0
                                                    " + this.ClientID + @"_Collection.forEach(function(oItem,i){
                                                                                        if(oItemBE." + this.ValueField + @"==oItem." + this.ValueField + @"){
                                                                                         idxFind=i;
                                                                                        }
                                                                                    });
                                                    " + this.ClientID + @"_Collection.Remove(idxFind); 
                                            }

                                          ";

            (new LiteralControl("\n <script>\n" + ScriptItenmSelected + "\n" + "</script>\n")).RenderControl(writer);


            /*----------------------------------------------------------------------------------------*/
            string ScriptMetodos = this.ClientID + @".GetListValue = function(){
                                                                        var lstValues='';
                                                                        " + this.ClientID + @"_Collection.forEach(function(oItem,i){
                                                                            lstValues +=  ((i==0)?'':'" + EasyUtilitario.Constantes.Caracteres.Separador.ToString() + @"') +  oItem." + this.ValueField + @"
                                                                        });
                                                                    return lstValues;
                                                                }
                                    " + this.ClientID + @".GetListText = function(){
                                                                        var lstTexts='';
                                                                        " + this.ClientID + @"_Collection.forEach(function(oItem,i){
                                                                            lstTexts +=  ((i==0)?'':'" + EasyUtilitario.Constantes.Caracteres.Separador.ToString() + @"') +  oItem." + this.DisplayText + @"
                                                                        });
                                                                    return lstTexts;
                                                                }
                                                                ";

             (new LiteralControl("\n <script>\n" + ScriptMetodos + "\n" + "</script>\n")).RenderControl(writer);

        }

        string[] GetData() {
            string[] LstItems = txtLstItems.Text.Split(EasyUtilitario.Constantes.Caracteres.Separador.ToCharArray());
            return LstItems;
        }

        public List<EasyListItem> GetCollection() {
            List< EasyListItem>oCollection = new List< EasyListItem >();   
            string[] LstItems = GetData();
            if (LstItems.Length > 0)
            {
                foreach (string Item in LstItems)
                {
                    EasyListItem oLitem = new EasyListItem();
                    Dictionary<string, string> oData = EasyUtilitario.Helper.Data.SeriaizedDiccionario(Item);
                    oLitem.Text = oData[this.DisplayText];
                    oLitem.Value = oData[this.ValueField];
                    oLitem.DataComplete = oData;
                    oCollection.Add(oLitem);
                }
            }
            return oCollection;
        }

        private bool IsDesign()
        {
            if (this.Site != null)
                return this.Site.DesignMode;
            return false;
        }


    }

}
