using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.CommonModels;
using UIAutomation.Src.UIA.TestObjects;

namespace UIAutomation.Keywords.CommonMappings
{
    public class ResultWindowsMappings
    {
        private readonly Group _mainGroup;
        public ResultWindowsMappings(Func<Group> mainGroup)
        {
            _mainGroup = mainGroup();
        }
        private Text Result => _mainGroup.FindFirstChild<Text>(automationId: "CalculatorResults");
      
        public ResultWindowsMappings VerifyResult(int result)
        {
            var resultValue = int.Parse(Result.Name.Split('s')[2].Trim());
            Assert.That(result, Is.EqualTo(resultValue));
            return this;
        }
    }
}
