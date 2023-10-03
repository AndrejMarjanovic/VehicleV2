namespace Vehicle.FormUI.Forms
{
    partial class mdiMain
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
            components = new System.ComponentModel.Container();
            menuStrip = new MenuStrip();
            vehicleModelsToolStripMenuItem = new ToolStripMenuItem();
            enginesToolStripMenuItem = new ToolStripMenuItem();
            fuelTypeToolStripMenuItem = new ToolStripMenuItem();
            usersToolStripMenuItem = new ToolStripMenuItem();
            seatsToolStripMenuItem = new ToolStripMenuItem();
            seatsToolStripMenuItem1 = new ToolStripMenuItem();
            seatTypeColoursToolStripMenuItem = new ToolStripMenuItem();
            seatTypesToolStripMenuItem = new ToolStripMenuItem();
            colourToolStripMenuItem = new ToolStripMenuItem();
            chatToolStripMenuItem = new ToolStripMenuItem();
            logOutToolStripMenuItem = new ToolStripMenuItem();
            toolTip = new ToolTip(components);
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.BackColor = Color.FromArgb(35, 47, 65);
            menuStrip.Dock = DockStyle.Left;
            menuStrip.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            menuStrip.Items.AddRange(new ToolStripItem[] { vehicleModelsToolStripMenuItem, enginesToolStripMenuItem, fuelTypeToolStripMenuItem, usersToolStripMenuItem, seatsToolStripMenuItem, colourToolStripMenuItem, chatToolStripMenuItem, logOutToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(7, 2, 0, 2);
            menuStrip.RightToLeft = RightToLeft.No;
            menuStrip.Size = new Size(133, 584);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "MenuStrip";
            // 
            // vehicleModelsToolStripMenuItem
            // 
            vehicleModelsToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            vehicleModelsToolStripMenuItem.ForeColor = SystemColors.ButtonFace;
            vehicleModelsToolStripMenuItem.Name = "vehicleModelsToolStripMenuItem";
            vehicleModelsToolStripMenuItem.Size = new Size(118, 25);
            vehicleModelsToolStripMenuItem.Text = "Vehicle models";
            vehicleModelsToolStripMenuItem.Click += vehicleModelsToolStripMenuItem_Click;
            // 
            // enginesToolStripMenuItem
            // 
            enginesToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            enginesToolStripMenuItem.ForeColor = SystemColors.ButtonFace;
            enginesToolStripMenuItem.Name = "enginesToolStripMenuItem";
            enginesToolStripMenuItem.Size = new Size(118, 25);
            enginesToolStripMenuItem.Text = "Engines";
            enginesToolStripMenuItem.Click += enginesToolStripMenuItem_Click;
            // 
            // fuelTypeToolStripMenuItem
            // 
            fuelTypeToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            fuelTypeToolStripMenuItem.ForeColor = SystemColors.ButtonFace;
            fuelTypeToolStripMenuItem.Name = "fuelTypeToolStripMenuItem";
            fuelTypeToolStripMenuItem.Size = new Size(118, 25);
            fuelTypeToolStripMenuItem.Text = "Fuel type";
            fuelTypeToolStripMenuItem.Click += fuelTypeToolStripMenuItem_Click;
            // 
            // usersToolStripMenuItem
            // 
            usersToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            usersToolStripMenuItem.ForeColor = SystemColors.ButtonFace;
            usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            usersToolStripMenuItem.Size = new Size(118, 25);
            usersToolStripMenuItem.Text = "Users";
            usersToolStripMenuItem.Click += usersToolStripMenuItem_Click;
            // 
            // seatsToolStripMenuItem
            // 
            seatsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { seatsToolStripMenuItem1, seatTypeColoursToolStripMenuItem, seatTypesToolStripMenuItem });
            seatsToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            seatsToolStripMenuItem.ForeColor = SystemColors.ButtonFace;
            seatsToolStripMenuItem.Name = "seatsToolStripMenuItem";
            seatsToolStripMenuItem.Size = new Size(118, 25);
            seatsToolStripMenuItem.Text = "Seats";
            // 
            // seatsToolStripMenuItem1
            // 
            seatsToolStripMenuItem1.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            seatsToolStripMenuItem1.Name = "seatsToolStripMenuItem1";
            seatsToolStripMenuItem1.Size = new Size(165, 22);
            seatsToolStripMenuItem1.Text = "Seats";
            seatsToolStripMenuItem1.Click += seatsToolStripMenuItem1_Click;
            // 
            // seatTypeColoursToolStripMenuItem
            // 
            seatTypeColoursToolStripMenuItem.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            seatTypeColoursToolStripMenuItem.Name = "seatTypeColoursToolStripMenuItem";
            seatTypeColoursToolStripMenuItem.Size = new Size(165, 22);
            seatTypeColoursToolStripMenuItem.Text = "Seat type colours";
            seatTypeColoursToolStripMenuItem.Click += seatTypeColoursToolStripMenuItem_Click;
            // 
            // seatTypesToolStripMenuItem
            // 
            seatTypesToolStripMenuItem.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            seatTypesToolStripMenuItem.Name = "seatTypesToolStripMenuItem";
            seatTypesToolStripMenuItem.Size = new Size(165, 22);
            seatTypesToolStripMenuItem.Text = "Seat types";
            seatTypesToolStripMenuItem.Click += seatTypesToolStripMenuItem_Click;
            // 
            // colourToolStripMenuItem
            // 
            colourToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            colourToolStripMenuItem.ForeColor = SystemColors.ButtonFace;
            colourToolStripMenuItem.Name = "colourToolStripMenuItem";
            colourToolStripMenuItem.Size = new Size(118, 25);
            colourToolStripMenuItem.Text = "Colour";
            colourToolStripMenuItem.Click += colourToolStripMenuItem_Click;
            // 
            // chatToolStripMenuItem
            // 
            chatToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            chatToolStripMenuItem.ForeColor = Color.FromArgb(70, 140, 225);
            chatToolStripMenuItem.Name = "chatToolStripMenuItem";
            chatToolStripMenuItem.Size = new Size(118, 25);
            chatToolStripMenuItem.Text = "Chat";
            chatToolStripMenuItem.Click += chatToolStripMenuItem_Click;
            // 
            // logOutToolStripMenuItem
            // 
            logOutToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            logOutToolStripMenuItem.ForeColor = Color.Red;
            logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            logOutToolStripMenuItem.Size = new Size(118, 25);
            logOutToolStripMenuItem.Text = "Log out";
            logOutToolStripMenuItem.Click += logOutToolStripMenuItem_Click;
            // 
            // mdiMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(35, 45, 67);
            ClientSize = new Size(1198, 584);
            Controls.Add(menuStrip);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            Margin = new Padding(4, 3, 4, 3);
            Name = "mdiMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "mdiMain";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion


        private MenuStrip menuStrip;
        private ToolTip toolTip;
        private ToolStripMenuItem vehicleModelsToolStripMenuItem;
        private ToolStripMenuItem enginesToolStripMenuItem;
        private ToolStripMenuItem fuelTypeToolStripMenuItem;
        private ToolStripMenuItem logOutToolStripMenuItem;
        private ToolStripMenuItem usersToolStripMenuItem;
        private ToolStripMenuItem seatsToolStripMenuItem;
        private ToolStripMenuItem seatTypeColoursToolStripMenuItem;
        private ToolStripMenuItem seatsToolStripMenuItem1;
        private ToolStripMenuItem seatTypesToolStripMenuItem;
        private ToolStripMenuItem colourToolStripMenuItem;
        private ToolStripMenuItem chatToolStripMenuItem;
    }
}



