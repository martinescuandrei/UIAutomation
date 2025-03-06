using System;

namespace UIAutomation.Src.UIA.Exceptions
{
    public class MultipleObjectsFoundException : GUITestingException
    {

        public MultipleObjectsFoundException() { }

        public MultipleObjectsFoundException( string message ) : base( message )
        {

        }
        public MultipleObjectsFoundException( string message, Exception inner ) : base( message, inner )
        {

        }
    }
}
