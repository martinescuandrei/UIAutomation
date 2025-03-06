using UIAutomation.Src.UIA.TestObjects.Interfaces;
using UIAutomation.Src.UIA.TestObjects.TestObjectRequisites;
using System.Windows.Automation;

namespace UIAutomation.Src.UIA.TestObjects
{
    /// <summary>
    /// This class represents a Label object from the GUI.
    /// </summary>
    public class Text : TestObjectBase, IValue
    {
        private ValuePattern _valuePattern => TryGetCurrentPattern<ValuePattern>();
        /// <summary>
        /// Constructor with AutomationElement parameter used on test object creation.
        /// Calls the TestObjectBase constructor.
        /// </summary>
        /// <param name="element">UIA AutomationElement that corresponds to this instance of the class.</param>
        public Text( AutomationElement element ) : base( element )
        {

        }

        /// <summary>
        /// This method returns the current value of the object.
        /// </summary>
        /// <returns>Returns the current text inside the object.</returns>
        public string GetValue() => _valuePattern.Current.Value;

        /// <summary>
        /// This method returns the read-only state of the object.
        /// </summary>
        /// <returns>Returns true if the object is read-only, false otherwise.</returns>
        public bool IsReadOnly() => _valuePattern.Current.IsReadOnly;

        /// <summary>
        /// This method sets the value of an object if the value is not read-only.
        /// </summary>
        /// <param name="value">The value to be set.</param>
        public void SetValue( string value ) => _valuePattern.SetValue( value );
    }
}
