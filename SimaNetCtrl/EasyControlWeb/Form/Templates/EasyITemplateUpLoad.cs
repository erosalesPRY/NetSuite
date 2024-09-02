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
    public class EasyITemplateUpLoad: EasyFormItemTemplate
    {
        public EasyITemplateUpLoad() { }
        public EasyITemplateUpLoad(EasyFormItemTemplate oEasyFormItemTemplate) {
            this.PaginaProceso = oEasyFormItemTemplate.PaginaProceso;
            this.RutaLocalTmp = oEasyFormItemTemplate.RutaLocalTmp;
            this.RutaLocalFinal = oEasyFormItemTemplate.RutaLocalFinal;
            this.HttpFinal = oEasyFormItemTemplate.HttpFinal;
            this.HttpTmp = oEasyFormItemTemplate.HttpTmp;
            this.ImgDelete = oEasyFormItemTemplate.ImgDelete;
            this.TemplateType = oEasyFormItemTemplate.TemplateType;
        }

        [Browsable(false), Bindable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Obsolete("", true)]
        public new string PathImagenDefault { get; set; }

        #region Ocultar Attr EasyITemplateNumericBox
        [Browsable(false), Bindable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Obsolete("", true)]
        public new int NroDecimales { get; set; }
        #endregion

        #region Ocultar Attributos de EasyITemplateTextMultiline
        [Browsable(false), Bindable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Obsolete("", true)]
        public new int NroLineas { get; set; }
        #endregion

        #region Attr AutoComlete
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
