using UIAutomation.Src.UIA.TestObjects.TestObjectRequisites;
using System.Windows.Automation;

namespace UIAutomation.Src.UIA.TestObjects
{
    /// <summary>
    /// This class represents an Editor object from the GUI.
    /// </summary>
    public class ComboBox : TestObjectBase
    {
        private ValuePattern _valuePattern => TryGetCurrentPattern<ValuePattern>();
        /// <summary>
        /// Constructor with AutomationElement parameter used on test object creation.
        /// Calls the TestObjectBase constructor.
        /// </summary>
        /// <param name="element">UIA AutomationElement that corresponds to this instance of the class.</param>
        public ComboBox( AutomationElement element ) : base( element )
        {

        }

        public bool SelectComboboxItem( string item )
        {
            if(AutoElement == null)
            {
                return false;
            }
            // Get the list box within the combobox
            AutomationElement listBox = AutoElement.FindFirst( TreeScope.Children, new PropertyCondition( AutomationElement.ControlTypeProperty, ControlType.List ) );
            if(listBox == null)
            {
                return false;
            }
            // Search for item within the listbox
            AutomationElement listItem = listBox.FindFirst( TreeScope.Children, new PropertyCondition( AutomationElement.NameProperty, item ) );
            if(listItem == null)
            {
                return false;
            }
            // Check if listbox item has SelectionItemPattern
            if(true == listItem.TryGetCurrentPattern( SelectionItemPatternIdentifiers.Pattern, out object objPattern ))
            {
                var selectionItemPattern = objPattern as SelectionItemPattern;
                selectionItemPattern.Select(); // Invoke Selection
                return true;
            }
            return false;
        }
        /// <summary>
        /// This method returns the current value of the object.
        /// </summary>
        /// <returns>Returns the current text inside the object.</returns>
        public string GetValue() => _valuePattern.Current.Value;
    }
}
