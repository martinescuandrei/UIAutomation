using UIAutomation.Src.UIA.Exceptions;
using UIAutomation.Src.UIA.TestObjects.Interfaces;
using UIAutomation.Src.UIA.TestObjects.TestObjectRequisites;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Automation;

namespace UIAutomation.Src.UIA.TestObjects
{
    /// <summary>
    /// This class represents a Menu object from the GUI.
    /// </summary>
	public class Menu : TestObjectBase, ISelection
    {
        /// <summary>
        /// Constructor with AutomationElement parameter used on test object creation.
        /// Calls the TestObjectBase constructor.
        /// Initializes menu items that can be selected.
        /// </summary>
        /// <param name="element">UIA AutomationElement that corresponds to this instance of the class.</param>
        public Menu( AutomationElement element ) : base( element )
        {
        }

        public MenuItem GetMenuItem( int index )
        {
            var child = FindAllChildren<MenuItem>().Skip( index ).FirstOrDefault();
            return child == null ? throw new GUIObjectNotFoundException() : child;
        }

        public MenuItem GetMenuItem( string value )
        {
            var child = FindAllChildren<MenuItem>().FirstOrDefault( item => item.Name.Equals( value ) );
            return child == null ? throw new GUIObjectNotFoundException() : child;
        }

        /// <summary>
        /// This method performs the selection action on the item at the given index inside this object.
        /// </summary>
        /// <param name="index"></param>
        public void Select( int index ) => GetMenuItem( index ).Select();

        /// <summary>
        /// This method performs the selection action on the item with the given text inside this object.
        /// </summary>
        /// <param name="text"></param>
        public void Select( string text ) => GetMenuItem( text ).Select();
    }
}
