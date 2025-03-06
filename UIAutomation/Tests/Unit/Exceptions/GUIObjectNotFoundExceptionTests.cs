using NUnit.Framework;
using UIAutomation.Src.UIA.Exceptions;
using UIAutomation.Src.UIA.TestObjects;
using UIAutomation.Src.UIA.TestObjects.Factories;

namespace UIAutomation.Tests.Unit.Exceptions
{
    [TestFixture]
    public class GUIObjectNotFoundExceptionTests
    {
        [Test]
        public void Constructor_WithCondition()
        {
            UIAutomationCondition condition = ConditionFactory.Create( typeof(Button), "name", "automationId", "value", "className", true );

            var exception = new GUIObjectNotFoundException( condition );

            Assert.That( exception, Is.Not.Null );
            Assert.That( exception.Message, Is.EqualTo( "No object was found with the given properties:  ControlType = button | Name = name | AutomationId = automationId | Value = value | ClassName = className | IsEnabled = True |" ) );
        }

        [Test]
        public void Constructor_WithSomeConditions()
        {
            UIAutomationCondition condition = ConditionFactory.Create( typeof(Button), automationId: "automationId");

            var exception = new GUIObjectNotFoundException( condition );

            Assert.That( exception, Is.Not.Null );
            Assert.That( exception.Message, Is.EqualTo( "No object was found with the given properties:  ControlType = button | AutomationId = automationId |" ) );
        }

        [Test]
        public void Constructor_WithEmptyCondition()
        {
            UIAutomationCondition condition = ConditionFactory.Create();

            var exception = new GUIObjectNotFoundException( condition );

            Assert.That( exception, Is.Not.Null );
            Assert.That( exception.Message, Is.EqualTo( "No object was found with the given properties: Always true condition." ) );
        }
    }
}