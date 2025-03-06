using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAutomation.Src.UIA.Services;
using UIAutomation.Src.UIA.TestObjects;

namespace UIAutomation.Keywords.CommonMappings
{
    public class NumberPadWindowsMappings
    {
        private readonly Group _mainGroup;
        public NumberPadWindowsMappings(Func<Group> mainGroup)
        {
            _mainGroup = mainGroup();
        }
        private Group NumberPad => _mainGroup.FindFirstChild<Group>(automationId: "NumberPad");
        private Button NumberButton(int number) => NumberPad.FindFirstChild<Button>(automationId: $"num{number}Button");

        public NumberPadWindowsMappings PressNumberButton(int number)
        {
            NumberButton(number).Invoke();
            return this;
        }
    }
}
