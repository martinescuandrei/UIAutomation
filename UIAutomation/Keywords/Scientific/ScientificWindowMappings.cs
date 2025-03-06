using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using UIAutomation.Src.UIA.Services;
using UIAutomation.Src.UIA.TestObjects;

namespace UIAutomation.Keywords.Scientific
{
    public class ScientificWindowMappings
    {
        private static GUITestingContext _context;

        public ScientificWindowMappings(GUITestingContext context)
        {
            _context = context;
        }
        private Window CalculatorWindow => _context.window.FindFirstChild<Window>(className: "Windows.UI.Core.CoreWindow");
        private Custom NavigationView => CalculatorWindow.FindFirstChild<Custom>(automationId: "NavView");
        private Group MainGroup => NavigationView.FindFirstChild<Group>(className: "LandmarkTarget");
        private Group ScientificOperators => MainGroup.FindFirstChild<Group>(name: "Scientific functions");
        private Button SquareRootButton => ScientificOperators.FindFirstChild<Button>(automationId: "squareRootButton");

        public ScientificWindowMappings PressSquareRoot()
        {
            SquareRootButton.Invoke();
            return this;
        }

        public Func<Group> GetMainGroup() => () => MainGroup;
    }
}
