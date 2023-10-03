namespace Vehicle.FormUI.Forms
{
    partial class frmChat
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
            label2 = new Label();
            btnSend = new Button();
            lbChat = new ListBox();
            btnClear = new Button();
            lblStatus = new Label();
            tbMessage = new TextBox();
            lblUser = new Label();
            lblDateTime = new Label();
            DateTimeTimer = new System.Windows.Forms.Timer(components);
            label3 = new Label();
            lbUsers = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(239, 43);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 0;
            label1.Text = "User:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(367, 445);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 1;
            label2.Text = "Message:";
            // 
            // btnSend
            // 
            btnSend.Anchor = AnchorStyles.None;
            btnSend.BackColor = Color.FromArgb(35, 47, 65);
            btnSend.FlatAppearance.BorderColor = Color.FromArgb(70, 140, 225);
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.ForeColor = SystemColors.ButtonFace;
            btnSend.Location = new Point(781, 441);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(101, 23);
            btnSend.TabIndex = 3;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // lbChat
            // 
            lbChat.Anchor = AnchorStyles.None;
            lbChat.BackColor = Color.FromArgb(30, 40, 55);
            lbChat.BorderStyle = BorderStyle.None;
            lbChat.ColumnWidth = 10;
            lbChat.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbChat.ForeColor = SystemColors.ButtonFace;
            lbChat.FormattingEnabled = true;
            lbChat.ItemHeight = 17;
            lbChat.Location = new Point(239, 72);
            lbChat.Name = "lbChat";
            lbChat.RightToLeft = RightToLeft.No;
            lbChat.Size = new Size(643, 323);
            lbChat.TabIndex = 4;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.None;
            btnClear.BackColor = Color.FromArgb(35, 47, 65);
            btnClear.BackgroundImageLayout = ImageLayout.None;
            btnClear.FlatAppearance.BorderColor = Color.FromArgb(70, 140, 225);
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnClear.ForeColor = SystemColors.ButtonFace;
            btnClear.Location = new Point(239, 405);
            btnClear.Name = "btnClear";
            btnClear.RightToLeft = RightToLeft.No;
            btnClear.Size = new Size(102, 23);
            btnClear.TabIndex = 6;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.ForeColor = Color.FromArgb(107, 207, 97);
            lblStatus.Location = new Point(28, 9);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 15);
            lblStatus.TabIndex = 7;
            // 
            // tbMessage
            // 
            tbMessage.Anchor = AnchorStyles.None;
            tbMessage.BackColor = Color.FromArgb(56, 75, 103);
            tbMessage.BorderStyle = BorderStyle.FixedSingle;
            tbMessage.ForeColor = SystemColors.ButtonFace;
            tbMessage.Location = new Point(431, 441);
            tbMessage.Name = "tbMessage";
            tbMessage.Size = new Size(344, 23);
            tbMessage.TabIndex = 8;
            tbMessage.KeyDown += tbMessage_KeyDown;
            // 
            // lblUser
            // 
            lblUser.Anchor = AnchorStyles.None;
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblUser.ForeColor = Color.FromArgb(70, 140, 225);
            lblUser.Location = new Point(281, 39);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(38, 20);
            lblUser.TabIndex = 9;
            lblUser.Text = "User";
            // 
            // lblDateTime
            // 
            lblDateTime.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblDateTime.AutoSize = true;
            lblDateTime.ForeColor = Color.FromArgb(70, 140, 225);
            lblDateTime.Location = new Point(28, 488);
            lblDateTime.Name = "lblDateTime";
            lblDateTime.RightToLeft = RightToLeft.No;
            lblDateTime.Size = new Size(57, 15);
            lblDateTime.TabIndex = 10;
            lblDateTime.Text = "DateTime";
            // 
            // DateTimeTimer
            // 
            DateTimeTimer.Tick += timer1_Tick;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(54, 43);
            label3.Name = "label3";
            label3.Size = new Size(78, 15);
            label3.TabIndex = 12;
            label3.Text = "Active users:";
            // 
            // lbUsers
            // 
            lbUsers.Anchor = AnchorStyles.None;
            lbUsers.BackColor = Color.FromArgb(30, 40, 55);
            lbUsers.BorderStyle = BorderStyle.None;
            lbUsers.ColumnWidth = 10;
            lbUsers.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbUsers.ForeColor = SystemColors.ButtonFace;
            lbUsers.FormattingEnabled = true;
            lbUsers.ItemHeight = 17;
            lbUsers.Location = new Point(54, 72);
            lbUsers.Name = "lbUsers";
            lbUsers.RightToLeft = RightToLeft.No;
            lbUsers.Size = new Size(170, 323);
            lbUsers.TabIndex = 13;
            // 
            // frmChat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(35, 47, 65);
            ClientSize = new Size(935, 512);
            Controls.Add(lbUsers);
            Controls.Add(label3);
            Controls.Add(lblDateTime);
            Controls.Add(lblUser);
            Controls.Add(tbMessage);
            Controls.Add(lblStatus);
            Controls.Add(btnClear);
            Controls.Add(lbChat);
            Controls.Add(btnSend);
            Controls.Add(label2);
            Controls.Add(label1);
            MinimumSize = new Size(851, 541);
            Name = "frmChat";
            RightToLeft = RightToLeft.No;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chat";
            FormClosed += frmChat_FormClosed;
            Load += frmChat_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button btnSend;
        private ListBox lbChat;
        private Button btnClear;
        private Label lblStatus;
        private TextBox tbMessage;
        private Label lblUser;
        private Label lblDateTime;
        private System.Windows.Forms.Timer DateTimeTimer;
        private Label label3;
        private ListBox lbUsers;
    }
}