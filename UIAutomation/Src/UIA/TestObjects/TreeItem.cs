using UIAutomation.Src.UIA.TestObjects.Interfaces;
using UIAutomation.Src.UIA.TestObjects.TestObjectRequisites;
using System.Windows.Automation;

namespace UIAutomation.Src.UIA.TestObjects
{
    /// <summary>
    /// This class represents a TreeItem object from the GUI.
    /// </summary>
    public class TreeItem : TestObjectBase, IExpandCollapse
    {
        private ExpandCollapsePattern _expandCollapsePattern => TryGetCurrentPattern<ExpandCollapsePattern>();
        /// <summary>
        /// Constructor with AutomationElement parameter used on test object creation.
        /// Calls the TestObjectBase constructor.
        /// </summary>
        /// <param name="element">UIA AutomationElement that corresponds to this instance of the class.</param>
		public TreeItem( AutomationElement element ) : base( element )
        {

        }

        /// <summary>
        /// This method performs the collapse action on the object.
        /// </summary>
        public void Collapse() => _expandCollapsePattern.Collapse();


        /// <summary>
        /// This method performs the expand action on the object.
        /// </summary>
        public void Expand() => _expandCollapsePattern.Expand();
    }
}
