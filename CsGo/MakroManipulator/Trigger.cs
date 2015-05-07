using Manipulator.CsGo;
using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakroManipulator
{
    public class Trigger
    {


    
        private readonly KeyboardHookListener m_KeyboardHookManager;
       // private readonly MouseHookListener m_MouseHookManager;
        private System.Windows.Forms.Timer _timer;
        private bool Moving;
        private bool Started;
        private System.Drawing.Point gvLocation;
        private System.Drawing.Size gvSize;
        private const string Path = "tmp.png";
        private int gvTolerance;
        private ScreenPicture actualPic;
        private ScreenPicture oldPic;
        private Enums.Modes mode;
        private bool Shooting;

       public Trigger(int aiTolerance, Enums.Modes aiMode)
        {
            m_KeyboardHookManager = new KeyboardHookListener(new GlobalHooker());
            m_KeyboardHookManager.Enabled = true;
            m_KeyboardHookManager.KeyDown += HookManager_KeyDown;
            m_KeyboardHookManager.KeyUp += HookManager_KeyUp;

            //m_MouseHookManager = new MouseHookListener(new GlobalHooker());
            //m_MouseHookManager.Enabled = true;
            //m_MouseHookManager.MouseDown += HookManager_MouseDown;
            //m_MouseHookManager.MouseUp += HookManager_MouseUp;

            Started = false;
            mode = aiMode;
            //Moving = true;

            gvTolerance = aiTolerance;
            gvLocation = StartPosition;
            gvSize = Size;
        }

       private void HookManager_KeyUp(object sender, KeyEventArgs e)
       {
           Moving = false;

           if(mode == Enums.Modes.TriggerC && e.KeyCode == Keys.C)
           {
               Started = false;
               Stop();
           }
       }

       private void _timer_Tick(object sender, EventArgs e)
       {
           if (!IsPlayerMoving())
           {
               if (!IsPictureNotChanged())
               {
                  // Mouse.ClickLeftMouseButton();
                   Trace.WriteLine("Shot");
               }
               Trace.Write("Not Moving");
           }
           else { Trace.WriteLine("Moving"); }
       }

       private bool IsPictureNotChanged()
       {
           if (File.Exists(Path))
           {
               oldPic = actualPic;
               actualPic = ScreenPicture.Take(gvLocation, gvSize);
               //Thread.Sleep(1000);
               //actualPic.Save(Path);
               return ScreenPicture.CompareScreenPictures(actualPic, oldPic, gvTolerance);
           }
           else
           {
               actualPic = ScreenPicture.Take(gvLocation, gvSize);
               oldPic = actualPic;
               File.WriteAllText(Path, "test");
               return false;
           }
       }

       private bool IsPlayerMoving()
       {
           return Moving;//!Mouse.AnyKeyPressed();
       }


        private void HookManager_KeyDown(object sender, KeyEventArgs e)
        {
            if (mode == Enums.Modes.Continuous)
            {
                if (e.KeyCode == Keys.Pause)
                {
                    if (!Started)
                    {
                        Start();
                    }
                    else
                    {
                        Stop();
                    }
                }
                else
                {
                    //Wenn er sich wirklich gerade nur bewegt
                    if (e.KeyCode == Keys.W || e.KeyCode == Keys.A || e.KeyCode == Keys.S || e.KeyCode == Keys.D || e.KeyCode == Keys.Space || e.KeyCode == Keys.C)
                        Moving = true;
                }
            }
            else if(mode == Enums.Modes.TriggerC)
            {
                //Wenn C gedrückt wird
                if (e.KeyCode == Keys.C)
                {
                    if (!Started)
                    {
                        Start();
                    }
                }
            }
        }

        internal void Start()
        {
            if (mode == Enums.Modes.Continuous || mode == Enums.Modes.TriggerC)
            {
                Started = true;

                if (File.Exists(Path))
                    File.Delete(Path);

                _timer = new System.Windows.Forms.Timer();
                _timer.Interval = 100;
                _timer.Tick += _timer_Tick;
                _timer.Start();
            }
        }

        internal void Stop()
        {
            if (_timer != null)
            {
                Started = false;
                if(File.Exists(Path))
                    File.Delete(Path);
                _timer.Stop();
            }
        }

        public static Point StartPosition
        {
            get
            {
                return new Point((Crosshair.GetScreen().Width / 2) - (Size.Width / 2), (Crosshair.GetScreen().Height / 2) - (Size.Height / 2));
            }
            set
            {
                StartPosition = value;
            }
        }
        public static Size Size { get { return new Size(20, 20); } set { Size = value; } }
    }
}
