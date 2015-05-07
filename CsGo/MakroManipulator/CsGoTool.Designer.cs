namespace MakroManipulator
{
    partial class FormCsGoTool
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCsGoTool));
            this.checkBoxActivateCrosshair = new System.Windows.Forms.CheckBox();
            this.checkBoxActivateCrosshairMouse = new System.Windows.Forms.CheckBox();
            this.checkBoxTrogger = new System.Windows.Forms.CheckBox();
            this.checkBoxCrosshair_WinApi = new System.Windows.Forms.CheckBox();
            this.textBoxTolerance = new System.Windows.Forms.TextBox();
            this.labelTolerance = new System.Windows.Forms.Label();
            this.dropDownTriggerMode = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // checkBoxActivateCrosshair
            // 
            this.checkBoxActivateCrosshair.AutoSize = true;
            this.checkBoxActivateCrosshair.Location = new System.Drawing.Point(3, 12);
            this.checkBoxActivateCrosshair.Name = "checkBoxActivateCrosshair";
            this.checkBoxActivateCrosshair.Size = new System.Drawing.Size(111, 17);
            this.checkBoxActivateCrosshair.TabIndex = 0;
            this.checkBoxActivateCrosshair.Text = "Activate Crosshair";
            this.checkBoxActivateCrosshair.UseVisualStyleBackColor = true;
            this.checkBoxActivateCrosshair.CheckedChanged += new System.EventHandler(this.checkBoxActivateCrosshair_CheckedChanged);
            // 
            // checkBoxActivateCrosshairMouse
            // 
            this.checkBoxActivateCrosshairMouse.AutoSize = true;
            this.checkBoxActivateCrosshairMouse.Location = new System.Drawing.Point(3, 35);
            this.checkBoxActivateCrosshairMouse.Name = "checkBoxActivateCrosshairMouse";
            this.checkBoxActivateCrosshairMouse.Size = new System.Drawing.Size(143, 17);
            this.checkBoxActivateCrosshairMouse.TabIndex = 1;
            this.checkBoxActivateCrosshairMouse.Text = "Activate CrosshairMouse";
            this.checkBoxActivateCrosshairMouse.UseVisualStyleBackColor = true;
            this.checkBoxActivateCrosshairMouse.CheckedChanged += new System.EventHandler(this.checkBoxActivateCrosshairMouse_CheckedChanged);
            // 
            // checkBoxTrogger
            // 
            this.checkBoxTrogger.AutoSize = true;
            this.checkBoxTrogger.Location = new System.Drawing.Point(3, 233);
            this.checkBoxTrogger.Name = "checkBoxTrogger";
            this.checkBoxTrogger.Size = new System.Drawing.Size(101, 17);
            this.checkBoxTrogger.TabIndex = 2;
            this.checkBoxTrogger.Text = "Activate Trigger";
            this.checkBoxTrogger.UseVisualStyleBackColor = true;
            this.checkBoxTrogger.CheckedChanged += new System.EventHandler(this.checkBoxTrogger_CheckedChanged);
            // 
            // checkBoxCrosshair_WinApi
            // 
            this.checkBoxCrosshair_WinApi.AutoSize = true;
            this.checkBoxCrosshair_WinApi.Location = new System.Drawing.Point(3, 210);
            this.checkBoxCrosshair_WinApi.Name = "checkBoxCrosshair_WinApi";
            this.checkBoxCrosshair_WinApi.Size = new System.Drawing.Size(150, 17);
            this.checkBoxCrosshair_WinApi.TabIndex = 4;
            this.checkBoxCrosshair_WinApi.Text = "Activate Crosshair WinAPI";
            this.checkBoxCrosshair_WinApi.UseVisualStyleBackColor = true;
            this.checkBoxCrosshair_WinApi.CheckedChanged += new System.EventHandler(this.checkBoxCrosshair_WinApi_CheckedChanged);
            // 
            // textBoxTolerance
            // 
            this.textBoxTolerance.Location = new System.Drawing.Point(110, 230);
            this.textBoxTolerance.Name = "textBoxTolerance";
            this.textBoxTolerance.Size = new System.Drawing.Size(36, 20);
            this.textBoxTolerance.TabIndex = 5;
            this.textBoxTolerance.Text = "30";
            // 
            // labelTolerance
            // 
            this.labelTolerance.AutoSize = true;
            this.labelTolerance.Location = new System.Drawing.Point(152, 233);
            this.labelTolerance.Name = "labelTolerance";
            this.labelTolerance.Size = new System.Drawing.Size(55, 13);
            this.labelTolerance.TabIndex = 6;
            this.labelTolerance.Text = "Tolerance";
            // 
            // dropDownTriggerMode
            // 
            this.dropDownTriggerMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropDownTriggerMode.FormattingEnabled = true;
            this.dropDownTriggerMode.Location = new System.Drawing.Point(213, 229);
            this.dropDownTriggerMode.Name = "dropDownTriggerMode";
            this.dropDownTriggerMode.Size = new System.Drawing.Size(59, 21);
            this.dropDownTriggerMode.TabIndex = 7;
            // 
            // FormCsGoTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.dropDownTriggerMode);
            this.Controls.Add(this.labelTolerance);
            this.Controls.Add(this.textBoxTolerance);
            this.Controls.Add(this.checkBoxCrosshair_WinApi);
            this.Controls.Add(this.checkBoxTrogger);
            this.Controls.Add(this.checkBoxActivateCrosshairMouse);
            this.Controls.Add(this.checkBoxActivateCrosshair);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCsGoTool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CsGoTool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxActivateCrosshair;
        private System.Windows.Forms.CheckBox checkBoxActivateCrosshairMouse;
        private System.Windows.Forms.CheckBox checkBoxTrogger;
        private System.Windows.Forms.CheckBox checkBoxCrosshair_WinApi;
        private System.Windows.Forms.TextBox textBoxTolerance;
        private System.Windows.Forms.Label labelTolerance;
        private System.Windows.Forms.ComboBox dropDownTriggerMode;
    }
}

