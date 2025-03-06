using UIAutomation.Src.UIA.TestObjects.Interfaces;
using UIAutomation.Src.UIA.TestObjects.TestObjectRequisites;
using System.Windows.Automation;

namespace UIAutomation.Src.UIA.TestObjects
{
    /// <summary>
    /// This class represents a Button object from the GUI.
    /// </summary>
    public class Button : TestObjectBase, IInvoke
    {
        private InvokePattern _invokePattern => TryGetCurrentPattern<InvokePattern>();
        /// <summary>
        /// Constructor with AutomationElement parameter used on test object creation.
        /// Calls the TestObjectBase constructor.
        /// </summary>
        /// <param name="element">UIA AutomationElement that corresponds to this instance of the class.</param>
        public Button( AutomationElement element ) : base( element )
        {

        }

        /// <summary>
        /// This method performs the specific invoke action specific for the object.
        /// For the button object, invoke performs a click action.
        /// </summary>
        public void Invoke() => _invokePattern.Invoke();
    }
}
