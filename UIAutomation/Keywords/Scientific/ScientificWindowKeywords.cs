using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAutomation.Keywords.CommonMappings;
using UIAutomation.Src.UIA.Services;

namespace UIAutomation.Keywords.Scientific
{
    public class ScientificWindowKeywords
    {
        private readonly ScientificWindowMappings _scientificWindowMappings;
        private readonly NumberPadWindowsMappings _numberPadMappings;
        public ScientificWindowKeywords(GUITestingContext context)
        {
            _scientificWindowMappings = new ScientificWindowMappings(context);
            _numberPadMappings = new NumberPadWindowsMappings(_scientificWindowMappings.GetMainGroup());
        }

        public ScientificWindowKeywords CalculateSquareRoot(string number) {
            int[] digits = number.Select(d => int.Parse(d.ToString())).ToArray();
            foreach (int digit in digits)
            {
                _numberPadMappings.PressNumberButton(digit);
            }
            _scientificWindowMappings.PressSquareRoot();

            return this;
        }

    }
}
