namespace Vehicle.FormUI.Forms
{
    partial class frmUserAdd
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
            cbRole = new ComboBox();
            label3 = new Label();
            tbLastname = new TextBox();
            btnAdd = new Button();
            err = new ErrorProvider(components);
            tbPassword = new TextBox();
            lblPass = new Label();
            tbPhone = new TextBox();
            label6 = new Label();
            tbEmail = new TextBox();
            label4 = new Label();
            tbUsername = new TextBox();
            label7 = new Label();
            tbConfirm = new TextBox();
            lblConfirm = new Label();
            cbPassChange = new CheckBox();
            cbPassShow = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)err).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 26);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 0;
            label1.Text = "Name:";
            // 
            // tbName
            // 
            tbName.Location = new Point(106, 21);
            tbName.Name = "tbName";
            tbName.Size = new Size(237, 23);
            tbName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(360, 65);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 2;
            label2.Text = "Role:";
            // 
            // cbRole
            // 
            cbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRole.FormattingEnabled = true;
            cbRole.Location = new Point(470, 55);
            cbRole.Name = "cbRole";
            cbRole.Size = new Size(237, 23);
            cbRole.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 60);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 4;
            label3.Text = "Lastname:";
            // 
            // tbLastname
            // 
            tbLastname.Location = new Point(106, 55);
            tbLastname.Name = "tbLastname";
            tbLastname.Size = new Size(237, 23);
            tbLastname.TabIndex = 5;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(589, 211);
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
            // tbPassword
            // 
            tbPassword.Location = new Point(470, 89);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '*';
            tbPassword.Size = new Size(237, 23);
            tbPassword.TabIndex = 14;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Location = new Point(360, 99);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(60, 15);
            lblPass.TabIndex = 13;
            lblPass.Text = "Password:";
            // 
            // tbPhone
            // 
            tbPhone.Location = new Point(470, 21);
            tbPhone.Name = "tbPhone";
            tbPhone.Size = new Size(237, 23);
            tbPhone.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(360, 31);
            label6.Name = "label6";
            label6.Size = new Size(44, 15);
            label6.TabIndex = 11;
            label6.Text = "Phone:";
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(106, 128);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(237, 23);
            tbEmail.TabIndex = 18;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 133);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 17;
            label4.Text = "Email:";
            // 
            // tbUsername
            // 
            tbUsername.Location = new Point(106, 91);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(237, 23);
            tbUsername.TabIndex = 16;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 96);
            label7.Name = "label7";
            label7.Size = new Size(63, 15);
            label7.TabIndex = 15;
            label7.Text = "Username:";
            // 
            // tbConfirm
            // 
            tbConfirm.Location = new Point(470, 125);
            tbConfirm.Name = "tbConfirm";
            tbConfirm.PasswordChar = '*';
            tbConfirm.Size = new Size(237, 23);
            tbConfirm.TabIndex = 20;
            // 
            // lblConfirm
            // 
            lblConfirm.AutoSize = true;
            lblConfirm.Location = new Point(357, 133);
            lblConfirm.Name = "lblConfirm";
            lblConfirm.Size = new Size(107, 15);
            lblConfirm.TabIndex = 19;
            lblConfirm.Text = "Confirm password:";
            // 
            // cbPassChange
            // 
            cbPassChange.AutoSize = true;
            cbPassChange.Location = new Point(470, 163);
            cbPassChange.Name = "cbPassChange";
            cbPassChange.Size = new Size(113, 19);
            cbPassChange.TabIndex = 21;
            cbPassChange.Text = "Chage password";
            cbPassChange.UseVisualStyleBackColor = true;
            cbPassChange.CheckedChanged += cbPassChange_CheckedChanged;
            // 
            // cbPassShow
            // 
            cbPassShow.AutoSize = true;
            cbPassShow.Location = new Point(594, 163);
            cbPassShow.Name = "cbPassShow";
            cbPassShow.Size = new Size(108, 19);
            cbPassShow.TabIndex = 22;
            cbPassShow.Text = "Show password";
            cbPassShow.UseVisualStyleBackColor = true;
            cbPassShow.CheckedChanged += cbPassShow_CheckedChanged;
            // 
            // frmUserAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(728, 255);
            Controls.Add(cbPassShow);
            Controls.Add(cbPassChange);
            Controls.Add(tbConfirm);
            Controls.Add(lblConfirm);
            Controls.Add(tbEmail);
            Controls.Add(label4);
            Controls.Add(tbUsername);
            Controls.Add(label7);
            Controls.Add(tbPassword);
            Controls.Add(lblPass);
            Controls.Add(tbPhone);
            Controls.Add(label6);
            Controls.Add(btnAdd);
            Controls.Add(tbLastname);
            Controls.Add(label3);
            Controls.Add(cbRole);
            Controls.Add(label2);
            Controls.Add(tbName);
            Controls.Add(label1);
            Name = "frmUserAdd";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmVehicleModelAdd";
            Load += frmUserAdd_Load;
            ((System.ComponentModel.ISupportInitialize)err).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbName;
        private Label label2;
        private ComboBox cbRole;
        private Label label3;
        private TextBox tbLastname;
        private Button btnAdd;
        private ErrorProvider err;
        private TextBox tbConfirm;
        private Label lblConfirm;
        private TextBox tbEmail;
        private Label label4;
        private TextBox tbUsername;
        private Label label7;
        private TextBox tbPassword;
        private Label lblPass;
        private TextBox tbPhone;
        private Label label6;
        private CheckBox cbPassChange;
        private CheckBox cbPassShow;
    }
}