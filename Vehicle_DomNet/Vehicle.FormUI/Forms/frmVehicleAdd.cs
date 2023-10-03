using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vehicle.FormUI.API;

namespace Vehicle.FormUI.Forms
{
    public partial class frmVehicleAdd : Form
    {
        private readonly APIService _vehicles = new APIService("Vehicle");

        private int? _id = null;
        private DataGridView? _dgvVehicles = null;
        public frmVehicleAdd(DataGridView? dgvVehicles = null, int? id = null)
        {
            InitializeComponent();
            _dgvVehicles = dgvVehicles;
            _id = id;
        }
    }
}
