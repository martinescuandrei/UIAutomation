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
    /// This class represents a List object from the GUI.
    /// </summary>
	public class List : TestObjectBase, ISelection
    {
        /// <summary>
        /// Constructor with AutomationElement parameter used on test object creation.
        /// Calls the TestObjectBase constructor.
        /// </summary>
        /// <param name="element">UIA AutomationElement that corresponds to this instance of the class.</param>
        public List( AutomationElement element ) : base( element )
        {
        }

        public ListItem GetListItem( int index )
        {
            var child = FindAllChildren<ListItem>().Skip( index ).FirstOrDefault();
            return child == null ? throw new GUIObjectNotFoundException() : child;
        }

        public ListItem GetListItem( string value )
        {
            var child = FindAllChildren<ListItem>().FirstOrDefault( item => item.Name.Equals( value ) );
            return child == null ? throw new GUIObjectNotFoundException() : child;
        }

        /// <summary>
        /// This method performs the selection action on the item at the given index inside this object.
        /// </summary>
        /// <param name="index"></param>
        public void Select( int index ) => GetListItem( index ).Select();

        /// <summary>
        /// This method performs the selection action on the item with the given text inside this object.
        /// </summary>
        /// <param name="text"></param>
        public void Select( string text ) => GetListItem( text ).Select();
    }
}
