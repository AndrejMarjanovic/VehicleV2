using Microsoft.EntityFrameworkCore.Diagnostics;
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
    public partial class frmSeatType : Form
    {
        private readonly APIService _SeatType = new APIService("SeatType");
        public frmSeatType()
        {
            InitializeComponent();
            dgvSeatType.AutoGenerateColumns = false;

            foreach (DataGridViewColumn column in dgvSeatType.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private async void frmSeatType_Load(object sender, EventArgs e)
        {
            await LoadData();
            LoadPages();
        }

        private async Task LoadData()
        {
            dgvSeatType.DataSource = await _SeatType.Get<List<SeatTypeModel>>();
        }
        private void LoadPages()
        {
            int totalPages = dgvSeatType.Rows.Count / 4;
            if (dgvSeatType.Rows.Count % 4 != 0)
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
                dgvSeatType.DataSource = await _SeatType.GetFiltered<List<SeatTypeModel>>(parameters);
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

        private async void dgvSeatType_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvSeatType.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
            string sort = dgvSeatType.Columns[e.ColumnIndex].Name;
            await GetFilteredData(sort);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSeatTypeAdd frm = new frmSeatTypeAdd(dgvSeatType);
            frm.Show();
        }

        private async void dgvSeats_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var seatType = dgvSeatType.SelectedRows[0].DataBoundItem as SeatTypeModel;

            if (e.ColumnIndex == 3)
            {

                DialogResult result = MessageBox.Show("Are you sure you want to delete this seat type?", "Warning", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    await _SeatType.Delete<SeatTypeModel>(seatType.Id);
                    await GetFilteredData();


                }
                else if (result == DialogResult.No)
                {
                    return;
                }
            }
            else if (e.ColumnIndex == 2)
            {
                if (seatType != null)
                {
                    frmSeatTypeAdd frm = new frmSeatTypeAdd(dgvSeatType, seatType.Id);
                    frm.ShowDialog();
                }
            }
        }
    }
}
