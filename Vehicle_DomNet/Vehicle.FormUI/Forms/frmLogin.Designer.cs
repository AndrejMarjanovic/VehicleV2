namespace Vehicle.FormUI.Forms
{
    partial class frmLogin
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
            tbUsername = new TextBox();
            tbPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnLogin = new Button();
            err = new ErrorProvider(components);
            cbShowPass = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)err).BeginInit();
            SuspendLayout();
            // 
            // tbUsername
            // 
            tbUsername.BackColor = Color.FromArgb(56, 75, 103);
            tbUsername.BorderStyle = BorderStyle.FixedSingle;
            tbUsername.ForeColor = SystemColors.ButtonFace;
            tbUsername.Location = new Point(141, 48);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(219, 23);
            tbUsername.TabIndex = 0;
            tbUsername.KeyDown += tbUsername_KeyDown;
            // 
            // tbPassword
            // 
            tbPassword.BackColor = Color.FromArgb(56, 75, 103);
            tbPassword.BorderStyle = BorderStyle.FixedSingle;
            tbPassword.ForeColor = SystemColors.ButtonFace;
            tbPassword.Location = new Point(141, 94);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '*';
            tbPassword.Size = new Size(219, 23);
            tbPassword.TabIndex = 1;
            tbPassword.KeyDown += tbPassword_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(66, 56);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 2;
            label1.Text = "Username:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(66, 102);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 3;
            label2.Text = "Password:";
            // 
            // btnLogin
            // 
            btnLogin.FlatAppearance.BorderColor = Color.FromArgb(70, 140, 225);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.ForeColor = SystemColors.ButtonFace;
            btnLogin.Location = new Point(257, 163);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(103, 23);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Log in";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // err
            // 
            err.ContainerControl = this;
            // 
            // cbShowPass
            // 
            cbShowPass.AutoSize = true;
            cbShowPass.ForeColor = SystemColors.ButtonFace;
            cbShowPass.Location = new Point(252, 123);
            cbShowPass.Name = "cbShowPass";
            cbShowPass.Size = new Size(108, 19);
            cbShowPass.TabIndex = 5;
            cbShowPass.Text = "Show Password";
            cbShowPass.UseVisualStyleBackColor = true;
            cbShowPass.CheckedChanged += cbShowPass_CheckedChanged;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(35, 47, 65);
            ClientSize = new Size(440, 222);
            Controls.Add(cbShowPass);
            Controls.Add(btnLogin);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbPassword);
            Controls.Add(tbUsername);
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmLogin";
            ((System.ComponentModel.ISupportInitialize)err).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbUsername;
        private TextBox tbPassword;
        private Label label1;
        private Label label2;
        private Button btnLogin;
        private ErrorProvider err;
        private CheckBox cbShowPass;
    }
}