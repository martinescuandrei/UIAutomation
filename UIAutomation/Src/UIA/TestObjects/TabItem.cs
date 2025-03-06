using UIAutomation.Src.UIA.TestObjects.TestObjectRequisites;
using System.Windows.Automation;

namespace UIAutomation.Src.UIA.TestObjects
{
    /// <summary>
    /// This class represents a Tab object from the GUI.
    /// </summary>
	public class TabItem : TestObjectBase
    {
        private SelectionItemPattern _selectionPattern => TryGetCurrentPattern<SelectionItemPattern>();
        /// Constructor with AutomationElement parameter used on test object creation.
        /// Calls the TestObjectBase constructor.
        /// Initializes tab items that can be selected.
        /// </summary>
        /// <param name="element">UIA AutomationElement that corresponds to this instance of the class.</param>
        public TabItem( AutomationElement element ) : base( element )
        {
        }

        public void Select() => _selectionPattern.Select();
    }
}
