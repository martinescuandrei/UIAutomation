using UIAutomation.Src.UIA.TestObjects.Interfaces;
using UIAutomation.Src.UIA.TestObjects.TestObjectRequisites;
using System.Windows.Automation;

namespace UIAutomation.Src.UIA.TestObjects
{
    /// <summary>
    /// This class represents a CheckBox object from the GUI.
    /// </summary>
    public class CheckBox : TestObjectBase, IToggle
    {
        private TogglePattern _togglePattern => TryGetCurrentPattern<TogglePattern>();
        private InvokePattern _invokePattern => TryGetCurrentPattern<InvokePattern>();

        /// <summary>
        /// Constructor with AutomationElement parameter used on test object creation.
        /// Calls the TestObjectBase constructor.
        /// </summary>
        /// <param name="element">UIA AutomationElement that corresponds to this instance of the class.</param>
        public CheckBox( AutomationElement element ) : base( element )
        {
        }

        /// <inheritdoc/>
        /// <remarks>
        /// For the check box object, toggle performs a check action if the checkbox is not checked, and an uncheck action if the check box is checked.
        /// </remarks>
        public void Toggle()
        {
            if( _togglePattern != null )
            {
                _togglePattern.Toggle();
                return;
            }

            if( _invokePattern != null )
            {
                _invokePattern.Invoke();
                return;
            }

        }

    }
}
