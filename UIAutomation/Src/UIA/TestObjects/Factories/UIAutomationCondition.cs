using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Automation;

namespace UIAutomation.Src.UIA.TestObjects.Factories
{
    public class UIAutomationCondition
    {
        public UIAutomationCondition( Condition compiledCondition )
        {
            CompiledCondition = compiledCondition;
        }

        public Condition CompiledCondition { get; set; }

        public List<Condition> ComponentConditions { get; set; }

        public override string ToString()
        {
            if( CompiledCondition == Condition.TrueCondition )
            {
                return "Always true condition.";
            }

            if( CompiledCondition == Condition.FalseCondition )
            {
                return "Always false condition.";
            }

            return CompiledCondition.ToStringEnhanced();
        }
    }

    public static class ConditionExtensions 
    {
        private static T GetFieldValue<T>(this object obj, string name) {
            var field = obj.GetType().GetField(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            return (T)field?.GetValue(obj);
        }

        public static string ToStringEnhanced( this Condition condition )
        {
            var conditions = condition.GetFieldValue<Condition[]>( "_conditions" );

            if( conditions == null || !conditions.Any() )
            {
                return "No filtered properties.";
            }

            var conditionText = string.Empty;
            foreach( Condition componentCondition in conditions )
            {
                if( componentCondition is PropertyCondition propertyComponentCondition )
                {
                    var conditionName = propertyComponentCondition.Property.ProgrammaticName
                        .Replace($"{nameof(AutomationElementIdentifiers)}.", string.Empty)
                        .Replace($"{nameof(ValuePatternIdentifiers)}.", string.Empty)
                        .Replace("Property", string.Empty);

                    var value = string.Empty;
                    switch( true )
                    {
                        case true when propertyComponentCondition.Property == AutomationElementIdentifiers.ControlTypeProperty:
                            value = ControlType.LookupById( (int)propertyComponentCondition.Value )?.LocalizedControlType ?? "null";
                            break;
                        default:
                            value = propertyComponentCondition.Value.ToString();
                            break;
                    }

                    conditionText += $" {conditionName} = {value} |";
                }
            }

            return conditionText;
        }
    }
}