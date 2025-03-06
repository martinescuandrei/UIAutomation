using UIAutomation.Src.UIA.TestObjects.Factories;
using System;

namespace UIAutomation.Src.UIA.Exceptions
{
    public class GUIObjectNotFoundException : GUITestingException
    {
        private const string DefaultMessage = "No object was found with the given properties.";
        private const string DetailedDefaultMessage = "No object was found with the given properties:";

        public GUIObjectNotFoundException() : base( DefaultMessage ){ }
        
        public GUIObjectNotFoundException( UIAutomationCondition condition ) : base( $"{DetailedDefaultMessage} {condition}" )
        {
        }
    }
}
