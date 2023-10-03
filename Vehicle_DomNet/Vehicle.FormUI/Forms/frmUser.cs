using Microsoft.IdentityModel.Tokens;
using Vehicle.FormUI.API;
using Vehicle.Model;

namespace Vehicle.FormUI.Forms
{
    public partial class frmUser : Form
    {
        private readonly APIService _Users = new APIService("User");
        public frmUser()
        {
            InitializeComponent();
            dgvUsers.AutoGenerateColumns = false;

            foreach (DataGridViewColumn column in dgvUsers.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private async void frmUser_Load(object sender, EventArgs e)
        {
            await LoadData();
            LoadPages();
        }

        private async Task LoadData()
        {
            dgvUsers.DataSource = await _Users.Get<List<UserModel>>();
        }
        private void LoadPages()
        {
            int totalPages = dgvUsers.Rows.Count / 4;
            if (dgvUsers.Rows.Count % 4 != 0)
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
                dgvUsers.DataSource = await _Users.GetFiltered<List<UserModel>>(parameters);
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

        private async void dgvUsers_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvUsers.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
            string sort = dgvUsers.Columns[e.ColumnIndex].Name;
            await GetFilteredData(sort);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmUserAdd frm = new frmUserAdd(dgvUsers);
            frm.Show();
        }

        private async void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var user = dgvUsers.SelectedRows[0].DataBoundItem as UserModel;

            if (e.ColumnIndex == 8)
            {

                DialogResult result = MessageBox.Show("Are you sure you want to delete the selected user?", "Warning", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    await _Users.Delete<EngineModel>(user.Id);
                    if(user.Id == APIService.LoggedUser.Id)
                    { 
                        Application.Restart();
                    }
                    else
                    {
                       GetFilteredData();
                    }
                }
                else if (result == DialogResult.No)
                {
                    return;
                }
            }
            else if (e.ColumnIndex == 7)
            {
                if (user != null)
                {

                    frmUserAdd frm = new frmUserAdd(dgvUsers, user.Id);
                    frm.ShowDialog();

                }
            }
        }
    }
}
