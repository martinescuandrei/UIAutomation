using System;
using UIAutomation.Src.UIA.TestObjects.Builders;
using UIAutomation.Src.UIA.TestObjects.Mappers;

namespace UIAutomation.Src.UIA.TestObjects.Factories
{
    public static class ConditionFactory
    {
        public static UIAutomationCondition Create( Type type = null, string name = null, string automationId = null, string value = null, string className = null,
            bool? isEnabled = null )
        {
            var builder = new ConditionBuilder();

            if( type != null )
            {
                var guiElementType = GUIElementTypeMapper.MapType( type );
                var controlType = ControlTypeMapper.MapGUIElementType( guiElementType );

                if( controlType != null )
                {
                    builder.WithControlType( controlType );
                }
            }

            if( !string.IsNullOrWhiteSpace( name ) )
            {
                builder.WithName( name );
            }

            if( !string.IsNullOrWhiteSpace( automationId ) )
            {
                builder.WithAutomationId( automationId );
            }

            if( !string.IsNullOrWhiteSpace( value ) )
            {
                builder.WithValue( value );
            }

            if( !string.IsNullOrWhiteSpace( className ) )
            {
                builder.WithClassName( className );
            }

            if( isEnabled != null )
            {
                builder.WithIsEnabled( isEnabled.Value );
            }

            return new UIAutomationCondition( builder.Build() );
        }
    }
}