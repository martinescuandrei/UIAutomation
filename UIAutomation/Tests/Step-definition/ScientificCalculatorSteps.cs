using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UIAutomation.Keywords;
using UIAutomation.Keywords.Scientific;
using UIAutomation.Src.UIA.Services;

namespace UIAutomation.Tests.Step_definition
{
    [Binding]
    public  class ScientificCalculatorSteps
    {
        private readonly FeatureContext _featureContext;
        private readonly GUITestingContext _context;
        private readonly ScientificWindowKeywords _scientificWindowKeywords;

        public ScientificCalculatorSteps(FeatureContext featureContext, GUITestingContext context)
        {
            _featureContext = featureContext;
            _context = context;
            _scientificWindowKeywords = new ScientificWindowKeywords(_context);
        }

        [When(@"I calculate the square root for ""([^""]*)""")]
        public void WhenICalculateTheSquareRootFor(string number)
        {
            _scientificWindowKeywords.CalculateSquareRoot(number);
        }

    }
}
