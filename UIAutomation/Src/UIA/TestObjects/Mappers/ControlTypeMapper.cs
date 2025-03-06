using UIAutomation.Src.UIA.TestObjects.TestObjectRequisites;
using System.Windows.Automation;

namespace UIAutomation.Src.UIA.TestObjects.Mappers
{
    public static class ControlTypeMapper
    {
        /// <summary>
        /// This method converts the GUITestingSDK type to a UIA Automation.ControlType. Used internally to map objects.
        /// </summary>
        /// <param name="elementType"></param>
        /// <returns>Returns a UIA ControlType. </returns>
        public static ControlType MapGUIElementType( GUIElementType elementType )
        {
            switch (elementType)
            {
                case GUIElementType.Button:
                    return ControlType.Button;

                case GUIElementType.ComboBox:
                    return ControlType.ComboBox;

                case GUIElementType.DataItem:
                    return ControlType.DataItem;

                case GUIElementType.CheckBox:
                    return ControlType.CheckBox;

                case GUIElementType.Window:
                    return ControlType.Window;

                case GUIElementType.List:
                    return ControlType.List;

                case GUIElementType.ListItem:
                    return ControlType.ListItem;

                case GUIElementType.Editor:
                    return ControlType.Edit;

                case GUIElementType.Document:
                    return ControlType.Document;

                case GUIElementType.Table:
                    return ControlType.Table;

                case GUIElementType.Pane:
                    return ControlType.Pane;

                case GUIElementType.TableItem:
                    return ControlType.Edit; //must change the logic for specific frameworks

                case GUIElementType.GUIObject:
                    return null;

                case GUIElementType.Group:
                    return ControlType.Group;

                case GUIElementType.HyperLink:
                    return ControlType.Hyperlink;

                case GUIElementType.Text:
                    return ControlType.Text;

                case GUIElementType.Menu:
                    return ControlType.MenuBar; //or menu, more testing needed

                case GUIElementType.Slider:
                    return ControlType.Slider;

                case GUIElementType.Tab:
                    return ControlType.Tab;

                case GUIElementType.ToolBar:
                    return ControlType.ToolBar;

                case GUIElementType.TabItem:
                    return ControlType.TabItem;

                case GUIElementType.Tree:
                    return ControlType.Tree;

                case GUIElementType.TreeItem:
                    return ControlType.TreeItem;

                case GUIElementType.RadioButton:
                    return ControlType.RadioButton;

                case GUIElementType.Header:
                    return ControlType.Header;

                case GUIElementType.Custom:
                    return ControlType.Custom;

                case GUIElementType.TableRow:
                    return ControlType.Custom;

                default:
                    return ControlType.Custom;
            }
        }
    }
}
