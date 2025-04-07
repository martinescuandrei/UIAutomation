using NUnit.Framework;
using UIAutomation.Src.UIA.Services;
using UIAutomation.Src.UIA.Utils;
using System;
using System.IO;
using Reqnroll;

namespace UIAutomation.Src.Utils
{

    public static class UICommonMethods
    {
        public static void SendKeysToUI(string value) {
            System.Windows.Forms.SendKeys.SendWait( value );
            System.Windows.Forms.SendKeys.SendWait( "{ENTER}" );
        }
    }

        
}
