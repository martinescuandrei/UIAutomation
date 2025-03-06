using NUnit.Framework;
using UIAutomation.Src.UIA.Services;
using UIAutomation.Src.UIA.Utils;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace UIAutomation.Src.Utils
{
    [Binding]
    internal class Hooks
    {

        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        private static GUITestingContext _context;

        public Hooks( FeatureContext featureContext, GUITestingContext context, ScenarioContext scenarioContext )
        {
            this._featureContext = featureContext;
            this._scenarioContext = scenarioContext;
            _context = context;
            _context.ApplicationName = this._scenarioContext.Get<string>( "applicationName" );
        }

        [AfterScenario]
        public static void CloseApp()
        {
            GUITestingUtils.CloseApplication( $"{_context.ApplicationName}App");
        }

        [AfterStep]
        public void AfterStep()
        {
            if(this._scenarioContext.TestError != null)
            {
                //var pathToRoot = ConfigurationManager.AppSettings["E2EExecutableLocation"];
                //var screenshotFile =  _context.window?.TakeScreenshot( pathToRoot );

                //var pathToRoot = ConfigurationManager.AppSettings["E2EExecutableLocation"];

                string path = Path.GetDirectoryName( AppDomain.CurrentDomain.BaseDirectory );
                string screenshotFile = _context.window?.TakeScreenshot( path );
                TestContext.AddTestAttachment( screenshotFile, "My Screenshot" );
            }
        }
    }
}
