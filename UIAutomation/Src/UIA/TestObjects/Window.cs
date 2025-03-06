using UIAutomation.Src.UIA.TestObjects.Interfaces;
using UIAutomation.Src.UIA.TestObjects.TestObjectRequisites;
using System.Windows.Automation;

namespace UIAutomation.Src.UIA.TestObjects
{
    /// <summary>
    /// This class represents a Window object from the GUI.
    /// </summary>
    public class Window : TestObjectBase, IWindow
    {

        private WindowPattern _windowPattern => TryGetCurrentPattern<WindowPattern>();
        /// <summary>
        /// Constructor with AutomationElement parameter used on test object creation.
        /// Calls the TestObjectBase constructor.
        /// </summary>
        /// <param name="element">UIA AutomationElement that corresponds to this instance of the class.</param>
        public Window( AutomationElement element ) : base( element )
        {

        }

        /// <summary>
        /// This method performs the close action on the object.
        /// </summary>
        public void Close() => _windowPattern.Close();

        /// <summary>
        /// This method returns the top-most state of the object.
        /// </summary>
        /// <returns>If the object is on top on the desktop, returns true. Returns false otherwise.</returns>
        public bool IsTopMost() => _windowPattern.Current.IsTopmost;

        /// <summary>
        /// This method returns the canMinimize property of the object.
        /// </summary>
        /// <returns>Returns true if the object can be minimized. Returns false otherwise.</returns>
        public bool CanMinimize() => _windowPattern.Current.CanMinimize;


        /// <summary>
        /// This method returns the canMaximize property of the object.
        /// </summary>
        /// <returns>Returns true if the object can be maximized. Returns false otherwise.</returns>
        public bool CanMaximize() => _windowPattern.Current.CanMaximize;

        public void Maximize()
        {
            if(_windowPattern.Current.CanMaximize)
            {
                _windowPattern.SetWindowVisualState( WindowVisualState.Maximized );
            }
        }

        public void SetVisualStateNormal()
        {
            if(_windowPattern.Current.CanMaximize)
            {
                _windowPattern.SetWindowVisualState( WindowVisualState.Normal );
            }
        }
    }
}
