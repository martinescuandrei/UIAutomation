﻿using System;

namespace UIAutomation.Src.UIA.Exceptions
{
    public class GUITestingException : Exception
    {
        public GUITestingException() { }

        public GUITestingException( string message ) : base( message )
        {

        }

        public GUITestingException( string message, Exception inner ) : base( message, inner )
        {

        }
    }
}
