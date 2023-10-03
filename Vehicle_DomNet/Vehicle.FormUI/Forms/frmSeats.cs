using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using Vehicle.FormUI.API;
using Vehicle.Model;

namespace Vehicle.FormUI.Forms
{
    public partial class frmSeats : Form
    {
        private readonly APIService _Seats = new APIService("Seats");
        public frmSeats()
        {
            InitializeComponent();
            dgvSeats.AutoGenerateColumns = false;

            foreach (DataGridViewColumn column in dgvSeats.Columns)
            {

                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private async void frmSeats_Load(object sender, EventArgs e)
        {
            await LoadData();
            LoadPages();
        }

        private async Task LoadData()
        {
            dgvSeats.DataSource = await _Seats.Get<List<SeatsModel>>();
        }
        private void LoadPages()
        {
            int totalPages = dgvSeats.Rows.Count / 4;
            if (dgvSeats.Rows.Count % 4 != 0)
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
                dgvSeats.DataSource = await _Seats.GetFiltered<List<SeatsModel>>(parameters);
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

        private async void dgvSeats_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvSeats.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
            string sort = dgvSeats.Columns[e.ColumnIndex].Name;
            await GetFilteredData(sort);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSeatsAdd frm = new frmSeatsAdd(dgvSeats);
            frm.Show();
        }

        private async void dgvSeats_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var seats = dgvSeats.SelectedRows[0].DataBoundItem as SeatsModel;

            if (e.ColumnIndex == 4)
            {

                DialogResult result = MessageBox.Show("Are you sure you want to delete this seat combination?", "Warning", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    await _Seats.Delete<SeatsModel>(seats.Id);
                    await GetFilteredData();


                }
                else if (result == DialogResult.No)
                {
                    return;
                }
            }
            else if (e.ColumnIndex == 3)
            {
                if (seats != null)
                {
                    frmSeatsAdd frm = new frmSeatsAdd(dgvSeats, seats.Id);
                    frm.ShowDialog();
                }
            }
        }
    }
}
