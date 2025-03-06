using Microsoft.Test.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAutomation.Src.MouseInteraction
{
    public static class MouseInteraction
    {

        public static void ClickWithCoordinates( int X, int Y , System.Windows.Rect rectangle )
        {
            int x = (int)rectangle.X + (int)rectangle.Width / 2;
            int y = (int)rectangle.Y + (int)rectangle.Height / 2;
            Point point = new Point( x, y );

            Mouse.MoveTo( point );
            Mouse.Click( MouseButton.Left );
        }
    }


}