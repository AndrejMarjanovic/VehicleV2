namespace Vehicle.FormUI.Forms
{
    partial class frmSeatsAdd
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
            cbSeats = new ComboBox();
            label3 = new Label();
            btnAdd = new Button();
            err = new ErrorProvider(components);
            tbNoOfSeats = new TextBox();
            ((System.ComponentModel.ISupportInitialize)err).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 76);
            label2.Name = "label2";
            label2.Size = new Size(113, 15);
            label2.TabIndex = 2;
            label2.Text = "Material and colour:";
            // 
            // cbSeats
            // 
            cbSeats.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSeats.FormattingEnabled = true;
            cbSeats.Location = new Point(135, 73);
            cbSeats.Name = "cbSeats";
            cbSeats.Size = new Size(237, 23);
            cbSeats.TabIndex = 3;
            cbSeats.Format += cbSeats_Format;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 41);
            label3.Name = "label3";
            label3.Size = new Size(97, 15);
            label3.TabIndex = 4;
            label3.Text = "Number of seats:";
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
            // tbNoOfSeats
            // 
            tbNoOfSeats.Location = new Point(135, 38);
            tbNoOfSeats.Name = "tbNoOfSeats";
            tbNoOfSeats.Size = new Size(237, 23);
            tbNoOfSeats.TabIndex = 5;
            // 
            // frmSeatsAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(431, 200);
            Controls.Add(btnAdd);
            Controls.Add(tbNoOfSeats);
            Controls.Add(label3);
            Controls.Add(cbSeats);
            Controls.Add(label2);
            Name = "frmSeatsAdd";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmVehicleModelAdd";
            Load += frmSeatsAdd_Load;
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
        private TextBox tbNoOfSeats;
    }
}