using Microsoft.IdentityModel.Tokens;
using Vehicle.FormUI.API;
using Vehicle.Model;

namespace Vehicle.FormUI.Forms
{
    public partial class frmSeatTypeColour : Form
    {
        private readonly APIService _seatTypeColour = new APIService("SeatTypeColour");
        public frmSeatTypeColour()
        {
            InitializeComponent();
            dgvSTColour.AutoGenerateColumns = false;

            foreach (DataGridViewColumn column in dgvSTColour.Columns)
            {

                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private async void frmSeatTypeColour_Load(object sender, EventArgs e)
        {
            await LoadData();
            LoadPages();
        }

        private async Task LoadData()
        {
            dgvSTColour.DataSource = await _seatTypeColour.Get<List<SeatTypeColourModel>>();
        }
        private void LoadPages()
        {
            int totalPages = dgvSTColour.Rows.Count / 4;
            if (dgvSTColour.Rows.Count % 4 != 0)
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
                dgvSTColour.DataSource = await _seatTypeColour.GetFiltered<List<SeatTypeColourModel>>(parameters);
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

        private async void dgvSeatTypeColour_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvSTColour.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
            string sort = dgvSTColour.Columns[e.ColumnIndex].Name;
            await GetFilteredData(sort);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSeatTypeColourAdd frm = new frmSeatTypeColourAdd(dgvSTColour);
            frm.Show();
        }

        private async void dgvSeats_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var stColour = dgvSTColour.SelectedRows[0].DataBoundItem as SeatTypeColourModel;

            if (e.ColumnIndex == 4)
            {

                DialogResult result = MessageBox.Show("Are you sure you want to delete this seat type colour?", "Warning", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    await _seatTypeColour.Delete<SeatTypeColourModel>(stColour.Id);
                    await GetFilteredData();


                }
                else if (result == DialogResult.No)
                {
                    return;
                }
            }
            else if (e.ColumnIndex == 3)
            {
                if (stColour != null)
                {
                    frmSeatTypeColourAdd frm = new frmSeatTypeColourAdd(dgvSTColour, stColour.Id);
                    frm.ShowDialog();
                }
            }
        }
    }
}
