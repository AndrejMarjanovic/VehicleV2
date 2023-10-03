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
    public partial class frmEngine : Form
    {
        private readonly APIService _Engines = new APIService("Engine");
        public frmEngine()
        {
            InitializeComponent();
            dgvEngines.AutoGenerateColumns = false;

            foreach (DataGridViewColumn column in dgvEngines.Columns)
            {

                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private async void frmEngine_Load(object sender, EventArgs e)
        {
            await LoadData();
            LoadPages();
        }

        private async Task LoadData()
        {
            dgvEngines.DataSource = await _Engines.Get<List<EngineModel>>();
        }
        private void LoadPages()
        {
            int totalPages = dgvEngines.Rows.Count / 4;
            if (dgvEngines.Rows.Count % 4 != 0)
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
                dgvEngines.DataSource = await _Engines.GetFiltered<List<EngineModel>>(parameters);
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

        private async void dgvEngines_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvEngines.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
            string sort = dgvEngines.Columns[e.ColumnIndex].Name;
            await GetFilteredData(sort);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmEngineAdd frm = new frmEngineAdd(dgvEngines);
            frm.Show();
        }

        private async void dgvEngines_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var engine = dgvEngines.SelectedRows[0].DataBoundItem as EngineModel;

            if (e.ColumnIndex == 7)
            {

                DialogResult result = MessageBox.Show("Are you sure you want to delete the selected engine?", "Warning", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    await _Engines.Delete<EngineModel>(engine.Id);
                    await GetFilteredData();


                }
                else if (result == DialogResult.No)
                {
                    return;
                }
            }
            else if (e.ColumnIndex == 6)
            {
                if (engine != null)
                {

                    frmEngineAdd frm = new frmEngineAdd(dgvEngines, engine.Id);
                    frm.ShowDialog();

                }
            }
        }
    }
}
