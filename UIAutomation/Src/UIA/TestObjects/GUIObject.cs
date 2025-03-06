
using UIAutomation.Src.UIA.TestObjects.TestObjectRequisites;
using System.Windows.Automation;

namespace UIAutomation.Src.UIA.TestObjects
{
    /// <summary>
    /// This class represents any from the GUI that does not have a class in the GUITestingSDK.
    /// </summary>
    public class GUIObject : TestObjectBase
    {
        /// <summary>
        /// Constructor with AutomationElement parameter used on test object creation.
        /// Calls the TestObjectBase constructor.
        /// </summary>
        /// <param name="element">UIA AutomationElement that corresponds to this instance of the class.</param>
        public GUIObject( AutomationElement element ) : base( element )
        {
        }
    }
}