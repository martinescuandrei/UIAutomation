using UIAutomation.Src.UIA.TestObjects;

namespace UIAutomation.Src.UIA.Services
{

    public class GUITestingContext
    {
        public GUITestingContext()
        {
        }
        public string ApplicationName { get; set; }
        public Window window { get; set; }
        public string DbConfiguration { get; set; }
        public string User { get; set; }
        public string Domain { get; set; }
        public string AnalyteShortName {  get; set; }
        public string AnalyteName { get; set; }
        public string Unit { get; set; }
    }
}


