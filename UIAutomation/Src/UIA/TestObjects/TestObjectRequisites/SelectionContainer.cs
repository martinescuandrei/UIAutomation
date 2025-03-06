using System.Windows.Automation;

namespace UIAutomation.Src.UIA.TestObjects.TestObjectRequisites
{
    internal class SelectionContainer : TestObjectBase
    {
        private SelectionPattern _selectionPattern => TryGetCurrentPattern<SelectionPattern>();
        public SelectionContainer( AutomationElement automationElement ): base( automationElement )
        {  
        }

        public bool IsSelectionRequired() => _selectionPattern.Current.IsSelectionRequired;
        public SelectionPattern SelectionPattern() => _selectionPattern;
    }
}
