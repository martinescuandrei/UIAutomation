using System;
using UIAutomation.Src.UIA.TestObjects.TestObjectRequisites;

namespace UIAutomation.Src.UIA.TestObjects.Mappers
{
    public static class GUIElementTypeMapper
    {
        public static GUIElementType MapType( Type controlType )
        {
            switch(controlType)
            {
                case Type _ when controlType == typeof( Button ):
                    return GUIElementType.Button;

                case Type _ when controlType == typeof( Header ):
                    return GUIElementType.Header;

                case Type _ when controlType == typeof( ComboBox ):
                    return GUIElementType.ComboBox;

                case Type _ when controlType == typeof( DataItem ):
                    return GUIElementType.DataItem;

                case Type _ when controlType == typeof( CheckBox ):
                    return GUIElementType.CheckBox;

                case Type _ when controlType == typeof( Window ):
                    return GUIElementType.Window;

                case Type _ when controlType == typeof( List ):
                    return GUIElementType.List;

                case Type _ when controlType == typeof( ListItem ):
                    return GUIElementType.ListItem;

                case Type _ when controlType == typeof( Editor ):
                    return GUIElementType.Editor;

                case Type _ when controlType == typeof( Table ):
                    return GUIElementType.Table;

                case Type _ when controlType == typeof( TableItem ):
                    return GUIElementType.TableItem;

                case Type _ when controlType == typeof( GUIObject ):
                    return GUIElementType.GUIObject;

                case Type _ when controlType == typeof( HyperLink ):
                    return GUIElementType.HyperLink;

                case Type _ when controlType == typeof( Text ):
                    return GUIElementType.Text;

                case Type _ when controlType == typeof( Menu ):
                    return GUIElementType.Menu;

                case Type _ when controlType == typeof( Slider ):
                    return GUIElementType.Slider;

                case Type _ when controlType == typeof( Tab ):
                    return GUIElementType.Tab;

                case Type _ when controlType == typeof( ToolBar ):
                    return GUIElementType.ToolBar;

                case Type _ when controlType == typeof( TabItem ):
                    return GUIElementType.TabItem;

                case Type _ when controlType == typeof( Tree ):
                    return GUIElementType.Tree;

                case Type _ when controlType == typeof( TreeItem ):
                    return GUIElementType.TreeItem;

                case Type _ when controlType == typeof( RadioButton ):
                    return GUIElementType.RadioButton;

                case Type _ when controlType == typeof( Pane ):
                    return GUIElementType.Pane;

                case Type _ when controlType == typeof( HyperLink ):
                    return GUIElementType.HyperLink;

                case Type _ when controlType == typeof( Custom ):
                    return GUIElementType.Custom;

                case Type _ when controlType == typeof( TableRow ):
                    return GUIElementType.Custom;

                default:
                    return GUIElementType.GUIObject;
            }
        }
    }
}