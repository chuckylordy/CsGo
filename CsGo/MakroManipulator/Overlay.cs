using Manipulator.CsGo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakroManipulator
{
    public partial class Overlay
    {
        public Overlay()
        {
          
        }

        [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr SetParent(IntPtr HWNDChild, IntPtr HWNDNewParent);

        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        private const int WM_SYSCOMMAND = 274;
        private const int SC_MAXIMIZE = 61488;

        private static Control panel;

        public static void DrawCrossOverlay(string aiProcess, Color aiColor, Control aiCtrl)
        {
            panel = aiCtrl;
            panel.Location = Crosshair.StartPosition;
            panel.Size = Crosshair.Size;
            panel.BackColor = aiColor;

            var processname = aiProcess;

            try
            {
                Process proc = Process.GetProcesses().FirstOrDefault(process => process.ProcessName == processname);
                //proc.WaitForInputIdle();
                SetParent(panel.Handle, proc.MainWindowHandle);
                SendMessage(proc.MainWindowHandle, WM_SYSCOMMAND, SC_MAXIMIZE, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
 
    }
}

