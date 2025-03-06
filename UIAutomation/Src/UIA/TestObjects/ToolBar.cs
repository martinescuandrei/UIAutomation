using UIAutomation.Src.UIA.TestObjects.TestObjectRequisites;
using System.Windows.Automation;

namespace UIAutomation.Src.UIA.TestObjects
{
    /// <summary>
    /// This class represents a ToolBar object from the GUI.
    /// </summary>
	public class ToolBar : TestObjectBase
    {
        /// Constructor with AutomationElement parameter used on test object creation.
        /// Calls the TestObjectBase constructor.
        /// Initializes tab items that can be selected.
        /// </summary>
        /// <param name="element">UIA AutomationElement that corresponds to this instance of the class.</param>
        public ToolBar( AutomationElement element ) : base( element )
        {
        }
    }
}
