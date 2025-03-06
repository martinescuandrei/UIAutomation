using System.Linq;
using UIAutomation.Src.UIA.Exceptions;
using UIAutomation.Src.UIA.TestObjects.Interfaces;
using UIAutomation.Src.UIA.TestObjects.TestObjectRequisites;
using System.Windows.Automation;

namespace UIAutomation.Src.UIA.TestObjects
{
    /// <summary>
    /// This class represents a Tab object from the GUI.
    /// </summary>
	public class Tab : TestObjectBase, ISelection
    {
        private SelectionItemPattern _selectionItemPattern => TryGetCurrentPattern<SelectionItemPattern>();

        // private readonly List<TabItem> tabItems;

        /// Constructor with AutomationElement parameter used on test object creation.
        /// Calls the TestObjectBase constructor.
        /// Initializes tab items that can be selected.
        /// </summary>
        /// <param name="element">UIA AutomationElement that corresponds to this instance of the class.</param>
        public Tab( AutomationElement element ) : base( element )
        {
            //this.tabItems = FindAllChildren<TabItem>().ToList();
        }

        public TabItem GetTabItem( int index )
        {
            var child = FindAllChildren<TabItem>().Skip( index ).FirstOrDefault();
            return child == null ? throw new GUIObjectNotFoundException() : child;
        }

        public TabItem GetTabItem( string value )
        {
            var child = FindAllChildren<TabItem>().FirstOrDefault( item => item.Name.Equals( value ));  
            return child == null ? throw new GUIObjectNotFoundException() : child;
        }

        /// <summary>
        /// This method performs the selection action on the item at the given index inside this object.
        /// </summary>
        /// <param name="index"></param>
        public void Select( int index ) => GetTabItem( index).Select();

        /// <summary>
        /// This method performs the selection action on the item with the given text inside this object.
        /// </summary>
        /// <param name="text"></param>
        public void Select( string text ) => GetTabItem( text ).Select();
    }
}
