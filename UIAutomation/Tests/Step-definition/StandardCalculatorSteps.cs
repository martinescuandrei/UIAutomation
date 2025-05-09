﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll;
using UIAutomation.Keywords;
using UIAutomation.Src.UIA.Services;

namespace UIAutomation.Tests.Step_definition
{
    [Binding]
    public class StandardCalculatorSteps
    {
        private readonly FeatureContext _featureContext;
        private readonly GUITestingContext _contextFeatureWindow;
        private readonly StandardWindowKeywords _standardWindowKeywords;

        public StandardCalculatorSteps(FeatureContext featureContext, GUITestingContext context)
        {
            _featureContext = featureContext;
            _contextFeatureWindow = featureContext["window"] as GUITestingContext;
            _standardWindowKeywords = new StandardWindowKeywords(_contextFeatureWindow);
        }

        [When(@"I add ""([^""]*)"" to ""([^""]*)""")]
        public void WhenIAddTo(string number1, string number2)
        {
            _standardWindowKeywords.AddTwoNumber(int.Parse(number1), int.Parse(number2));
        }

        [Then(@"I verify the result is ""([^""]*)""")]
        public void TheIVerifyTheResult(string result)
        {
            _standardWindowKeywords.VerifyResult(int.Parse(result));
        }
    }
}
