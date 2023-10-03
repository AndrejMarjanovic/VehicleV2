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
    public partial class frmFuelType : Form
    {
        private readonly APIService _FuelType = new APIService("FuelType");
        public frmFuelType()
        {
            InitializeComponent();
            dgvFuelTypes.AutoGenerateColumns = false;

            foreach (DataGridViewColumn column in dgvFuelTypes.Columns)
            {

                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private async void frmFuelType_Load(object sender, EventArgs e)
        {
            await LoadData();
            LoadPages();
        }

        private async Task LoadData()
        {
            dgvFuelTypes.DataSource = await _FuelType.Get<List<FuelTypeModel>>();
        }
        private void LoadPages()
        {
            int totalPages = dgvFuelTypes.Rows.Count / 4;
            if (dgvFuelTypes.Rows.Count % 4 != 0)
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
                dgvFuelTypes.DataSource = await _FuelType.GetFiltered<List<FuelTypeModel>>(parameters);
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

        private async void dgvFuelType_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvFuelTypes.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
            string sort = dgvFuelTypes.Columns[e.ColumnIndex].Name;
            await GetFilteredData(sort);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmFuelTypeAdd frm = new frmFuelTypeAdd(dgvFuelTypes);
            frm.Show();
        }

        private async void dgvFuelTypes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var fuel = dgvFuelTypes.SelectedRows[0].DataBoundItem as FuelTypeModel;

            if (e.ColumnIndex == 3)
            {

                DialogResult result = MessageBox.Show("Are you sure you want to delete " + fuel.Type + " ?", "Warning", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    await _FuelType.Delete<FuelTypeModel>(fuel.Id);
                    await GetFilteredData();


                }
                else if (result == DialogResult.No)
                {
                    return;
                }
            }
            else if (e.ColumnIndex == 2)
            {
                if (fuel != null)
                {

                    frmFuelTypeAdd frm = new frmFuelTypeAdd(dgvFuelTypes, fuel.Id);
                    frm.ShowDialog();

                }
            }
        }
    }
}
