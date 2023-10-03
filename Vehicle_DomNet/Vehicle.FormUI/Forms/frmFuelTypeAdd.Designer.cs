namespace Vehicle.FormUI.Forms
{
    partial class frmFuelTypeAdd
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
            tbFuel = new TextBox();
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
            label1.Size = new Size(58, 15);
            label1.TabIndex = 0;
            label1.Text = "Fuel type:";
            // 
            // tbFuel
            // 
            tbFuel.Location = new Point(135, 26);
            tbFuel.Name = "tbFuel";
            tbFuel.Size = new Size(237, 23);
            tbFuel.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(254, 76);
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
            // frmFuelTypeAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(416, 150);
            Controls.Add(btnAdd);
            Controls.Add(tbFuel);
            Controls.Add(label1);
            Name = "frmFuelTypeAdd";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmVehicleModelAdd";
            Load += frmFuelTypeAdd_Load;
            ((System.ComponentModel.ISupportInitialize)err).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbFuel;
        private Button btnAdd;
        private ErrorProvider err;
    }
}