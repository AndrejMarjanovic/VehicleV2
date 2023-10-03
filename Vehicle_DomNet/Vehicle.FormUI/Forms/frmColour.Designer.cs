namespace Vehicle.FormUI.Forms
{
    partial class frmColour
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            btnAdd = new Button();
            tbSearch = new TextBox();
            label1 = new Label();
            dgvColours = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            ColourName = new DataGridViewTextBoxColumn();
            ColourCode = new DataGridViewTextBoxColumn();
            EditModel = new DataGridViewButtonColumn();
            Delete = new DataGridViewButtonColumn();
            Id = new DataGridViewTextBoxColumn();
            label2 = new Label();
            cbPages = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvColours).BeginInit();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(641, 20);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(147, 23);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Add new";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // tbSearch
            // 
            tbSearch.Location = new Point(63, 20);
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(230, 23);
            tbSearch.TabIndex = 6;
            tbSearch.TextChanged += tbSearch_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 23);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 5;
            label1.Text = "Search:";
            // 
            // dgvColours
            // 
            dgvColours.AllowUserToAddRows = false;
            dgvColours.AllowUserToDeleteRows = false;
            dgvColours.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvColours.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvColours.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvColours.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, ColourName, ColourCode, EditModel, Delete });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvColours.DefaultCellStyle = dataGridViewCellStyle3;
            dgvColours.Location = new Point(12, 59);
            dgvColours.Name = "dgvColours";
            dgvColours.ReadOnly = true;
            dgvColours.RowTemplate.Height = 25;
            dgvColours.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvColours.Size = new Size(776, 259);
            dgvColours.TabIndex = 0;
            dgvColours.CellContentClick += dgvSeats_CellContentClick;
            dgvColours.ColumnHeaderMouseClick += dgvColour_ColumnHeaderMouseClick;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewTextBoxColumn1.DataPropertyName = "id";
            dataGridViewTextBoxColumn1.HeaderText = "Id";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Width = 42;
            // 
            // ColourName
            // 
            ColourName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColourName.DataPropertyName = "name";
            ColourName.HeaderText = "Colour";
            ColourName.Name = "ColourName";
            ColourName.ReadOnly = true;
            // 
            // ColourCode
            // 
            ColourCode.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            ColourCode.DataPropertyName = "colourCode";
            ColourCode.HeaderText = "Colour code";
            ColourCode.Name = "ColourCode";
            ColourCode.ReadOnly = true;
            ColourCode.Width = 97;
            // 
            // EditModel
            // 
            EditModel.HeaderText = "";
            EditModel.Name = "EditModel";
            EditModel.ReadOnly = true;
            EditModel.Text = "Edit";
            EditModel.UseColumnTextForButtonValue = true;
            // 
            // Delete
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(192, 0, 0);
            Delete.DefaultCellStyle = dataGridViewCellStyle2;
            Delete.HeaderText = "";
            Delete.Name = "Delete";
            Delete.ReadOnly = true;
            Delete.Resizable = DataGridViewTriState.True;
            Delete.SortMode = DataGridViewColumnSortMode.Automatic;
            Delete.Text = "Delete";
            Delete.UseColumnTextForButtonValue = true;
            // 
            // Id
            // 
            Id.DataPropertyName = "id";
            Id.HeaderText = "Id";
            Id.Name = "Id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 341);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 8;
            label2.Text = "Select page:";
            // 
            // cbPages
            // 
            cbPages.FormattingEnabled = true;
            cbPages.Location = new Point(88, 338);
            cbPages.Name = "cbPages";
            cbPages.Size = new Size(64, 23);
            cbPages.TabIndex = 9;
            cbPages.SelectedIndexChanged += cbPages_SelectedIndexChanged;
            // 
            // frmColour
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cbPages);
            Controls.Add(label2);
            Controls.Add(btnAdd);
            Controls.Add(tbSearch);
            Controls.Add(label1);
            Controls.Add(dgvColours);
            Name = "frmColour";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmVehicleModel";
            Load += frmColour_Load;
            ((System.ComponentModel.ISupportInitialize)dgvColours).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdd;
        private TextBox tbSearch;
        private Label label1;
        private DataGridView dgvColours;
        private DataGridViewTextBoxColumn Id;
        private Label label2;
        private ComboBox cbPages;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn ColourName;
        private DataGridViewTextBoxColumn ColourCode;
        private DataGridViewButtonColumn EditModel;
        private DataGridViewButtonColumn Delete;
    }
}