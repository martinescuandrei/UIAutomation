
using UIAutomation.Src.UIA.TestObjects.TestObjectRequisites;
using System.Windows.Automation;
using UIAutomation.Src.UIA.TestObjects.Factories;

namespace UIAutomation.Src.UIA.TestObjects
{
    /// <summary>
    /// This class represents any from the GUI that does not have a class in the GUITestingSDK.
    /// </summary>
    public class Group : TestObjectBase
    {
        /// <summary>
        /// Constructor with AutomationElement parameter used on test object creation.
        /// Calls the TestObjectBase constructor.
        /// </summary>
        /// <param name="element">UIA AutomationElement that corresponds to this instance of the class.</param>
        public Group( AutomationElement element ) : base( element )
        {
        }
    }
}