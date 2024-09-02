﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using static EasyControlWeb.Form.Editor.EasyFormColletionsEditor; 

namespace EasyControlWeb
{
    [TypeConverter(typeof(Type_EasyGridViewGroupRow))]
    [Serializable]
    public class EasyGridRowGroup
    {

        private int groupedDepth;
        [RefreshProperties(RefreshProperties.All)]
        [NotifyParentProperty(true)]
        public int GroupedDepth
        {
            get {
                return groupedDepth;
            }
            set { groupedDepth = value; }
        }

        private int colIniRowMerge;
        [RefreshProperties(RefreshProperties.All)]
        [NotifyParentProperty(true)]
        public int ColIniRowMerge {
            get { return colIniRowMerge; }
            set { colIniRowMerge = value; }
        }
        public EasyGridRowGroup() { }
        public EasyGridRowGroup(int _GroupedDepth, int _ColIniRowMerge) {
            this.GroupedDepth = _GroupedDepth;
            this.ColIniRowMerge = _ColIniRowMerge;
        }

    }
}
