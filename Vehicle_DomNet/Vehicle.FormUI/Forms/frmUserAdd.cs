using System.Data;
using System.Text.RegularExpressions;
using Vehicle.FormUI.API;
using Vehicle.Model;

namespace Vehicle.FormUI.Forms
{
    public partial class frmUserAdd : Form
    {
        private readonly APIService _users = new APIService("User");
        private readonly APIService _roles = new APIService("Role");

        private int? _id = null;
        private DataGridView? _dgvUsers = null;
        public frmUserAdd(DataGridView? dgvUsers = null, int? id = null)
        {
            InitializeComponent();
            _dgvUsers = dgvUsers;
            _id = id;
        }

        private async void frmUserAdd_Load(object sender, EventArgs e)
        {
            await LoadRoles();

            if (_id.HasValue) // User update
            {
                var user = await _users.GetById<UserModel>(_id);
                tbName.Text = user.Name;
                tbLastname.Text = user.LastName;
                tbUsername.Text = user.Username;
                tbEmail.Text = user.Email;
                tbPhone.Text = user.Phone.ToString();


                if (!cbPassChange.Checked)
                {
                    tbPassword.Enabled = false;
                    tbConfirm.Enabled = false;
                    lblPass.Hide();
                    lblConfirm.Hide();
                    cbPassShow.Enabled = false;
                }


                foreach (RoleModel role in cbRole.Items)
                {
                    if (role.Id == user.RoleId)
                        cbRole.SelectedItem = role;
                }
            }
            else
            {
                cbPassChange.Hide();
            }
        }

        private async Task LoadRoles()
        {
            var result = await _roles.Get<List<RoleModel>>();
            result.Insert(0, new RoleModel());
            cbRole.DisplayMember = "Name";
            cbRole.ValueMember = "Id";
            cbRole.DataSource = result;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (await Validate())
            {
                int roleID = (cbRole.SelectedItem as RoleModel).Id;

                UserPostModel request = new UserPostModel()
                {
                    Name = tbName.Text,
                    LastName = tbLastname.Text,
                    Username = tbUsername.Text,
                    Email = tbEmail.Text,
                    Phone = tbPhone.Text,
                    Password = tbPassword.Text,
                    PasswordConfirm = tbConfirm.Text,
                    RoleId = roleID

                };


                if (_id.HasValue)
                {
                    await _users.UpdateUser<UserModel>(_id, request);

                    if (_id == APIService.LoggedUser.Id)
                    {
                        APIService.Username = request.Username;
                        if (!string.IsNullOrWhiteSpace(request.Password))
                        {
                            APIService.Password = request.Password;
                        }
                    }
                }
                else
                {
                    await _users.Insert<UserModel>(request);
                }


                Close();
                if (_dgvUsers != null)
                {
                    List<UserModel> users = await _users.Get<List<UserModel>>();
                    _dgvUsers.DataSource = users;
                    APIService.LoggedUser = users.Where(x => x.Username == APIService.Username).FirstOrDefault();
                }
            }
        }

        private void cbPassChange_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPassChange.Checked)
            {
                tbPassword.Enabled = true;
                tbConfirm.Enabled = true;
                lblPass.Show();
                lblConfirm.Show();
                cbPassShow.Enabled = true;
            }
            else
            {
                tbPassword.Clear();
                tbConfirm.Clear();
                tbPassword.Enabled = false;
                tbConfirm.Enabled = false;
                lblPass.Hide();
                lblConfirm.Hide();
                cbPassShow.Enabled = false;
            }
        }

        private void cbPassShow_CheckedChanged(object sender, EventArgs e)
        {
            tbPassword.PasswordChar = tbPassword.PasswordChar == '*' ? '\0' : '*';
            tbConfirm.PasswordChar = tbConfirm.PasswordChar == '*' ? '\0' : '*';
        }

        private async Task<bool> Validate()
        {
            var users = await _users.Get<List<UserModel>>();

            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                err.SetError(tbName, "Required!");
                return false;
            }
            else
            {
                foreach (var item in users)
                    if (item.Name == tbName.Text && item.Id != _id)
                    {
                        err.SetError(tbName, "This username is already taken.");
                        return false;
                    }
            }

            if (string.IsNullOrWhiteSpace(tbLastname.Text))
            {
                err.SetError(tbLastname, "Required!");
                return false;
            }
            else err.Clear();

            if (string.IsNullOrWhiteSpace(tbUsername.Text))
            {
                err.SetError(tbUsername, "Required!");
                return false;
            }
            else
            {
                foreach (var item in users)
                    if (item.Username == tbUsername.Text && item.Id != _id)
                    {
                        err.SetError(tbUsername, "A user already registered with this username.");
                        return false;
                    }
            }

            if (string.IsNullOrWhiteSpace(tbEmail.Text))
            {
                err.SetError(tbEmail, "Required!");
                return false;
            }
            else if (!Regex.IsMatch(tbEmail.Text, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                err.SetError(tbEmail, "Wrong e-mail format!");
                return false;
            }
            else
            {
                foreach (var item in users)
                    if (item.Email == tbEmail.Text && item.Id != _id)
                    {
                        err.SetError(tbEmail, "A user already registered with this email.");
                        return false;
                    }
            }

            if (string.IsNullOrWhiteSpace(tbPhone.Text))
            {
                err.SetError(tbPhone, "Required!");
                return false;
            }
            else if (!Regex.IsMatch(tbPhone.Text, @"(?<cRegexGroupsName>\d{9})$"))
            {
                err.SetError(tbPhone, "Enter phone number in a 9 digit format.");
                return false;
            }
            else
            {
                foreach (var item in users)
                    if (item.Phone == tbPhone.Text && item.Id != _id)
                    {
                        err.SetError(tbPhone, "This phone number is already registered to a user.");
                        return false;
                    }
            }

            if (tbPassword.Enabled && string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                err.SetError(tbPassword, "Required!");
                return false;
            }
            else err.Clear();

            if (tbConfirm.Enabled && string.IsNullOrWhiteSpace(tbConfirm.Text))
            {
                err.SetError(tbConfirm, "Required!");
                return false;
            }
            else if (tbPassword.Text != tbConfirm.Text)
            {
                err.SetError(tbConfirm, "Password confirm doesn't match!");
                return false;
            }
            else err.Clear();

            if (string.IsNullOrWhiteSpace(cbRole.Text))
            {
                err.SetError(cbRole, "Required!");
                return false;
            }
            else err.Clear();

            return true;
        }
    }
}
