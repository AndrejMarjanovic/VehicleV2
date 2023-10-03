namespace Vehicle.FormUI.Forms
{
    partial class frmSeatTypeColourAdd
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
            label2 = new Label();
            cbColours = new ComboBox();
            btnAdd = new Button();
            err = new ErrorProvider(components);
            cbSeatTypes = new ComboBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)err).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 76);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 2;
            label2.Text = "Colour:";
            // 
            // cbColours
            // 
            cbColours.DropDownStyle = ComboBoxStyle.DropDownList;
            cbColours.FormattingEnabled = true;
            cbColours.Location = new Point(135, 73);
            cbColours.Name = "cbColours";
            cbColours.Size = new Size(237, 23);
            cbColours.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(254, 128);
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
            // cbSeatTypes
            // 
            cbSeatTypes.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSeatTypes.FormattingEnabled = true;
            cbSeatTypes.Location = new Point(135, 33);
            cbSeatTypes.Name = "cbSeatTypes";
            cbSeatTypes.Size = new Size(237, 23);
            cbSeatTypes.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(57, 36);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 7;
            label3.Text = "Seat type:";
            // 
            // frmSeatTypeColourAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(431, 200);
            Controls.Add(cbSeatTypes);
            Controls.Add(label3);
            Controls.Add(btnAdd);
            Controls.Add(cbColours);
            Controls.Add(label2);
            Name = "frmSeatTypeColourAdd";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmVehicleModelAdd";
            Load += frmSeatTypeColourAdd_Load;
            ((System.ComponentModel.ISupportInitialize)err).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbName;
        private Label label2;
        private ComboBox cbColours;
        private Button btnAdd;
        private ErrorProvider err;
        private ComboBox cbSeatTypes;
        private Label label3;
    }
}