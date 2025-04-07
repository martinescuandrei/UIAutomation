using NUnit.Framework;
using UIAutomation.Src.UIA.Services;
using UIAutomation.Src.UIA.Utils;
using System;
using System.IO;
using Reqnroll;

namespace UIAutomation.Src.Utils
{
    [Binding]
    internal class Hooks
    {

        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        private static GUITestingContext _contextFeatureWindow;

        public Hooks( FeatureContext featureContext, ScenarioContext scenarioContext )
        {
            _contextFeatureWindow = featureContext["window"] as GUITestingContext;
            this._featureContext = featureContext;
            this._scenarioContext = scenarioContext;
        }

        [AfterFeature]
        public static void CloseApp()
        {
            var dd = _contextFeatureWindow;
            GUITestingUtils.CloseApplication( $"{_contextFeatureWindow.ApplicationName}App");
        }

        [BeforeFeature]
        public static void BeforeFeatureSetup(FeatureContext featureContext)
        {
            featureContext["window"] = new GUITestingContext();
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
                string screenshotFile = _contextFeatureWindow.window?.TakeScreenshot( path );
                TestContext.AddTestAttachment( screenshotFile, "My Screenshot" );
            }
        }
    }
}
