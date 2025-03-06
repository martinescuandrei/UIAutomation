using UIAutomation.Src.UIA.TestObjects.TestObjectRequisites;
using System.Windows.Automation;

namespace UIAutomation.Src.UIA.TestObjects
{
    /// <summary>
    /// This class represents a ListItem object from the GUI.
    /// </summary>
    public class DataItem : TestObjectBase
    {
        private ValuePattern _valuePattern => TryGetCurrentPattern<ValuePattern>();

        private SelectionItemPattern _selectionItemPattern => TryGetCurrentPattern<SelectionItemPattern>();
        /// <summary>
        /// Constructor with AutomationElement parameter used on test object creation.
        /// Calls the TestObjectBase constructor.
        /// </summary>
        /// <param name="element">UIA AutomationElement that corresponds to this instance of the class.</param>
        public DataItem( AutomationElement element ) : base( element )
        {
        }


        /// <summary>
        /// This method performs the selection action on the object.
        /// </summary>
        public void Select() => _selectionItemPattern.Select();

        /// <summary>
        /// This method performs the deselection action on the object.
        /// </summary>
        //public void Deselect()
        //{
        //    if(AutoElement.GetCurrentPattern( SelectionItemPattern.Pattern ) is SelectionItemPattern selectionItemPattern)
        //    {
        //        AutomationElement selectionContainer = selectionItemPattern.Current.SelectionContainer;
        //        var selectionPattern = selectionContainer.GetCurrentPattern( SelectionPattern.Pattern ) as SelectionPattern;

        //        if(!(selectionPattern.Current.IsSelectionRequired && selectionPattern.Current.GetSelection().GetLength( 0 ) <= 1) && selectionItemPattern.Current.IsSelected)
        //        {
        //            selectionItemPattern.RemoveFromSelection();
        //        }

        //    }
        //}

        public void Deselect()
        {
            SelectionContainer selectionContainer = new SelectionContainer( _selectionItemPattern.Current.SelectionContainer );
            if(!(selectionContainer.IsSelectionRequired() && selectionContainer.SelectionPattern().Current.GetSelection().GetLength( 0 ) <= 1) && _selectionItemPattern.Current.IsSelected)
            {
                _selectionItemPattern.RemoveFromSelection();
            }
        }

        /// <summary>
        /// This method performs the specific invoke action specific for the object.
        /// For the button object, invoke performs a click action.
        /// </summary>
        public void Invoke()
        {
            if(AutoElement.GetCurrentPattern( InvokePattern.Pattern ) is InvokePattern invokePattern)
            {
                invokePattern.Invoke();
            }
        }

        public void SetValue( string value ) => _valuePattern.SetValue( value );

        public string GetValue() => _valuePattern.Current.Value;
    }
}
