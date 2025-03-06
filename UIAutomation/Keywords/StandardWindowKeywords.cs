using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAutomation.Keywords.CommonMappings;
using UIAutomation.Src.UIA.Services;

namespace UIAutomation.Keywords
{
    public class StandardWindowKeywords
    {
        private readonly StandardWindowMappings _homeWindowMappings;
        private readonly NumberPadWindowsMappings _numberPadMappings;
        private readonly ResultWindowsMappings _resultWindowsMappings;
        public StandardWindowKeywords(GUITestingContext context) {
            _homeWindowMappings = new StandardWindowMappings(context);
            _numberPadMappings = new NumberPadWindowsMappings(_homeWindowMappings.GetMainGroup());
            _resultWindowsMappings = new ResultWindowsMappings(_homeWindowMappings.GetMainGroup());
        }

        public StandardWindowKeywords AddTwoNumber(int numberOne, int numberTwo) {
            int[] digits = numberOne.ToString().Select(d => int.Parse(d.ToString())).ToArray();
            foreach (int digit in digits)
            {
                _numberPadMappings.PressNumberButton(digit);
            }
            
            _homeWindowMappings.PressSum();

            digits = numberTwo.ToString().Select(d => int.Parse(d.ToString())).ToArray();
            foreach (int digit in digits)
            {
                _numberPadMappings.PressNumberButton(digit);
            }

            _homeWindowMappings.PressEqual();
            return this;
        }

        public StandardWindowKeywords VerifyResult(int result) {
            _resultWindowsMappings.VerifyResult(result);
            return this;
        }
    }
}
