using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vehicle.FormUI.API;
using Vehicle.Model;

namespace Vehicle.FormUI.Forms
{
    public partial class frmVehicleModel : Form
    {
        private readonly APIService _vehicleModels = new APIService("VehicleModel");
        public frmVehicleModel()
        {
            InitializeComponent();
            dgvVehicleModels.AutoGenerateColumns = false;

            foreach (DataGridViewColumn column in dgvVehicleModels.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private async void frmVehicleModel_Load(object sender, EventArgs e)
        {
            await LoadData();
            LoadPages();
        }

        private async Task LoadData()
        {
            dgvVehicleModels.DataSource = await _vehicleModels.Get<List<VehicleModelModel>>();
        }
        private void LoadPages()
        {
            int totalPages = dgvVehicleModels.Rows.Count / 4;
            if (dgvVehicleModels.Rows.Count % 4 != 0)
                totalPages += 1;

            object[] pages = new object[totalPages + 1];

            for (int i = 0; i <= totalPages; i++)
            {
                pages[i] = i;
            }

            cbPages.Items.AddRange(pages);
            cbPages.SelectedIndex = 0;
        }

        public async Task GetFilteredData(string? sort = null)
        {
            var parameters = new
            {
                page = cbPages.SelectedIndex,
                search = tbSearch.Text,
                sortBy = sort
            };

            if ((cbPages.SelectedIndex == 0) && tbSearch.Text.IsNullOrEmpty())
            {
                await LoadData();
            }
            else
            {
                dgvVehicleModels.DataSource = await _vehicleModels.GetFiltered<List<VehicleModelModel>>(parameters);
            }
        }

        private async void tbSearch_TextChanged(object sender, EventArgs e)
        {
            await GetFilteredData();
        }

        private async void cbPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            await GetFilteredData();
        }

        private async void dgvVehicleModels_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvVehicleModels.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
            string sort = dgvVehicleModels.Columns[e.ColumnIndex].Name;
            await GetFilteredData(sort);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmVehicleModelAdd frm = new frmVehicleModelAdd(dgvVehicleModels);
            frm.Show();
        }

        private async void dgvVehicleModels_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var model = dgvVehicleModels.SelectedRows[0].DataBoundItem as VehicleModelModel;

            if (e.ColumnIndex == 4)
            {

                DialogResult result = MessageBox.Show("Are you sure you want to delete: " + model.Name + "?", "Warning", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    await _vehicleModels.Delete<VehicleModelModel>(model.Id);
                    await GetFilteredData();
                }
                else if (result == DialogResult.No)
                {
                    return;
                }
            }
            else if (e.ColumnIndex == 3)
            {
                if (model != null)
                {
                    frmVehicleModelAdd frm = new frmVehicleModelAdd(dgvVehicleModels, model.Id);
                    frm.ShowDialog();
                }
            }
        }
    }
}
