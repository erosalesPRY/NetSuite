using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Security.Permissions;
using System.Web;

namespace EasyControlWeb.Form.Controls
{
    [
           AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal),
           AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal),
           DefaultProperty("Placeholder"),
           ParseChildren(true, "Placeholder"),
           ToolboxData("<{0}:EasyTabControl runat=server></{0}:EasyTabControl")
       ]
    public  class EasyTabControl :CompositeControl
    {
        #region Declaracion de variables y Objetos de uso interno 
        public HtmlTable ossTab;
        #endregion


        #region Propiedades

        [Category("Mensaje"), Description("")]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.All)]
        [NotifyParentProperty(true)]
        public string Placeholder { get; set; }


        [Browsable(false)]
        List<EasyTabItem> oEasyTabItem;

        [Editor(typeof(EasyControlCollection.EasyFormCollectionTabsItemEditor), typeof(UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Description("Contiene los items de tabs definidos")]
        [Category("Behaviour"),
         PersistenceMode(PersistenceMode.InnerProperty)
        ]
        [RefreshProperties(RefreshProperties.All)]
        [NotifyParentProperty(true)]
        public List<EasyTabItem> LstTabs
        {
            get
            {
                if (oEasyTabItem == null)
                {
                    oEasyTabItem = new List<EasyTabItem>();
                }
                return oEasyTabItem;
            }
        }

        #endregion



        #region Constructor
        public EasyTabControl() : this(String.Empty) { }

        public EasyTabControl(string Formato)
        {
            oEasyTabItem = new List<EasyTabItem>();
        }
        #endregion


        #region Fragmento de Control
        HtmlTable Tabcontainer() {
            try
            {
                if (oEasyTabItem != null)
                {
                    ossTab = EasyUtilitario.Helper.HtmlControlsDesign.CrearTabla(2, 1);
                    ossTab.ID = "head_" + this.ClientID;
                    ossTab.Style.Add("Width", "100%");
                    ossTab.Style.Add("padding-top", "5px");
                    ossTab.Style.Add("padding-left", "5px");
                    ossTab.Rows[0].Cells[0].Style.Add("Width", "100%");
                    foreach (EasyTabItem item in oEasyTabItem)
                    {
                        HtmlTable tblItem = EasyUtilitario.Helper.HtmlControlsDesign.CrearTabla(1, 2);
                        // tblItem.Attributes["class"] = this.CssClass;
                        HtmlImage oimg = new HtmlImage(); //EasyUtilitario.Helper.HtmlControlsDesign.CrearImagen(item.Imagen);
                        oimg.Attributes["Width"] = item.Width;
                        tblItem.Rows[0].Cells[0].Controls.Add(oimg);
                        tblItem.Rows[0].Cells[0].Style.Add("padding-left", "5px");
                        tblItem.Rows[0].Cells[1].InnerHtml = item.Text;

                        ossTab.Rows[0].Cells[0].Controls.Add(tblItem);
                    }
                }
            }
            catch(Exception ex) {
                ossTab = new HtmlTable();
                ossTab.Rows[0].Cells[0].InnerText = ex.Message;
                return ossTab;
            }
            return ossTab;
        }

            
        #endregion



        #region Eventos Propios
        protected override void OnInit(EventArgs e)
        {
           // base.OnInit(e);
        }

        protected override void CreateChildControls()
        {
            this.Controls.Clear();
        }
      
        #endregion

        protected override void Render(HtmlTextWriter writer)
        {
            if (!IsDesign())
            {

                  Tabcontainer().RenderControl(writer);
                //(new LiteralControl("TabControl")).RenderControl(writer);
            }
            else
            {
                (new LiteralControl("TabControl")).RenderControl(writer);
            }
        }



        #region Metodos de Apoyo
        private bool IsDesign()
        {
            if (this.Site != null)
                return this.Site.DesignMode;
            return false;
        }
        #endregion

    }
}
