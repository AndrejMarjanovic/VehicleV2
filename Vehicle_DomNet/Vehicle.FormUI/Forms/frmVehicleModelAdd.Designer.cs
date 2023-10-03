namespace Vehicle.FormUI.Forms
{
    partial class frmVehicleModelAdd
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
            label1 = new Label();
            tbName = new TextBox();
            label2 = new Label();
            cbMakes = new ComboBox();
            label3 = new Label();
            tbAbrv = new TextBox();
            btnAdd = new Button();
            err = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)err).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 29);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 0;
            label1.Text = "Name:";
            // 
            // tbName
            // 
            tbName.Location = new Point(135, 26);
            tbName.Name = "tbName";
            tbName.Size = new Size(237, 23);
            tbName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 95);
            label2.Name = "label2";
            label2.Size = new Size(79, 15);
            label2.TabIndex = 2;
            label2.Text = "Vehicle make:";
            // 
            // cbMakes
            // 
            cbMakes.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMakes.FormattingEnabled = true;
            cbMakes.Location = new Point(135, 95);
            cbMakes.Name = "cbMakes";
            cbMakes.Size = new Size(237, 23);
            cbMakes.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 60);
            label3.Name = "label3";
            label3.Size = new Size(78, 15);
            label3.TabIndex = 4;
            label3.Text = "Abbreviation:";
            // 
            // tbAbrv
            // 
            tbAbrv.Location = new Point(135, 60);
            tbAbrv.Name = "tbAbrv";
            tbAbrv.Size = new Size(237, 23);
            tbAbrv.TabIndex = 5;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(254, 150);
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
            // frmVehicleModelAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(431, 200);
            Controls.Add(btnAdd);
            Controls.Add(tbAbrv);
            Controls.Add(label3);
            Controls.Add(cbMakes);
            Controls.Add(label2);
            Controls.Add(tbName);
            Controls.Add(label1);
            Name = "frmVehicleModelAdd";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmVehicleModelAdd";
            Load += frmVehicleModelAdd_Load;
            ((System.ComponentModel.ISupportInitialize)err).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbName;
        private Label label2;
        private ComboBox cbMakes;
        private Label label3;
        private TextBox tbAbrv;
        private Button btnAdd;
        private ErrorProvider err;
    }
}