using UIAutomation.Src.UIA.TestObjects.Interfaces;
using UIAutomation.Src.UIA.TestObjects.TestObjectRequisites;
using System.Windows.Automation;

namespace UIAutomation.Src.UIA.TestObjects
{
    /// <summary>
    /// This class represents a ListItem object from the GUI.
    /// </summary>
    public class MenuItem : TestObjectBase, ISelectionItem
    {
        private SelectionItemPattern _selectionItemPattern => TryGetCurrentPattern<SelectionItemPattern>();
        /// <summary>
        /// Constructor with AutomationElement parameter used on test object creation.
        /// Calls the TestObjectBase constructor.
        /// </summary>
        /// <param name="element">UIA AutomationElement that corresponds to this instance of the class.</param>
        public MenuItem( AutomationElement element ) : base( element )
        {

        }

        /// <summary>
        /// This method performs the selection action on the object.
        /// </summary>
        public void Select() => _selectionItemPattern.AddToSelection();

        /// <summary>
        /// This method performs the deselection action on the object.
        /// </summary>
        public void Deselect()
        {
                SelectionContainer selectionContainer = new SelectionContainer( _selectionItemPattern.Current.SelectionContainer);
                if(!(selectionContainer.IsSelectionRequired() && selectionContainer.SelectionPattern().Current.GetSelection().GetLength(0) <=1 ) && _selectionItemPattern.Current.IsSelected)
                {
                    _selectionItemPattern.RemoveFromSelection();
                }
        }
    }
}
