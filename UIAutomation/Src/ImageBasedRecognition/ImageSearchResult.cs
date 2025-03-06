using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UIAutomation.Src.ImageBasedRecognition
{
    public class ImageSearchResult
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Rect Rectangle { get; set; }

        public ImageSearchResult( int x, int y , Rect rectangle)
        {
            X = x;
            Y = y;
            Rectangle = rectangle;
        }
    }
}
