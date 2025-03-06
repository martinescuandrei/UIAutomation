using UIAutomation.Src.UIA.TestObjects.TestObjectRequisites;
using System.Collections.Generic;
using System.Windows.Automation;

namespace UIAutomation.Src.UIA.TestObjects
{
    /// <summary>
    /// This class represents a Table object from the GUI.
    /// </summary>
    public class DataGrid : TestObjectBase
    {
        /// <summary>
        /// Constructor with AutomationElement parameter used on test object creation.
        /// Calls the TestObjectBase constructor.
        /// </summary>
        /// <param name="element">UIA AutomationElement that corresponds to this instance of the class.</param>
        public DataGrid( AutomationElement element ) : base( element )
        {

        }
        /// <summary>
        /// This method returns the column count of the object.
        /// This action is not supported in WinForms dataGrid controls.
        /// </summary>
        /// <returns>Returns the number of columns.</returns>
        public int GetColumnCount()
        {
            if(AutoElement.GetCurrentPattern( GridPattern.Pattern ) is GridPattern gridPattern)
            {
                return gridPattern.Current.ColumnCount;
            }
            else
            {
                if(AutoElement.GetCurrentPattern( TablePattern.Pattern ) is TablePattern tablePattern)
                {
                    return tablePattern.Current.ColumnCount;
                }
            }

            return 0;
        }

        /// <summary>
        /// This method returns the row count of the object.
        /// This action is not supported in WinForms dataGrid controls.
        /// </summary>
        /// <returns>Returns the number of rows.</returns>
        public int GetRowCount()
        {
            if(AutoElement.GetCurrentPattern( GridPattern.Pattern ) is GridPattern gridPattern)
            {
                return gridPattern.Current.RowCount;
            }
            else
            {
                if(AutoElement.GetCurrentPattern( TablePattern.Pattern ) is TablePattern tablePattern)
                {
                    return tablePattern.Current.RowCount;
                }
            }
            return 0;
        }

        /// <summary>
        /// This method returns the row headers of the object.
        /// This action is not supported in WinForms dataGrid controls.
        /// </summary>
        /// <returns>Returns an array with the object row headers.</returns>
        public string[] GetRowHeaders()
        {
            if(AutoElement.GetCurrentPattern( TablePattern.Pattern ) is TablePattern tablePattern)
            {
                var headers = new List<string>();
                AutomationElement[] elements = tablePattern.Current.GetRowHeaders();
                foreach(AutomationElement elem in elements)
                {
                    headers.Add( elem.Current.Name );
                }
                return headers.ToArray();
            }
            return null;
        }

        /// <summary>
        /// This method returns the column headers of the object.
        /// This action is not supported in WinForms dataGrid controls.
        /// </summary>
        /// <returns>Returns an array with the object column headers.</returns>
        public string[] GetColumnHeaders()
        {
            if(AutoElement.GetCurrentPattern( TablePattern.Pattern ) is TablePattern tablePattern)
            {
                var headers = new List<string>();
                AutomationElement[] elements = tablePattern.Current.GetColumnHeaders();
                foreach(AutomationElement elem in elements)
                {
                    headers.Add( elem.Current.Name );
                }
                return headers.ToArray();
            }
            return null;
        }

        /// <summary>
        /// This method returns a TableItem object inside the table, with the given row and column indexes.
        /// </summary>
        /// <param name="rowindex">TableItem row index</param>
        /// <param name="columnIndex">TableItem column index</param>
        /// <returns></returns>
        public TableItem GetItem( int rowindex, int columnIndex )
        {
            if(AutoElement.GetCurrentPattern( GridPattern.Pattern ) is GridPattern gridPattern)
            {
                return new TableItem( gridPattern.GetItem( rowindex, columnIndex ) );
            }
            return null;
        }


        private AutomationElement GetTableElement()
        {
            // The control type we're looking for; in this case 'Document'  
            var cond1 =
                new PropertyCondition(
                AutomationElement.ControlTypeProperty,
                ControlType.Table );

            // The control pattern of interest; in this case 'TextPattern'.  
            var cond2 =
                new PropertyCondition(
                AutomationElement.IsTablePatternAvailableProperty,
                true );

            var tableCondition = new AndCondition( cond1, cond2 );

            AutomationElement targetTableElement =
                AutoElement.FindFirst( TreeScope.Descendants, tableCondition );

            // If targetTableElement is null then a suitable table control  
            // was not found.  
            return targetTableElement;
        }

        //private void SetTableItemEventListeners()
        //{
        //    AutomationFocusChangedEventHandler tableItemFocusChangedListener =
        //        new AutomationFocusChangedEventHandler(AutoElement);
        //    Automation.AddAutomationFocusChangedEventHandler(
        //        tableItemFocusChangedListener);
        //}
    }
}
