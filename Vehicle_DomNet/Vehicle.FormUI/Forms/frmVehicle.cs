using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vehicle.FormUI.API;
using Vehicle.Model;

namespace Vehicle.FormUI.Forms
{
    public partial class frmVehicle : Form
    {
        private readonly APIService _vehicles = new APIService("Vehicle");
        public frmVehicle()
        {
            InitializeComponent();
            dgvVehicles.AutoGenerateColumns = false;

        }

        private async void frmVehicle_Load(object sender, EventArgs e)
        {
            await LoadData();
            LoadPages();
        }

        private async Task LoadData()
        {
            dgvVehicles.DataSource = await _vehicles.Get<List<VehicleEntityModel>>();
        }

        private void LoadPages()
        {
            int totalPages = dgvVehicles.Rows.Count / 4;
            if (dgvVehicles.Rows.Count % 4 != 0)
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
                dgvVehicles.DataSource = await _vehicles.GetFiltered<List<VehicleEntityModel>>(parameters);
            }
        }

        private async void tbSearch_TextChanged(object sender, EventArgs e)
        {
            await GetFilteredData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmVehicleAdd frm = new frmVehicleAdd();
            frm.Show();
        }

        private async void cbPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            await GetFilteredData();
        }

        private async void dgvVehicles_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvVehicles.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
            string sort = dgvVehicles.Columns[e.ColumnIndex].Name;
            await GetFilteredData(sort);
        }

        private async void dgvVehicles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var model = dgvVehicles.SelectedRows[0].DataBoundItem as VehicleEntityModel;

            if (e.ColumnIndex == 4)
            {

                DialogResult result = MessageBox.Show("Are you sure you want to delete this vehicle?", "Warning", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    await _vehicles.Delete<VehicleEntityModel>(model.Id);
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
                    frmVehicleAdd frm = new frmVehicleAdd(dgvVehicles, model.Id);
                    frm.ShowDialog();
                }
            }
        }
    }
}
