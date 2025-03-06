using UIAutomation.Src.UIA.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UIAutomation.Src.UIA.Utils
{
    /// <summary>
    /// This class is a helper to launch and close applications.
    /// </summary>
	public class GUITestingUtils
    {
        /// <summary>
        /// The application process obtained at launch.
        /// </summary>
        static Process process;
        private readonly GUITestingContext _context;

        public GUITestingUtils( GUITestingContext context )
        {
            this._context = context;
        }

        /// <summary>
        /// This method launches an .exe application with or without arguments.
        /// </summary>
        /// <param name="filePath">Applcation file path.</param>
        /// <param name="args">Launch arguments.</param>
        public static void LaunchApplication( string filePath, string args = "" )
        {
            process = Process.Start( filePath, args );
        }

        /// <summary>
        /// This method closes the application started when the LaunchApplication method was used, or kills an application with given process name.
        /// </summary>
        /// <param name="execName">Applcation process name.</param>
        public static void CloseApplication( string execName = "" )
        {
            if(execName == "")
            {
                process.Kill();
            }
            else
            {
                foreach (Process process in Process.GetProcessesByName( execName ))
                {
                    process.Kill();
                }
            }
        }
    }
}
