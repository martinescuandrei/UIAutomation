using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAutomation.Src.UIA.Services;

namespace UIAutomation.Keywords.CommonMappings.Navigation
{
    public class NavigationWindowKeywords
    {
        private readonly NavigationWindowMappings _navigationWindowMappings;
        public NavigationWindowKeywords(GUITestingContext context)
        {
            _navigationWindowMappings = new NavigationWindowMappings(context);
        }

        public NavigationWindowKeywords NavigateTo(string calculatorType) {
            _navigationWindowMappings.OpenNavigationBar()
                                     .NavigateTo(calculatorType);
            return this; 
        }

    }
}
