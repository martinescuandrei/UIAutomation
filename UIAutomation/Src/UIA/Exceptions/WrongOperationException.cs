using System;

namespace UIAutomation.Src.UIA.Exceptions
{
    class WrongOperationException : GUITestingException
    {
        public WrongOperationException() { }

        public WrongOperationException( string message ) : base( message )
        {

        }
        public WrongOperationException( string message, Exception inner ) : base( message, inner )
        {

        }
    }
}
