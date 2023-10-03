namespace Vehicle.FormUI.Forms
{
    partial class frmSeatTypeAdd
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
            tbSeatType = new TextBox();
            ((System.ComponentModel.ISupportInitialize)err).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(47, 60);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 4;
            label3.Text = "Seat type:";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(254, 119);
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
            // tbSeatType
            // 
            tbSeatType.Location = new Point(135, 57);
            tbSeatType.Name = "tbSeatType";
            tbSeatType.Size = new Size(237, 23);
            tbSeatType.TabIndex = 5;
            // 
            // frmSeatTypeAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(431, 200);
            Controls.Add(btnAdd);
            Controls.Add(tbSeatType);
            Controls.Add(label3);
            Name = "frmSeatTypeAdd";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmVehicleModelAdd";
            Load += frmSeatTypeAdd_Load;
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
        private TextBox tbSeatType;
    }
}