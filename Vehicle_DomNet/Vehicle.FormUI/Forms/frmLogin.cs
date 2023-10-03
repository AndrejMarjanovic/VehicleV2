using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vehicle.FormUI.API;
using Vehicle.Model;

namespace Vehicle.FormUI.Forms
{
    public partial class frmLogin : Form
    {
        private readonly APIService _users = new APIService("User");
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                APIService.Username = tbUsername.Text;
                APIService.Password = tbPassword.Text;

                try
                {
                    List<UserModel> userList = await _users.Get<List<UserModel>>();

                    APIService.LoggedUser = userList.Where(x => x.Username == APIService.Username).FirstOrDefault();

                    if (APIService.LoggedUser != null)
                    {
                        if (APIService.LoggedUser.Role.Name == "Admin")
                        {
                            await _users.Get<List<UserModel>>();
                            mdiMain frm = new mdiMain();
                            DialogResult = DialogResult.OK;
                            frm.Show();
                            Hide();
                        }
                    }
                }
                catch
                {
                    tbPassword.Text = string.Empty;
                    tbUsername.Text = string.Empty;
                }

            }
        }

        private bool Validate()
        {
            if (string.IsNullOrEmpty(tbUsername.Text))
            {
                err.SetError(tbUsername, "Enter username!");
                return false;
            }
            else err.Clear();
            if (string.IsNullOrEmpty(tbPassword.Text))
            {
                err.SetError(tbPassword, "Enter password!");
                return false;
            }
            else err.Clear();



            return true;
        }

        private void cbShowPass_CheckedChanged(object sender, EventArgs e)
        {
            tbPassword.PasswordChar = tbPassword.PasswordChar == '*' ? '\0' : '*';

        }

        private void tbUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin.PerformClick();
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin.PerformClick();
        }
    }
}
