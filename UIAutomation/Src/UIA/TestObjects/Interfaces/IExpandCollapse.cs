
namespace UIAutomation.Src.UIA.TestObjects.Interfaces
{
    /// <summary>
    /// This interface is used to describe the collapse expand behavior. 
    /// </summary>
    public interface IExpandCollapse
    {
        /// <summary>
        /// This method performs the expand action on the object.
        /// </summary>
        void Expand();

        /// <summary>
        /// This method performs the collapse action on the object.
        /// </summary>
        void Collapse();
    }
}
