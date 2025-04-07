using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using UIAutomation.Src.UIA.Services;
using UIAutomation.Src.UIA.TestObjects;

namespace UIAutomation.Keywords.CommonMappings
{
    public class NavigationWindowMappings
    {
        private static GUITestingContext _context;

        public NavigationWindowMappings(GUITestingContext context)
        {
            _context = context;
        }
        private Window CalculatorWindow => _context.window.FindFirstChild<Window>(className: "Windows.UI.Core.CoreWindow");
        private Custom NavigationView => CalculatorWindow.FindFirstChild<Custom>(automationId: "NavView");
        private Group NavigationList => NavigationView.FindFirstChild<Window>(automationId: "PaneRoot")
                                                       .FindFirstChild<Pane>(automationId: "MenuItemsScrollViewer")
                                                       .FindFirstChild<Group>(automationId: "MenuItemsHost");
        private Button NavigationBar => NavigationView.FindFirstChild<Button>(automationId: "TogglePaneButton");

        private ListItem CalculatorType(string calculatorType) => NavigationList.FindFirstChild<ListItem>(automationId: calculatorType);

        public NavigationWindowMappings OpenNavigationBar()
        {
            NavigationBar.Invoke();
            return this;
        }

        public NavigationWindowMappings NavigateTo(string calculatorType)
        {
            CalculatorType(calculatorType).Select(); ;
            return this;
        }
    }
}
