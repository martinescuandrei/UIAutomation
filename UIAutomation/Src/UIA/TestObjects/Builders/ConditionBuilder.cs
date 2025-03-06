using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;
using UIAutomation.Src.UIA.Exceptions;

namespace UIAutomation.Src.UIA.TestObjects.Builders
{
    public class ConditionBuilder
    {
        private readonly List<Condition> _conditions = new List<Condition>();

        public ConditionBuilder WithName(string name)
        {
            _conditions.Add(new PropertyCondition(AutomationElement.NameProperty, name));
            return this;
        }

        public ConditionBuilder WithAutomationId(string automationId)
        {
            _conditions.Add(new PropertyCondition(AutomationElement.AutomationIdProperty, automationId));
            return this;
        }

        public ConditionBuilder WithValue(string value)
        {
            _conditions.Add(new PropertyCondition(AutomationProperty.LookupById(30045), value));
            return this;
        }

        public ConditionBuilder WithClassName(string className)
        {
            _conditions.Add(new PropertyCondition(AutomationElement.ClassNameProperty, className));
            return this;
        }

        public ConditionBuilder WithIsEnabled(bool isEnabled)
        {
            _conditions.Add(new PropertyCondition(AutomationElement.IsEnabledProperty, isEnabled));
            return this;
        }

        public ConditionBuilder WithControlType( ControlType controlType )
        {
            _conditions.Add( new PropertyCondition( AutomationElement.ControlTypeProperty, controlType ) );
            return this;
        }

        public Condition Build()
        {
            if( _conditions == null || !_conditions.Any() )
            {
                return Condition.TrueCondition;
            }

            return _conditions.Count == 1 ? _conditions.First() : new AndCondition( _conditions.ToArray() );
        }
    }
}