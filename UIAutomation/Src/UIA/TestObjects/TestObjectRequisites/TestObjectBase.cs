using Microsoft.Test.Input;
using UIAutomation.Src.UIA.Exceptions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;
using UIAutomation.Src.UIA.TestObjects.Factories;


namespace UIAutomation.Src.UIA.TestObjects.TestObjectRequisites
{
    /// <summary>
    /// This class represents the base for all test objects.
    /// </summary>
    public class TestObjectBase
    {
        /// <summary>
        /// The AutomationElement that corresponds to a test object.
        /// </summary>
        public AutomationElement AutoElement { get; set; }

        /// <summary>
        /// The object process id that usually matches the id for the parent window.
        /// </summary>
        public int ProcessId => AutoElement.Current.ProcessId;

        /// <summary>
        /// The object name.
        /// </summary>
        public string Name => AutoElement.Current.Name;

        /// <summary>
        /// The object value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The object UI Automation automation id
        /// </summary>
        public string AutomationId => AutoElement.Current.AutomationId;

        /// <summary>
        /// The object isEnabled property
        /// </summary>
        public bool IsEnabled => AutoElement.Current.IsEnabled;

        /// <summary>
        /// The object frameworkId (WinForms, WPF etc.)
        /// </summary>
        public string FrameworkId => AutoElement.Current.FrameworkId;


        /// <summary>
        /// Constructor with AutomationElement parameter used on test object creation.
        /// Initializes the properties from the given AutomationElement.
        /// </summary>
        /// <param name="automationElement">UIA AutomationElement that corresponds to this instance of the class.</param>
        protected TestObjectBase( AutomationElement automationElement )
        {
            AutoElement = automationElement ?? throw new ArgumentNullException( nameof(automationElement) );
        }

        public T FindFirstChild<T>( string name = null, string automationId = null, string value = null, string className = null, bool? isEnabled = null, int numberOfRetries = 5 )  where T: TestObjectBase
        {
            return FindFirstInScope<T>( TreeScope.Children, name, automationId, value, className, isEnabled, numberOfRetries );
        }

        public T FindFirstDescendant<T>( string name = null, string automationId = null, string value = null, string className = null, bool? isEnabled = null, int numberOfRetries = 5 )  where T: TestObjectBase
        {
            return FindFirstInScope<T>( TreeScope.Descendants, name, automationId, value, className, isEnabled, numberOfRetries );
        }

        public IEnumerable<T> FindAllChildren<T>( string name = null, string automationId = null, string value = null, string className = null, bool? isEnabled = null, int numberOfRetries = 5 )  where T: TestObjectBase
        {
            return FindAllInScope<T>( TreeScope.Children, name, automationId, value, className, isEnabled, numberOfRetries );
        }

        public IEnumerable<T> FindAllDescendants<T>( string name = null, string automationId = null, string value = null, string className = null, bool? isEnabled = null, int numberOfRetries = 5 )  where T: TestObjectBase
        {
            return FindAllInScope<T>( TreeScope.Descendants, name, automationId, value, className, isEnabled, numberOfRetries );
        }

        private T FindFirstInScope<T>( TreeScope scope, string name, string automationId, string value, string className, bool? isEnabled = null, int numberOfRetries = 5 )  where T: TestObjectBase
        {
            if( AutoElement == null )
            {
                throw new ArgumentNullException( nameof(AutoElement) );
            }

            UIAutomationCondition condition = ConditionFactory.Create( typeof(T), name, automationId, value, className, isEnabled );
            
            for( var retryCount = 0; retryCount < numberOfRetries; retryCount++ )
            {
                AutomationElement foundControl = AutoElement.FindFirst( scope, condition.CompiledCondition );

                if( foundControl != null )
                {
                    return ControlFactory.Create<T>( foundControl );
                }

                Thread.Sleep( 500 );
            }

            throw new GUIObjectNotFoundException( condition );
        }

        private IEnumerable<T> FindAllInScope<T>( TreeScope scope, string name, string automationId, string value, string className, bool? isEnabled = null, int numberOfRetries = 5 )  where T: TestObjectBase
        {
            if( AutoElement == null )
            {
                throw new ArgumentNullException( nameof(AutoElement) );
            }

            UIAutomationCondition condition = ConditionFactory.Create( typeof(T), name, automationId, value, className, isEnabled );

            var foundControlsCount = 0;
            for( var retryCount = 0; retryCount < numberOfRetries && foundControlsCount == 0; retryCount++ )
            {
                AutomationElementCollection foundControls = AutoElement.FindAll( scope, condition.CompiledCondition );

                if( foundControls != null && foundControls.Count > 0 )
                {
                    foreach( AutomationElement foundControl in foundControls )
                    {
                        foundControlsCount++;
                        yield return ControlFactory.Create<T>( foundControl );
                    }
                }

                Thread.Sleep( 500 );
            }

            if( foundControlsCount == 0 )
            {
                throw new GUIObjectNotFoundException( condition );
            }
        }

        protected TPattern TryGetCurrentPattern<TPattern>() where TPattern : BasePattern
        {
            AutomationPattern pattern = null;

            switch( true )
            {
                //TODO: Add other patterns that derive from <cref="BasePattern"/>
                case true when typeof(TPattern) == typeof(TogglePattern): pattern = TogglePattern.Pattern; break;
                case true when typeof(TPattern) == typeof(InvokePattern): pattern = InvokePattern.Pattern; break;
                case true when typeof(TPattern) == typeof(ValuePattern): pattern = ValuePattern.Pattern; break;
                case true when typeof(TPattern) == typeof(SelectionPattern): pattern = SelectionPattern.Pattern; break;
                case true when typeof(TPattern) == typeof(SelectionItemPattern): pattern = SelectionItemPattern.Pattern; break;
                case true when typeof(TPattern) == typeof( ExpandCollapsePattern ): pattern = ExpandCollapsePattern.Pattern; break;
                case true when typeof(TPattern) == typeof( WindowPattern ): pattern = WindowPattern.Pattern; break;
                case true when typeof(TPattern) == typeof( GridItemPattern ): pattern = GridItemPattern.Pattern; break;
                case true when typeof(TPattern) == typeof( TableItemPattern ): pattern = TableItemPattern.Pattern; break;
            }

            bool isSuccessful = AutoElement.TryGetCurrentPattern( pattern, out object result );

            return isSuccessful ? (TPattern)result : null;
        }
        
        /// <summary>
        /// This method performs a single left-click on the object.
        /// </summary>
        public void Click()
        {

            System.Windows.Rect rectangle = AutoElement.Current.BoundingRectangle;
            int x = (int)rectangle.X + (int)rectangle.Width / 2;
            int y = (int)rectangle.Y + (int)rectangle.Height / 2;
            Point point = new Point( x, y );
            Mouse.MoveTo( point );
            Mouse.Click( MouseButton.Left );
        }

        public void ClickWithCoordinates(int X, int Y)
        {

            System.Windows.Rect rectangle = AutoElement.Current.BoundingRectangle;
            int x = (int)rectangle.X + X;
            int y = (int)rectangle.Y + Y;
            Point point = new Point( x, y );

            Mouse.MoveTo( point );
            Mouse.Click( MouseButton.Left );
        }

        /// <summary>
        /// This method performs a double left-click on the object.
        /// </summary>
        public void DoubleClick()
        {
            System.Windows.Rect rectangle = AutoElement.Current.BoundingRectangle;
            int x = (int)rectangle.X + (int)rectangle.Width / 2;
            int y = (int)rectangle.Y + (int)rectangle.Height / 2;
            Point point = new Point( x, y );
            // Mouse
            Mouse.MoveTo( point );
            Mouse.DoubleClick( MouseButton.Left );
        }

        /// <summary>
        /// This method performs a single right-click on the object.
        /// </summary>
        public void RightClick()
        {
            System.Windows.Rect rectangle = AutoElement.Current.BoundingRectangle;
            int x = (int)rectangle.X + (int)rectangle.Width / 2;
            int y = (int)rectangle.Y + (int)rectangle.Height / 2;
            Point point = new Point( x, y );
            Mouse.MoveTo( point );
            Mouse.Click( MouseButton.Right );
        }

        /// <summary>
        /// This method highlights the object in blue and brings it to focus.
        /// </summary>
        public void Focus()
        {
            if(AutoElement.Current.IsKeyboardFocusable) AutoElement.SetFocus();

            System.Windows.Rect rectangle = AutoElement.Current.BoundingRectangle;
            Size newSize = new Size( (int)rectangle.Size.Width, (int)rectangle.Size.Height );
            Point newPoint = new Point( (int)rectangle.X, (int)rectangle.Y );

            using(Form form = new Form())
            {

                form.AllowTransparency = true;
                form.ShowInTaskbar = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.BackColor = Color.Magenta;
                form.TransparencyKey = Color.Magenta;
                form.Height = Screen.PrimaryScreen.Bounds.Height;
                form.Width = Screen.PrimaryScreen.Bounds.Width;
                form.DesktopLocation = newPoint;
                form.TopMost = true;
                form.Show();

                Pen greenPen = new Pen( Color.FromArgb( 255, 0, 0, 255 ), 3 );
                Graphics g = form.CreateGraphics();
                Rectangle drawingRectangle = new Rectangle( newPoint, newSize );

                for(int i = 0; i <= 2; i++)
                {
                    g.DrawRectangle( greenPen, drawingRectangle );
                    Thread.Sleep( 100 );
                    g.Clear( Color.Magenta );
                    Thread.Sleep( 100 );
                }

                g.Dispose();

            }
            if(AutoElement.Current.IsKeyboardFocusable) AutoElement.SetFocus();
        }

        /// <summary>
        /// This method moves the cursor on top of the object and hovers for a given time.
        /// </summary>
        /// <param name="waitMiliseconds">Hover time in miliseconds.</param>
        public void Hover( int waitMiliseconds = 1000 )
        {
            System.Windows.Rect rectangle = AutoElement.Current.BoundingRectangle;
            int x = (int)rectangle.X + (int)rectangle.Width / 2;
            int y = (int)rectangle.Y + (int)rectangle.Height / 2;
            Point point = new Point( x, y );
            Cursor.Position = point;
            Thread.Sleep( waitMiliseconds );
        }

        public string TakeScreenshot( string pathToRoot )
        {

            System.Windows.Rect rectangle = AutoElement.Current.BoundingRectangle;
            Size windowSize = new Size( (int)rectangle.Size.Width, (int)rectangle.Size.Height );

            Bitmap printscreen = new Bitmap( Screen.PrimaryScreen.Bounds.Width,
                                            Screen.PrimaryScreen.Bounds.Height );
            Graphics graphics = Graphics.FromImage( printscreen as Image );
            graphics.CopyFromScreen( (int)rectangle.TopLeft.X, (int)rectangle.TopLeft.Y, 0, 0, windowSize );
            string nme = DateTime.Now.ToFileTime().ToString();
            printscreen.Save( Path.Combine( pathToRoot, $"{nme}.jpg" ), ImageFormat.Jpeg );
            return Path.Combine( pathToRoot, $"{nme}.jpg" );
        }
    }


}
