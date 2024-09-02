using Controladora.General;
using EntidadNegocio;
using EntidadNegocio.GestionFinanciera.Tesoreria.Pagos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WSCore.General
{
    public static class ExtendBE

    {

        public static PlanCabProv SetAttrValue(this PlanCabProv oPlanCabProv, DataRow dr)
        {
            SetAttr(oPlanCabProv, dr);
            return oPlanCabProv;
        }
        public static PlanDetProv SetAttrValue(this PlanDetProv oPlanDetProv, DataRow dr)
        {
            SetAttr(oPlanDetProv, dr);
            return oPlanDetProv;
        }

        public static Archivo SetAttrValue(this Archivo oArchivo, DataRow dr)
        {
            SetAttr(oArchivo, dr);
            return oArchivo;
        }


        public static DetDocBenef SetAttrValue(this DetDocBenef oDetDocBenef, DataRow dr)
        {
            SetAttr(oDetDocBenef, dr);
            return oDetDocBenef;
        }


        /*Utilizado cuando las clases sean extendidas*/
        #region Metodos de Extension


        private static void SetAttr(this object obj,  DataRow drValor)
        {
            string FieldName = "";
            string Atributo = "";
            string NomCls = obj.GetType().Name;
            DataTable dtProperty = (new cClaseExtend()).ListarPropiedades(NomCls,"SIMANetSuite");
            if ((dtProperty != null) && (dtProperty.Rows.Count > 0))
            {
                foreach (DataRow rowAttrib in dtProperty.Rows)
                {
                    string ValoPropiedad = "";
                    string TipoPropiedad = "";
                    try
                    {
                        Atributo = rowAttrib["PROPIEDAD"].ToString();
                        FieldName = rowAttrib["Field"].ToString();

                        ValoPropiedad = drValor[FieldName].ToString().TrimEnd();
                        //Busca Obligatoriedad del atributo

                        var property = obj.GetType().GetProperty(Atributo); //Crea el atributo de la clase
                        TipoPropiedad = property.PropertyType.ToString();
                        ConvertValueRefProperty(obj, Atributo, ValoPropiedad);
                    }
                    catch (Exception oex)
                    {
                        //EntidadBE.LogBE.EscribeMsg("500", "02:", "ERROR:= por atributo mal definido en el MAPEO" + obj.ToString() + Utilitario.Constantes.Caracter.IGUAL + Atributo + Utilitario.Constantes.Caracter.IGUAL + ValoPropiedad + " || CAMPO" + Utilitario.Constantes.Caracter.IGUAL + FieldName + "|| TIPO" + Utilitario.Constantes.Caracter.IGUAL + TipoPropiedad + "  " + Environment.NewLine + " ERROR:" + oex.Message + Environment.NewLine + Environment.NewLine);
                    }

                }
            }
            else
            {
                //Registrar en el Log  Mensaje de error falta mapear campos con atributos
                //EntidadBE.LogBE.EscribeMsg("500", "02:", "oComprobante:Falta el mapeo del siguiente atributo del Query[" + FieldName + "]");
            }
        }

        public static void ConvertValueRefProperty(this object obj, string propertyName, string pValoPropiedad)
            {
                PropertyInfo oProperty = obj.GetType().GetProperty(propertyName);
                string PropType = oProperty.PropertyType.ToString();
                if (PropType == "System.DateTime")
                {
                    oProperty.SetValue(obj, Convert.ToDateTime(pValoPropiedad), null);
                }
                else if (PropType == "System.Nullable`1[System.DateTime]")
                {
                    var typedVal = NullableSafeChangeType(pValoPropiedad, oProperty.PropertyType);

                    if (!string.IsNullOrEmpty(pValoPropiedad))
                        oProperty.SetValue(obj, typedVal, null);
                }
                else if (PropType == "System.Decimal")
                {
                    oProperty.SetValue(obj, Convert.ToDecimal(pValoPropiedad), null);
                }
                else if (PropType == "System.Nullable`1[System.Decimal]")
                {
                    var typedVal = NullableSafeChangeType(pValoPropiedad, oProperty.PropertyType);

                    if (!string.IsNullOrEmpty(pValoPropiedad))
                        oProperty.SetValue(obj, typedVal, null);

                }
                else if (PropType == "System.String")
                {
                    oProperty.SetValue(obj, pValoPropiedad.ToString(), null);
                }
                else if (PropType == "System.Int16")
                {
                    oProperty.SetValue(obj, Convert.ToInt16(pValoPropiedad), null);

                }
                else if (PropType == "System.Int32")
                {
                    oProperty.SetValue(obj, Convert.ToInt32(pValoPropiedad), null);

                }
            }

            static object NullableSafeChangeType(string input, Type type)
            {
                Type underlyingType = Nullable.GetUnderlyingType(type);
                if (underlyingType == null) // Non-nullable; convert directly
                {
                    return Convert.ChangeType(input, type);
                }
                else
                {
                    return input == null || input == "" ? null
                        : Convert.ChangeType(input, underlyingType);
                }
            }

        #endregion

    }
}
