using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vehicle.FormUI.Forms
{
    public partial class mdiMain : Form
    {
        private int childFormNumber = 0;

        public mdiMain()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void vehiclesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVehicle frm = new frmVehicle();
            frm.MdiParent = this;
            frm.Show();
        }

        private void vehicleModelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVehicleModel frm = new frmVehicleModel();
            frm.MdiParent = this;
            frm.Show();
        }

        private void enginesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEngine frm = new frmEngine();
            frm.MdiParent = this;
            frm.Show();
        }

        private void fuelTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFuelType frm = new frmFuelType();
            frm.MdiParent = this;
            frm.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            Close();
            frm.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUser frm = new frmUser();
            frm.MdiParent = this;
            frm.Show();
        }

        private void seatTypeColoursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSeatTypeColour frm = new frmSeatTypeColour();
            frm.MdiParent = this;
            frm.Show();
        }

        private void seatsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSeats frm = new frmSeats();
            frm.MdiParent = this;
            frm.Show();
        }

        private void seatTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSeatType frm = new frmSeatType();
            frm.MdiParent = this;
            frm.Show();
        }

        private void colourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmColour frm = new frmColour();
            frm.MdiParent = this;
            frm.Show();
        }

        private void chatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChat frm = new frmChat();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
