namespace Vehicle.FormUI.Forms
{
    partial class frmEngineAdd
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
            tbCubage = new TextBox();
            label2 = new Label();
            cbFuelType = new ComboBox();
            label3 = new Label();
            tbHp = new TextBox();
            btnAdd = new Button();
            err = new ErrorProvider(components);
            cbIsHybrid = new CheckBox();
            tbEmission = new TextBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)err).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 29);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Cubage:";
            // 
            // tbCubage
            // 
            tbCubage.Location = new Point(135, 26);
            tbCubage.Name = "tbCubage";
            tbCubage.Size = new Size(237, 23);
            tbCubage.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 98);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 2;
            label2.Text = "Fuel type:";
            // 
            // cbFuelType
            // 
            cbFuelType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFuelType.FormattingEnabled = true;
            cbFuelType.Location = new Point(135, 95);
            cbFuelType.Name = "cbFuelType";
            cbFuelType.Size = new Size(237, 23);
            cbFuelType.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 63);
            label3.Name = "label3";
            label3.Size = new Size(74, 15);
            label3.TabIndex = 4;
            label3.Text = "Horsepower:";
            // 
            // tbHp
            // 
            tbHp.Location = new Point(135, 60);
            tbHp.Name = "tbHp";
            tbHp.Size = new Size(237, 23);
            tbHp.TabIndex = 5;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(254, 196);
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
            // cbIsHybrid
            // 
            cbIsHybrid.AutoSize = true;
            cbIsHybrid.Location = new Point(135, 196);
            cbIsHybrid.Name = "cbIsHybrid";
            cbIsHybrid.Size = new Size(75, 19);
            cbIsHybrid.TabIndex = 8;
            cbIsHybrid.Text = "IsHybrid?";
            cbIsHybrid.UseVisualStyleBackColor = true;
            // 
            // tbEmission
            // 
            tbEmission.Location = new Point(135, 133);
            tbEmission.Name = "tbEmission";
            tbEmission.Size = new Size(237, 23);
            tbEmission.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 136);
            label4.Name = "label4";
            label4.Size = new Size(106, 15);
            label4.TabIndex = 9;
            label4.Text = "Emission standard:";
            // 
            // frmEngineAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(416, 268);
            Controls.Add(tbEmission);
            Controls.Add(label4);
            Controls.Add(cbIsHybrid);
            Controls.Add(btnAdd);
            Controls.Add(tbHp);
            Controls.Add(label3);
            Controls.Add(cbFuelType);
            Controls.Add(label2);
            Controls.Add(tbCubage);
            Controls.Add(label1);
            KeyPreview = true;
            Name = "frmEngineAdd";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmVehicleModelAdd";
            Load += frmEngineAdd_Load;
            ((System.ComponentModel.ISupportInitialize)err).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbCubage;
        private Label label2;
        private ComboBox cbFuelType;
        private Label label3;
        private TextBox tbHp;
        private Button btnAdd;
        private ErrorProvider err;
        private CheckBox cbIsHybrid;
        private TextBox tbEmission;
        private Label label4;
    }
}