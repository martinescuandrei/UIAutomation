using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll;
using UIAutomation.Keywords.CommonMappings.Navigation;
using UIAutomation.Src.DB;
using UIAutomation.Src.UIA.Services;
using UIAutomation.Src.UIA.TestObjects.TestObjectRequisites;
using UIAutomation.Src.UIA.Utils;

namespace UIAutomation.Tests.Step_definition
{
    [Binding]
    public class CommonSteps
    {
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        private static GUITestingContext _contextFeatureWindow;
        private readonly DBFactory dbFactory;
        private static DBContext _dbContext;
        private static NavigationWindowKeywords _navigationWindowKeywords;

        public CommonSteps(FeatureContext featureContext, GUITestingContext context, ScenarioContext scenarioContext, DBContext dbContext)
        {
            this._featureContext = featureContext;
            this._scenarioContext = scenarioContext;
            _dbContext = dbContext;
            this.dbFactory = new DBFactory();
            _contextFeatureWindow = featureContext["window"] as GUITestingContext;
            _navigationWindowKeywords = new NavigationWindowKeywords(_contextFeatureWindow);
        }


        [Given(@"the application is opened")]
        public void GivenApplicationIsLaunched()
        {
            _contextFeatureWindow.ApplicationName = "Calculator";
            //this._scenarioContext.Add("applicationName", _context.ApplicationName);
            string pathToRoot = ConfigurationManager.AppSettings["E2EExecutableLocation"];
            string pathToSolution = Path.Combine(pathToRoot, $"calc.exe");

            GUITestingUtils.LaunchApplication(pathToSolution);

            _contextFeatureWindow.window = UIRoot.Find(name: _contextFeatureWindow.ApplicationName);
           // this._scenarioContext.Add("window", _context.window);
        }

        [When(@"I navigate to ""([^""]*)""")]
        public void WhenINavigateTo(string calculatorType)
        {
            _navigationWindowKeywords.NavigateTo(calculatorType);
        }

    }
}
