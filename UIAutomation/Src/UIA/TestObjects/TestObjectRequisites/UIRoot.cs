using UIAutomation.Src.UIA.Exceptions;
using System;
using System.Threading;
using System.Windows.Automation;

namespace UIAutomation.Src.UIA.TestObjects.TestObjectRequisites
{
    /// <summary>
    /// This class represents the root of the UI which is the desktop.
    /// </summary>
    public class UIRoot
    {
        /// <summary>
        /// This method is used for finding a Window object inside the desktop.
        /// </summary>
        /// <param name="name">The name property of the window to find.</param>
        /// <param name="automationId">The automationId property of the window to find.</param>
        /// <param name="waitSeconds">The time in seconds allowed for the window search.</param>
        /// <returns>Returns a window object with the given properties.</returns>
        public static Window Find( string name = "", string automationId = "", int waitSeconds = 25 )
        {
            int count = 0;
            AutomationElement testObject = null;

            // Validate that at least one identification property is provided
            if(string.IsNullOrEmpty( name ) && string.IsNullOrEmpty( automationId ))
            {
                throw new GUITestingException( "Cannot find window without given properties." );
            }

            // Create conditions for name and automationId
            Condition nameCondition = !string.IsNullOrEmpty( name )
                ? new PropertyCondition( AutomationElementIdentifiers.NameProperty, name )
                : null;

            Condition autoIdCondition = !string.IsNullOrEmpty( automationId )
                ? new PropertyCondition( AutomationElementIdentifiers.AutomationIdProperty, automationId )
                : null;

            // Combine conditions if both are provided
            Condition combinedCondition = nameCondition != null && autoIdCondition != null
                ? new AndCondition( nameCondition, autoIdCondition )
                : nameCondition ?? autoIdCondition; // Use whichever condition is available

            // Try to find the element within the wait time
            do
            {
                testObject = AutomationElement.RootElement.FindFirst( TreeScope.Children, combinedCondition );

                Console.WriteLine( $"DEBUG: Looking for name: {name}, autoId: {automationId}. Attempt {count + 1}." );
                count++;
                Thread.Sleep( 100 );
            }
            while(testObject == null && count < 50 * waitSeconds);

            // Throw an error if the element is not found within the time limit
            if(testObject == null)
            {
                Console.WriteLine( $"DEBUG: Could not find object with specified properties." );
                throw new ArgumentNullException( nameof( testObject ), "No window found with the given properties." );
            }

            // Return the found window
            return new Window( testObject );
        }
    }
}
