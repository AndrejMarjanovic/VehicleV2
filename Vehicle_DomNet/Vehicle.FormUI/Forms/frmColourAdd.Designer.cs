namespace Vehicle.FormUI.Forms
{
    partial class frmColourAdd
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
            label3 = new Label();
            btnAdd = new Button();
            err = new ErrorProvider(components);
            tbColour = new TextBox();
            tbColourCode = new TextBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)err).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(47, 41);
            label3.Name = "label3";
            label3.Size = new Size(46, 15);
            label3.TabIndex = 4;
            label3.Text = "Colour:";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(254, 130);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(118, 23);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // err
            // 
            err.ContainerControl = this;
            // 
            // tbColour
            // 
            tbColour.Location = new Point(135, 38);
            tbColour.Name = "tbColour";
            tbColour.Size = new Size(237, 23);
            tbColour.TabIndex = 5;
            // 
            // tbColourCode
            // 
            tbColourCode.Location = new Point(135, 77);
            tbColourCode.Name = "tbColourCode";
            tbColourCode.Size = new Size(237, 23);
            tbColourCode.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(47, 80);
            label4.Name = "label4";
            label4.Size = new Size(75, 15);
            label4.TabIndex = 7;
            label4.Text = "Colour code:";
            // 
            // frmColourAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(431, 200);
            Controls.Add(tbColourCode);
            Controls.Add(label4);
            Controls.Add(btnAdd);
            Controls.Add(tbColour);
            Controls.Add(label3);
            Name = "frmColourAdd";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmVehicleModelAdd";
            Load += frmColourAdd_Load;
            ((System.ComponentModel.ISupportInitialize)err).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbName;
        private Label label2;
        private ComboBox cbSeats;
        private Label label3;
        private Button btnAdd;
        private ErrorProvider err;
        private TextBox tbColour;
        private TextBox tbColourCode;
        private Label label4;
    }
}