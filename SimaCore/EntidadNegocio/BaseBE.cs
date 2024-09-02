using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Utilitario;

namespace EntidadNegocio
{
    [Serializable]
    public class BaseBE
    {
        public string Descripcion { get; set; }
        public string Observacion { get; set; }
        public int IdEstado { get; set; }
        public string ImgEstado { get; set; }
        public string NombreEstado { get; set; }

        public string UserName { get; set; }
        public string IdCodigo { get; set; }
        /*public Char IdCodigoChar { get; set; }*/
        public int IdUsuario { get; set; }

        public string Token { get; set; }

        public string ambiente { get; set; }


        public override string ToString()
        {
            int idx = 0;
            string Structura = "";
            foreach (var propertyInfo in this.GetType().GetProperties())
            {
                Structura += ((idx == 0) ? "" : Constante.Caracteres.SeperadorSimple) + propertyInfo.Name + Constante.Caracteres.Igual + propertyInfo.GetValue(this, propertyInfo.GetIndexParameters());
                idx++;
            }
            return Structura;
        }
        public string ToCliente()
        {
            int idx = 0;
            string Structura = "";
            foreach (var propertyInfo in this.GetType().GetProperties())
            {
                Structura += ((idx == 0) ? "" : Constante.Caracteres.Coma) + propertyInfo.Name + Constante.Caracteres.DosPunto + propertyInfo.GetValue(this, propertyInfo.GetIndexParameters());
                idx++;
            }
            return "{" + Structura + "}";
        }
        public string[] ToString(bool AttAndVal)
        {
            string strSataBE = this.ToString().Replace(Constante.Caracteres.SeperadorSimple, "@");
            string[] AttVal = strSataBE.Split('@');


            return AttVal;
        }

        public string Atributos()
        {
            StringBuilder strLog = new StringBuilder();
            Type typeData = this.GetType();
            FieldInfo[] fields = typeData.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (FieldInfo field in fields)
            {
                if (field.GetValue(this) != null)
                {
                    strLog.Append(field.Name.ToString() + Constante.Caracteres.Igual + field.GetValue(this).ToString() + Constante.Caracteres.Coma);
                }
                else
                {
                    strLog.Append(field.Name.ToString() + Constante.Caracteres.Igual + " " + Constante.Caracteres.Coma);
                }
            }
            return strLog.ToString().Substring(1, strLog.ToString().Length - 1);
        }
        public string EntityToSerializedXML()
        {
            const string returnCarr = "\r\n";

            string cmll = Utilitario.Constante.Caracteres.ComillasDobles;
            Type typeData = this.GetType();
            int idx = 0;
            string Structura = "<" + typeData.Name + " xmlns:xsd=" + cmll + "http://www.w3.org/2001/XMLSchema" + cmll + " xmlns:xsi=" + cmll + "http://www.w3.org/2001/XMLSchema-instance" + cmll + " xmlns=" + cmll + "http://tempuri.org/" + cmll + ">";
            Structura += returnCarr;
            foreach (var propertyInfo in typeData.GetProperties())
            {
                if (propertyInfo.GetValue(this, propertyInfo.GetIndexParameters()) != null)
                {
                    Structura += "<" + propertyInfo.Name.ToString() + ">" + propertyInfo.GetValue(this, propertyInfo.GetIndexParameters()) + "</" + propertyInfo.Name.ToString() + ">";
                }
                else
                {
                    Structura += "<" + propertyInfo.Name.ToString() + "/>";
                }
                Structura += returnCarr;
            }
            Structura += "<" + typeData.Name + "/>";
            return Structura;
        }

    }

}
