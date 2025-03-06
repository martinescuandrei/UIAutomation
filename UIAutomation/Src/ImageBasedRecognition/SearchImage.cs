using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace UIAutomation.Src.ImageBasedRecognition
{
    public static class SearchImageFactory
    {
        //The .dll must be in the same folder as the app
        //You can also use [DllImport("C:\\full\\path\\to\\dll.dll")]
        [DllImport( "ImageSearchDLL.dll" )]
        private static extern IntPtr ImageSearch( int x, int y, int right, int bottom, [MarshalAs( UnmanagedType.LPStr )] string imagePath );


        public static ImageSearchResult SearchImage( string imgFullPath, int tolerance = 0 )
        {
            //Don't delete the space
            imgFullPath = $"*{tolerance} {imgFullPath}";

            IntPtr result = ImageSearch( 1, 1, Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height, imgFullPath );
            string res = Marshal.PtrToStringAnsi( result );

            if(string.IsNullOrEmpty( res ) || res[0] == '0')
            {
                return null;
            }

            string[] data = res.Split( '|' );
            int.TryParse( data[1], out int x );
            int.TryParse( data[2], out int y );
            int.TryParse( data[3], out int width );
            int.TryParse( data[4], out int height );

            var rectangle = new System.Windows.Rect
            {
                Width = width,
                Height = height
            };

            return new ImageSearchResult( x, y, rectangle );
        }

        public static ImageSearchResult FindImage( string imageFullPath, int timeOut = 15 )
        {
            ImageSearchResult result = null;

            for(int i = 0; i < timeOut; i++)
            {
                result = SearchImageFactory.SearchImage( imageFullPath, tolerance: 0 );
                if(result != null)
                {
                    break;
                }

                Thread.Sleep( 1000 );
            }
            return result;
        }
    }
}