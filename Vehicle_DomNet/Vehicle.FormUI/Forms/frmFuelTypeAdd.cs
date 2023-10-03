using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vehicle.FormUI.API;
using Vehicle.Model;

namespace Vehicle.FormUI.Forms
{
    public partial class frmFuelTypeAdd : Form
    {
        private readonly APIService _fuelType = new APIService("FuelType");

        private int? _id = null;
        private DataGridView? _dgvFuels = null;
        public frmFuelTypeAdd(DataGridView? dgvFuels = null, int? id = null)
        {
            InitializeComponent();
            _dgvFuels = dgvFuels;
            _id = id;
        }

        private async void frmFuelTypeAdd_Load(object sender, EventArgs e)
        {

            if (_id.HasValue) // Fuel update
            {
                var fuel = await _fuelType.GetById<FuelTypeModel>(_id);
                tbFuel.Text = fuel.Type;
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                FuelTypePostModel request = new FuelTypePostModel()
                {
                    Type = tbFuel.Text
                };

                var fuels = await _fuelType.Get<List<FuelTypeModel>>();


                if (_id.HasValue)
                {
                    await _fuelType.Update<FuelTypeModel>(_id, request);

                }
                else
                {
                    await _fuelType.Insert<FuelTypeModel>(request);
                }


                Close();
                if (_dgvFuels != null)
                    _dgvFuels.DataSource = await _fuelType.Get<List<FuelTypeModel>>();
            }
        }

        private bool Validate()
        {

            if (string.IsNullOrEmpty(tbFuel.Text))
            {
                err.SetError(tbFuel, "Required!");
                return false;
            }
            else err.Clear();

            return true;
        }

    }
}
