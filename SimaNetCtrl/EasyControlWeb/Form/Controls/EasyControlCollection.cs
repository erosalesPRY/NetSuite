using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Reflection;
using System.Web.UI.WebControls;

namespace EasyControlWeb.Form.Controls
{ 
    public class EasyControlCollection
    {
        public class EasyFormCollectionHistorialEditor : CollectionEditor
        {
            public EasyFormCollectionHistorialEditor(Type type) : base(type)
            {
            }
            protected override bool CanSelectMultipleInstances()
            {
                return true;
            }

            protected override Type CreateCollectionItemType()
            {
                return typeof(EasyNavigatorBE);
            }

        }

        //Colleccion para el GridView
        public class EasyFormCollectionGridButtonEditor : CollectionEditor
        {
            public EasyFormCollectionGridButtonEditor(Type type) : base(type)
            {
            }
            protected override bool CanSelectMultipleInstances()
            {
                return true;
            }

            protected override Type CreateCollectionItemType()
            {
                return typeof(EasyGridButton);
            }

        }


        //Colleccion para el Menu Context
        public class EasyFormCollectionMnuContextButtonEditor : CollectionEditor
        {
            public EasyFormCollectionMnuContextButtonEditor(Type type) : base(type)
            {
            }
            protected override bool CanSelectMultipleInstances()
            {
                return true;
            }

            protected override Type CreateCollectionItemType()
            {
                return typeof(EasyButtonMenuContext);
            }

        }

        public class EasyFormCollectionListViewEditor : CollectionEditor
        {
            public EasyFormCollectionListViewEditor(Type type) : base(type)
            {
            }
            protected override bool CanSelectMultipleInstances()
            {
                return true;
            }

            protected override Type CreateCollectionItemType()
            {
                return typeof(EasyListItem);
            }

        }

        public class EasyCollectionListItemsEditor : CollectionEditor
        {
            public EasyCollectionListItemsEditor(Type type) : base(type)
            {
            }
            protected override bool CanSelectMultipleInstances()
            {
                return true;
            }

            protected override Type CreateCollectionItemType()
            {
                return typeof(EasyListViewItemTipo);
            }

        }

        

        public class EasyFormCollectionButtons : CollectionEditor
        {
            public EasyFormCollectionButtons(Type type) : base(type)
            {
            }
            protected override bool CanSelectMultipleInstances()
            {
                return true;
            }

            protected override Type CreateCollectionItemType()
            {
                return typeof(EasyButton);
            }

        }

        public class EasyFormCollectionUpFilesEditor : CollectionEditor
        {
            public EasyFormCollectionUpFilesEditor(Type type) : base(type)
            {
            }
            protected override bool CanSelectMultipleInstances()
            {
                return true;
            }

            protected override Type CreateCollectionItemType()
            {
                return typeof(EasyFileInfo);
            }

        }

        /*Para el control Tabs*/

        public class EasyFormCollectionTabsItemEditor : CollectionEditor
        {
            public EasyFormCollectionTabsItemEditor(Type type) : base(type)
            {
            }
            protected override bool CanSelectMultipleInstances()
            {
                return true;
            }

            protected override Type CreateCollectionItemType()
            {
                return typeof(EasyTabItem);
            }

        }

    }
}
