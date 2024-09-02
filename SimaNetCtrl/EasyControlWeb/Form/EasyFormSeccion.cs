using EasyControlWeb.Form.Editor;
using EasyControlWeb.Form.Templates;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace EasyControlWeb.Form
{
    [Serializable]
    public class EasyFormSeccion
    {
        #region Propiedades
         public string Titulo { get; set; }

          
        [Browsable(false)]
        List<Control> _ItemsCtrl;

        [Editor(typeof(EasyFormColletionsEditor.AllItemsControls), typeof(UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Description("Contiene todos los controles necesarios en una List collection")]
        [Category("Behaviour"),
         PersistenceMode(PersistenceMode.InnerProperty)
        ]
        public List<Control> ItemsCtrl
        {
            get
            {
                if (_ItemsCtrl == null)
                {
                    _ItemsCtrl = new List<Control>();
                }
                return _ItemsCtrl;
            }
        }


        #endregion



        public EasyFormSeccion() : this(String.Empty){ }
        
        public EasyFormSeccion(string _Titulo)
        {
            Titulo = _Titulo;
        }







    }
}
