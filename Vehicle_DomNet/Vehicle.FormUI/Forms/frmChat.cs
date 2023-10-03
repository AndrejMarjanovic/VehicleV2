using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.VisualBasic.ApplicationServices;
using System.Globalization;
using System.Windows.Forms;
using Vehicle.FormUI.API;

namespace Vehicle.FormUI.Forms
{
    public partial class frmChat : Form
    {
        HubConnection hubConnection;
        private delegate void SafeCallDelegate(string text);
        private IDisposable hubDisposable;
        public frmChat()
        {
            InitializeComponent();
            hubConnection = new HubConnectionBuilder()
                .WithUrl($"{Properties.Settings.Default.ChatHubURL}")
                .Build();
            hubConnection.Closed += HubConnection_Closed;
        }

        private async Task HubConnection_Closed(Exception? arg)
        {
            await Task.Delay(new Random().Next(0, 5) * 1000);
            await hubConnection.StartAsync();
        }

        private async void frmChat_Load(object sender, EventArgs e)
        {
            lblUser.Text = APIService.Username;
            DateTimeTimer.Start();

            LoadMessages();
            LoadLoggedInUsers();

            try
            {
                await hubConnection.StartAsync();
                await hubConnection.InvokeAsync("UserLoggedIn", APIService.Username);
                lblStatus.ForeColor = Color.LightGreen;
                lblStatus.Text = "You are online.";
            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = ex.Message;
                btnSend.Enabled = false;
            }
        }

        private void LoadMessages()
        {
            hubDisposable = hubConnection.On<string, string>("ReceiveMessage", async (user, message) =>
            {
                var newMessage = $"{user}: {message}";

                if (user != APIService.Username)
                {
                    lbChat.BeginInvoke(() =>
                    {
                        if (CheckLastItem(user))
                        {
                            lbChat.Items.AddRange(new object[] { $"     {message}" });
                        }
                        else
                        {
                            lbChat.Items.AddRange(new object[] { "", $" ◦ {user}, {DateTime.Now.ToString("H:mm tt", CultureInfo.InvariantCulture)}", $"     {message}" });
                        }

                        AutoScrollChat();
                    });
                }
                else
                {
                    lbChat.BeginInvoke(() =>
                    {
                        if (CheckLastItem(user))
                        {
                            lbChat.Items.AddRange(new object[] { $"     {message}" });
                        }
                        else
                        {
                            lbChat.Items.AddRange(new object[] { "", $" • {user}, {DateTime.Now.ToString("H:mm tt", CultureInfo.InvariantCulture)}", $"     {message}" });
                        }

                        AutoScrollChat();
                    });
                }
            });
        }

        private void LoadLoggedInUsers()
        {
            hubDisposable = hubConnection.On<List<string>>("UpdateActiveUsers", async activeUsers =>
            {
                lbUsers.BeginInvoke(() =>
                {
                    if (!lbUsers.IsDisposed)
                    {
                        lbUsers.Items.Clear();
                        lbUsers.Items.AddRange(activeUsers.ToArray());
                    }
                });
            });
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tbMessage.Text))
                {
                    await hubConnection.InvokeAsync("SendMessage", lblUser.Text, tbMessage.Text);
                    tbMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lbChat.Items.Add(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lbChat.Items.Clear();
        }

        private async void frmChat_FormClosed(object sender, FormClosedEventArgs e)
        {
            await  hubConnection.InvokeAsync("UserLoggedOut", APIService.Username);
            hubDisposable.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            this.lblDateTime.Text = datetime.ToString("dddd, dd MMMM yyyy HH:mm:ss tt", CultureInfo.InvariantCulture);
        }

        private void tbMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSend.PerformClick();
        }

        private void AutoScrollChat()
        {
            int nItems = (int)(lbChat.Height / lbChat.ItemHeight);
            lbChat.TopIndex = lbChat.Items.Count - nItems;
        }

        private bool CheckLastItem(string user)
        {
            if (lbChat.Items.Count != 0)
            {
                lbChat.SelectedIndex = lbChat.Items.Count - 1;
                do
                {
                    lbChat.SelectedIndex -= 1;

                } while (lbChat.SelectedItem.ToString().StartsWith("     "));

                if (lbChat.SelectedItem.ToString().Contains(user))
                {
                    lbChat.SelectedItem = null;
                    return true;
                }

            }

            lbChat.SelectedItem = null;
            return false;
        }
    }
}
