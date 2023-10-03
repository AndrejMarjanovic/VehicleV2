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
    public partial class frmColour : Form
    {
        private readonly APIService _Colour = new APIService("Colour");
        public frmColour()
        {
            InitializeComponent();
            dgvColours.AutoGenerateColumns = false;

            foreach (DataGridViewColumn column in dgvColours.Columns)
            {

                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private async void frmColour_Load(object sender, EventArgs e)
        {
            await LoadData();
            LoadPages();
        }

        private async Task LoadData()
        {
            dgvColours.DataSource = await _Colour.Get<List<ColourModel>>();
        }
        private void LoadPages()
        {
            int totalPages = dgvColours.Rows.Count / 4;
            if (dgvColours.Rows.Count % 4 != 0)
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
                dgvColours.DataSource = await _Colour.GetFiltered<List<ColourModel>>(parameters);
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

        private async void dgvColour_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvColours.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
            string sort = dgvColours.Columns[e.ColumnIndex].Name;
            await GetFilteredData(sort);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmColourAdd frm = new frmColourAdd(dgvColours);
            frm.Show();
        }

        private async void dgvSeats_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var colour = dgvColours.SelectedRows[0].DataBoundItem as ColourModel;

            if (e.ColumnIndex == 4)
            {

                DialogResult result = MessageBox.Show($"Are you sure you want to delete the colour {colour.Name.ToLower()}?", "Warning", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    await _Colour.Delete<ColourModel>(colour.Id);
                    await GetFilteredData();
                }
                else if (result == DialogResult.No)
                {
                    return;
                }
            }
            else if (e.ColumnIndex == 3)
            {
                if (colour != null)
                {
                    frmColourAdd frm = new frmColourAdd(dgvColours, colour.Id);
                    frm.ShowDialog();
                }
            }
        }
    }
}
