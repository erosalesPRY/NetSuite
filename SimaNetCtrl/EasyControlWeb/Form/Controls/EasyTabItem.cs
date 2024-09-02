using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Resources;

namespace EasyControlWeb.Form.Controls
{

    [Serializable]
    public  class EasyTabItem
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
        public string Imagen{ get; set; }
        public string Width { get; set; }

        public EasyTabItem() { }
        public EasyTabItem(string _Id,string _Text,string _Value ,string _Imagen ,string _Width ) {
            this.Id = _Id;
            this.Text = _Text;
            this.Value = _Value;
            this.Imagen = _Imagen;
            this.Width = _Width;
        }
    }
}
