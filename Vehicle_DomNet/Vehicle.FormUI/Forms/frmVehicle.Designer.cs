namespace Vehicle.FormUI.Forms
{
    partial class frmVehicle
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
            Mileage = new DataGridViewTextBoxColumn();
            dgvVehicles = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Model = new DataGridViewTextBoxColumn();
            VehicleType = new DataGridViewTextBoxColumn();
            Engine = new DataGridViewTextBoxColumn();
            Year = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            label1 = new Label();
            tbSearch = new TextBox();
            btnAdd = new Button();
            cbPages = new ComboBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvVehicles).BeginInit();
            SuspendLayout();
            // 
            // Mileage
            // 
            Mileage.DataPropertyName = "Mileage";
            Mileage.HeaderText = "Mileage";
            Mileage.Name = "Mileage";
            // 
            // dgvVehicles
            // 
            dgvVehicles.AllowUserToAddRows = false;
            dgvVehicles.AllowUserToDeleteRows = false;
            dgvVehicles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVehicles.Columns.AddRange(new DataGridViewColumn[] { Id, Model, VehicleType, Engine, Year, dataGridViewTextBoxColumn1 });
            dgvVehicles.Location = new Point(12, 58);
            dgvVehicles.Name = "dgvVehicles";
            dgvVehicles.ReadOnly = true;
            dgvVehicles.RowTemplate.Height = 25;
            dgvVehicles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVehicles.Size = new Size(776, 258);
            dgvVehicles.TabIndex = 0;
            dgvVehicles.CellContentClick += dgvVehicles_CellContentClick;
            dgvVehicles.ColumnHeaderMouseClick += dgvVehicles_ColumnHeaderMouseClick;
            // 
            // Id
            // 
            Id.DataPropertyName = "id";
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.ReadOnly = true;
            // 
            // Model
            // 
            Model.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Model.DataPropertyName = "vehicleModel";
            Model.HeaderText = "Model name";
            Model.Name = "Model";
            Model.ReadOnly = true;
            // 
            // VehicleType
            // 
            VehicleType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            VehicleType.DataPropertyName = "VehicleType";
            VehicleType.HeaderText = "Vehicle type";
            VehicleType.Name = "VehicleType";
            VehicleType.ReadOnly = true;
            // 
            // Engine
            // 
            Engine.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Engine.DataPropertyName = "engine";
            Engine.HeaderText = "Engine";
            Engine.Name = "Engine";
            Engine.ReadOnly = true;
            // 
            // Year
            // 
            Year.DataPropertyName = "productionYear";
            Year.HeaderText = "Year";
            Year.Name = "Year";
            Year.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn1.DataPropertyName = "mileage";
            dataGridViewTextBoxColumn1.HeaderText = "Mileage (Km)";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 22);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 1;
            label1.Text = "Search:";
            // 
            // tbSearch
            // 
            tbSearch.Location = new Point(63, 19);
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(230, 23);
            tbSearch.TabIndex = 2;
            tbSearch.TextChanged += tbSearch_TextChanged;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(641, 22);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(147, 23);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Add new";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // cbPages
            // 
            cbPages.FormattingEnabled = true;
            cbPages.Location = new Point(92, 339);
            cbPages.Name = "cbPages";
            cbPages.Size = new Size(64, 23);
            cbPages.TabIndex = 11;
            cbPages.SelectedIndexChanged += cbPages_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 342);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 10;
            label2.Text = "Select page:";
            // 
            // frmVehicle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cbPages);
            Controls.Add(label2);
            Controls.Add(btnAdd);
            Controls.Add(tbSearch);
            Controls.Add(label1);
            Controls.Add(dgvVehicles);
            Name = "frmVehicle";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmVehicle";
            Load += frmVehicle_Load;
            ((System.ComponentModel.ISupportInitialize)dgvVehicles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridViewTextBoxColumn Mileage;
        private DataGridView dgvVehicles;
        private Label label1;
        private TextBox tbSearch;
        private Button btnAdd;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Model;
        private DataGridViewTextBoxColumn VehicleType;
        private DataGridViewTextBoxColumn Engine;
        private DataGridViewTextBoxColumn Year;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private ComboBox cbPages;
        private Label label2;
    }
}