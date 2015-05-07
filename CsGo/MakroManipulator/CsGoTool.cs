using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manipulator.CsGo;
using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;

namespace MakroManipulator
{
    public partial class FormCsGoTool : Form
    {
        private Trigger myTrigger;

        public FormCsGoTool()
        {
            InitializeComponent();

            Crosshair cross = new Crosshair(this);

            this.dropDownTriggerMode = LoadItems(dropDownTriggerMode);
        }

        private ComboBox LoadItems(ComboBox aiComboBox)
        {
            aiComboBox.DataSource = Enum.GetNames(typeof(Enums.Modes)).ToList();
            return aiComboBox;
        }

        private void checkBoxActivateCrosshair_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox sendCheck = sender as CheckBox;

            if(sendCheck.Checked)
            {
                Crosshair.TestDraw();
            }
            else if(Crosshair.Timer != null)
            {
                Crosshair.StopDrawing();
            }
        }

        private void checkBoxActivateCrosshairMouse_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox sendCheck = sender as CheckBox;

            if (sendCheck.Checked)
            {
                Crosshair.TestDrawMouse(this);
            }
            else if (Crosshair.MouseTimer != null)
            {
                Crosshair.StopDrawingMouse();
            }
        }

        private void checkBoxTrogger_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox sendCheck = sender as CheckBox;

            if (sendCheck.Checked)
            {
                myTrigger = new Trigger(Convert.ToInt32(textBoxTolerance.Text), Enums.GetMode(dropDownTriggerMode.Text));
            }
            else
            {
                if (myTrigger != null)
                {
                    myTrigger.Stop();
                }
            }
        }


        private void checkBoxCrosshair_WinApi_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox sendCheck = sender as CheckBox;

            if (sendCheck.Checked)
            {
                Overlay.DrawCrossOverlay("firefox", Color.Black,new Panel());
            }
        }

     
    }
}
