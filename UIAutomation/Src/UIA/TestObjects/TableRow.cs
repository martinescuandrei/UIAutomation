using System.Linq;
using System.Windows.Automation;
using UIAutomation.Src.UIA.Exceptions;
using UIAutomation.Src.UIA.TestObjects.Factories;
using UIAutomation.Src.UIA.TestObjects.TestObjectRequisites;

namespace UIAutomation.Src.UIA.TestObjects
{
    public class TableRow : Custom
    {
        private ValuePattern _valuePattern =>TryGetCurrentPattern<ValuePattern>();

        public TableRow( AutomationElement automationElement ) : base( automationElement ) { }

        public T GetCellOfType<T>( int cellIndex ) where T: TestObjectBase
        {
            var child = FindAllChildren<GUIObject>().Skip( cellIndex ).FirstOrDefault();

            return child == null ? throw new GUIObjectNotFoundException() : ControlFactory.Create<T>( child.AutoElement );
        }
        public bool ContainsValue( string value )
        {
            return _valuePattern.Current.Value.Contains( value );
        }

        public bool ContainsValueAtColumnIndex( string value, int columnIndex )
        {
            return _valuePattern.Current.Value.Split(';')[columnIndex] == value;
        }

        public string GetValue()
        {
            return _valuePattern.Current.Value;
        }

        public void SetValue( string value )
        {
            _valuePattern.SetValue( value );
        }
    }
}