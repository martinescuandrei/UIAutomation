using System.Windows.Automation;
using UIAutomation.Src.UIA.TestObjects.TestObjectRequisites;

namespace UIAutomation.Src.UIA.TestObjects
{
    public class Custom : TestObjectBase
    {
        private ValuePattern _valuePattern => TryGetCurrentPattern<ValuePattern>();

        private InvokePattern _invokePattern => TryGetCurrentPattern<InvokePattern>();

        public Custom( AutomationElement automationElement ) : base( automationElement ) {
        
        }
        public void SetValue( string value ) => _valuePattern.SetValue( value );

        public string GetValue() => _valuePattern.Current.Value;

        public void Invoke() => _invokePattern.Invoke();
    }
}