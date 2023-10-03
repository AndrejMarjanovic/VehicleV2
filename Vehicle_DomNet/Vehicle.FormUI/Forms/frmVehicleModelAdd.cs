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
    public partial class frmVehicleModelAdd : Form
    {
        private readonly APIService _vehicleMakes = new APIService("VehicleMake");
        private readonly APIService _vehicleModels = new APIService("VehicleModel");

        private int? _id = null;
        private DataGridView? _dgvModels = null;
        public frmVehicleModelAdd(DataGridView? dgvModels = null, int? id = null)
        {
            InitializeComponent();
            _dgvModels = dgvModels;
            _id = id;
        }

        private async void frmVehicleModelAdd_Load(object sender, EventArgs e)
        {
            LoadVehicleMakes();

            if (_id.HasValue) // Vehicle Model update
            {
                var model = await _vehicleModels.GetById<VehicleModelModel>(_id);
                tbName.Text = model.Name;
                tbAbrv.Text = model.Abrv;

                foreach (VehicleMakeModel make in cbMakes.Items)
                {
                    if (make.Id == model.VehicleMakeId)
                        cbMakes.SelectedItem = make;
                }
            }
        }

        private async Task LoadVehicleMakes()
        {
            var result = await _vehicleMakes.Get<List<VehicleMakeModel>>();
            result.Insert(0, new VehicleMakeModel());
            cbMakes.DisplayMember = "Name";
            cbMakes.ValueMember = "Id";
            cbMakes.DataSource = result;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                int makeID = (cbMakes.SelectedItem as VehicleMakeModel).Id;

                VehicleModelPostModel request = new VehicleModelPostModel()
                {
                    Name = tbName.Text,
                    Abrv = tbAbrv.Text,
                    VehicleMakeId = makeID

                };

                var models = await _vehicleModels.Get<List<VehicleModelModel>>();

                foreach (var m in models)
                {
                    if (m.Name.ToLower() == tbName.Text.ToLower() && m.VehicleMakeId == makeID && m.Id != _id)
                    {
                        err.SetError(tbName, "Model with that name already exists in " + m.VehicleMake.Name + ".");
                        return;
                    }
                }

                if (_id.HasValue)
                {
                    await _vehicleModels.Update<VehicleModelModel>(_id, request);

                }

                else
                {
                    await _vehicleModels.Insert<VehicleModelModel>(request);
                }


                Close();
                if (_dgvModels != null)
                    _dgvModels.DataSource = await _vehicleModels.Get<List<VehicleModelModel>>();
            }
        }

        private bool Validate()
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                err.SetError(tbName, "Required!");
                return false;
            }
            else err.Clear();

            if (string.IsNullOrEmpty(tbAbrv.Text))
            {
                err.SetError(tbAbrv, "Required!");
                return false;
            }
            else err.Clear();

            if (string.IsNullOrEmpty(cbMakes.Text))
            {
                err.SetError(cbMakes, "Required!");
                return false;
            }
            else err.Clear();


            return true;
        }
    }
}
