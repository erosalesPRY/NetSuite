using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using EasyControlWeb.Filtro;

namespace EasyControlWeb.Form.Templates
{
    [TypeConverter(typeof(Type_FormItemTemplate))]
    [Serializable]
    public class EasyITemplateTextMultiline : EasyFormItemTemplate
    {
        public EasyITemplateTextMultiline() { }

        public EasyITemplateTextMultiline(EasyFormItemTemplate oEasyFormItemTemplate) {
            this.NroLineas = oEasyFormItemTemplate.NroLineas;
            this.TemplateType = oEasyFormItemTemplate.TemplateType;
        }

        public string ToString(bool InfoProp)
        {
            return this.NroLineas.ToString();
        }

        /*******************************************************HIDDEN*************************************************/
            #region Ocultar Attr EasyITemplateNumericBox
            [Browsable(false), Bindable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Obsolete("", true)]
            public new int NroDecimales { get; set; }
            #endregion

            #region Ocultar Attributos de NumericBox y DatePicker
            [Browsable(false), Bindable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Obsolete("", true)]
            public new string PathImagenDefault { get; set; }
            #endregion

            #region Ocultar Attributos de EasyItemplateUpLoad
            [Browsable(false), Bindable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Obsolete("", true)]
            public new string PaginaProceso { get; set; }
            [Browsable(false), Bindable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Obsolete("", true)]
            public new string RutaLocalTmp { get; set; }
            [Browsable(false), Bindable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Obsolete("", true)]
            public new string RutaLocalFinal { get; set; }
            [Browsable(false), Bindable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Obsolete("", true)]
            public new string HttpFinal { get; set; }
            [Browsable(false), Bindable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Obsolete("", true)]
            public new string HttpTmp { get; set; }
            [Browsable(false), Bindable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Obsolete("", true)]
            public new string ImgDelete { get; set; }
        #endregion

            #region Attr AutoComplete
            [Browsable(false), Bindable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Obsolete("", true)]
            public new string PathImagenLoanding { get; set; }
            [Browsable(false), Bindable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Obsolete("", true)]
            public new string UrlWebServiceMetodo { get; set; }
            [Browsable(false), Bindable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Obsolete("", true)]
            public new string FieldValue { get; set; }
            [Browsable(false), Bindable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Obsolete("", true)]
            public new string FieldText { get; set; }
            [Browsable(false), Bindable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Obsolete("", true)]
            public new int NroCarIni { get; set; }
            [Browsable(false), Bindable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Obsolete("", true)]
            public new List<EasyFiltroParamURLws> EasyFiltroParamsURLws { get; }
            #endregion
    }
}
