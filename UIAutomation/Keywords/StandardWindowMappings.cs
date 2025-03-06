using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAutomation.Keywords.CommonMappings;
using UIAutomation.Src.UIA.Services;
using UIAutomation.Src.UIA.TestObjects;

namespace UIAutomation.Keywords
{
    public class StandardWindowMappings
    {
        private static GUITestingContext _context;

        public StandardWindowMappings(GUITestingContext context)
        {
            _context = context;
        }

        private Window CalculatorWindow => _context.window.FindFirstChild<Window>(className: "Windows.UI.Core.CoreWindow");
        private Custom NavigationView => CalculatorWindow.FindFirstChild<Custom>(automationId: "NavView");
        private Group MainGroup => NavigationView.FindFirstChild<Group>(className: "LandmarkTarget");
        private Group StandardOperators => MainGroup.FindFirstChild<Group>(automationId: "StandardOperators");
        private Button Sum => StandardOperators.FindFirstChild<Button>(automationId: "plusButton");
        private Button Equal => StandardOperators.FindFirstChild<Button>(automationId: "equalButton");


        public StandardWindowMappings PressSum()
        {
            Sum.Invoke();
            return this;
        }

        public StandardWindowMappings PressEqual()
        {
            Equal.Invoke();
            return this;
        }
        public Func<Group> GetMainGroup() => () => MainGroup;

    }
}
