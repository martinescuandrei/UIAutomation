using UIAutomation.Src.UIA.TestObjects.TestObjectRequisites;
using System;
using System.Windows.Automation;

namespace UIAutomation.Src.UIA.TestObjects.Factories
{
    public class ControlFactory
    {
        public static T Create<T>( AutomationElement testObject ) where T: TestObjectBase
        {
            return (T)Activator.CreateInstance( typeof( T ), testObject );
        }
    }
}