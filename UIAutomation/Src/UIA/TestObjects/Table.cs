using UIAutomation.Src.UIA.TestObjects.TestObjectRequisites;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;

namespace UIAutomation.Src.UIA.TestObjects
{
    /// <summary>
    /// This class represents a Table object from the GUI.
    /// </summary>
    public class Table : TestObjectBase
    {

        /// <summary>
        /// Constructor with AutomationElement parameter used on test object creation.
        /// Calls the TestObjectBase constructor.
        /// </summary>
        /// <param name="element">UIA AutomationElement that corresponds to this instance of the class.</param>
        public Table( AutomationElement element ) : base( element )
        {
        }

        /// <summary>
        ///     Returns the first row of the table with the given row index.
        /// </summary>
        /// <param name="rowIndex">Row index</param>
        /// <returns>The first row with the given row index.</returns>
        public TableRow GetFirstRowByIndex( int rowIndex )
        {
            return FindFirstChild<TableRow>( name: $"Row {rowIndex}" );
        }

        /// <summary>
        ///     Returns the first row of the table with the given value, in any of the row's columns.
        /// </summary>
        /// <param name="value">The value to search for.</param>
        /// <returns>The first row where the value is found.</returns>
        public TableRow GetFirstRowByValue( string value )
        {
            return FindAllChildren<TableRow>().FirstOrDefault( row => row.ContainsValue( value ) );
        }

        public TableRow GetFirstRowByValues( List<string> values )
        {
            return FindAllChildren<TableRow>().FirstOrDefault( row => values.All( value => row.ContainsValue( value ) ) );
        }

        public TableRow GetFirstRowByValueDataPanel( string value )
        {
            return FindAllChildren<TableRow>().FirstOrDefault( row => row.ContainsValue( value ) );
        }

        /// <summary>
        ///     Returns the first row of the table with the given value, in the column with the given index.
        /// </summary>
        /// <param name="value">The value to search for.</param>
        /// <param name="columnIndex">The index of the column to look for the value.</param>
        /// <returns>The first row where the value is found in the specific column.</returns>
        public TableRow GetFirstRowByValueAndColumnIndex( string value, int columnIndex )
        {
            return FindAllChildren<TableRow>().FirstOrDefault( row => row.ContainsValueAtColumnIndex( value, columnIndex ) );
        }

        /// <summary>
        ///     Returns all rows of the table with the given value, in any of the row's columns.
        /// </summary>
        /// <param name="value">The value to search for.</param>
        /// <returns>The rows where the value is found.</returns>
        public IEnumerable<TableRow> GetAllRowsByValue( string value )
        {
            return FindAllChildren<TableRow>().Where( row => row.ContainsValue( value ) );
        }

        /// <summary>
        ///     Returns all rows of the table with the given value, in the column with the given index.
        /// </summary>
        /// <param name="value">The value to search for.</param>
        /// <param name="columnIndex">The index of the column to look for the value.</param>
        /// <returns>The rows where the value is found in the specific column.</returns>
        public IEnumerable<TableRow> GetAllRowsByValueAndColumnIndex( string value, int columnIndex )
        {
            return FindAllChildren<TableRow>().Where( row => row.ContainsValueAtColumnIndex( value, columnIndex ) );
        }


        public List<string> GetAllRowsValues( int columnIndex )
        {
            List<string> editors = new List<string>();
            foreach(TableRow row in FindAllChildren<TableRow>())
            {
                editors.Add( row.GetCellOfType<Editor>( columnIndex ).GetValue() );
            }
            return editors;
        }

        /// <summary>
        ///     Returns table headers
        /// </summary>
        /// <param name="rowIndex">Row index</param>
        /// <returns>The first row with the given row index.</returns>
        public List<Header> GetTableHeaders()
        {
            List<Header> headers = new List<Header>();
            var row = FindFirstChild<TableRow>( name: $"Top Row" );
            foreach(Header header in row.FindAllChildren<Header>())
            {
                headers.Add( header );
            }
            return headers;
        }

        /// <summary>
        ///    Returns the values of the first row of the table.
        /// </summary>
        /// <param name="rowIndex">Row index</param>
        /// <returns>Returns the values of the cells of the first row of the table.</returns>
        /// 
        public List<string> GetTableCells( string rowIndex )
        {
            List<string> cellsValue = new List<string>();
            TableRow tableRow = FindFirstChild<TableRow>( name: $"Row " + rowIndex );
            int nrOfRowColumns = tableRow.FindAllChildren<GUIObject>().Count();

            for(int i = 0; i < nrOfRowColumns; i++)
            {
                cellsValue.Add( tableRow.GetCellOfType<Editor>( i ).GetValue() );
            }

            return cellsValue;
        }
    }
}
