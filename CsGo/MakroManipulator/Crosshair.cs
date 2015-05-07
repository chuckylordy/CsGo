using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manipulator.CsGo
{
    public class Crosshair
    {
        [DllImport("User32.dll")]
        static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("User32.dll")]
        static extern void ReleaseDC(IntPtr dc);


        // <summary>
        /// Retrieves the cursor's position, in screen coordinates.
        /// </summary>
        /// <see>See MSDN documentation for further information.</see>
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out Point lpPoint);

        public static Point GetCursorPosition()
        {
            Point lpPoint;
            GetCursorPos(out lpPoint);
            //bool success = User32.GetCursorPos(out lpPoint);
            // if (!success)

            return lpPoint;
        }

        private static Control Ctrl { get; set; }

        public static Timer Timer { get; set; }
        
        public static Timer MouseTimer { get; set; }

        public Crosshair(Control aiControl)
        {
            Ctrl = aiControl;
        }

        public static void Draw()
        {
            Point pt = Cursor.Position; // Get the mouse cursor in screen coordinates 

            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
            {
                Rectangle tst = GetScreen();

                g.DrawRectangle(Pens.Black, tst.Width/ 2, tst.Height/2, 20,20);
            }
        }

        public static void TestDraw()
        {
            Timer = new Timer();
            Timer.Interval = 1;
            Timer.Tick += myTimer_Tick;
            Timer.Start();
        }

        static void myTimer_Tick(object sender, EventArgs e)
        {
            Rectangle tst = GetScreen();
            
            FillPoint(Brushes.Black,new Size(4,4),new Point (tst.Width/2,tst.Height/2));
        }

    
        private static void FillPoint(Brush aiBrush, Size aiSize, Point aiLocation)
        {
            IntPtr desktop = GetDC(IntPtr.Zero);
            using (Graphics g = Graphics.FromHdc(desktop))
            {
                g.FillRectangle(aiBrush, aiLocation.X, aiLocation.Y, aiSize.Width, aiSize.Height);
            }
        }

        public static Rectangle GetScreen()
        {
            return Screen.FromControl(Ctrl).Bounds;
        }

        internal static void StopDrawing()
        {
            Timer.Stop();
        }


        internal static void StopDrawingMouse()
        {
            MouseTimer.Stop();
        }

        internal static void TestDrawMouse(Control aiCtrl)
        {
            Ctrl = aiCtrl;

            MouseTimer = new Timer();
            MouseTimer.Interval = 1;
            MouseTimer.Tick += myTimerMouse_Tick;
            MouseTimer.Start();
        }

        private static void myTimerMouse_Tick(object sender, EventArgs e)
        {
            FillPoint(Brushes.Black, new Size(4, 4), GetCursorPosition());
        }

        public static Point StartPosition 
        { 
            get 
            {
                return new Point((GetScreen().Width / 2) - (Size.Width / 2), (GetScreen().Height / 2) - (Size.Height / 2)); 
            }
            set 
            { 
                StartPosition = value;
            }
        }
        public static Size Size { get { return new Size(4, 4); } set { Size = value; } }
    }
}
