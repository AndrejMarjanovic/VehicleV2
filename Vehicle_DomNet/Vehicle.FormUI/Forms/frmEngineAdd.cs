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
using System.Xml.Linq;
using Vehicle.FormUI.API;
using Vehicle.Model;

namespace Vehicle.FormUI.Forms
{
    public partial class frmEngineAdd : Form
    {
        private readonly APIService _engines = new APIService("Engine");
        private readonly APIService _fuelTypes = new APIService("FuelType");

        private int? _id = null;
        private DataGridView? _dgvEngines = null;
        public frmEngineAdd(DataGridView? dgvEngines = null, int? id = null)
        {
            InitializeComponent();
            _dgvEngines = dgvEngines;
            _id = id;
        }

        private async void frmEngineAdd_Load(object sender, EventArgs e)
        {
            LoadFuelTypes();

            if (_id.HasValue) // Engine update
            {
                var engine = await _engines.GetById<EngineModel>(_id);
                tbCubage.Text = engine.Cubage.ToString();
                tbHp.Text = engine.Horsepower.ToString();
                tbEmission.Text = engine.EmissionStandard;
                cbIsHybrid.Checked = engine.IsHybrid;

                foreach (FuelTypeModel fuelType in cbFuelType.Items)
                {
                    if (fuelType.Id == engine.FuelTypeId)
                        cbFuelType.SelectedItem = fuelType;
                }
            }
        }

        private async Task LoadFuelTypes()
        {
            var result = await _fuelTypes.Get<List<FuelTypeModel>>();
            result.Insert(0, new FuelTypeModel());
            cbFuelType.DisplayMember = "Type";
            cbFuelType.ValueMember = "Id";
            cbFuelType.DataSource = result;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                int fuelTypeID = (cbFuelType.SelectedItem as FuelTypeModel).Id;

                EnginePostModel request = new EnginePostModel()
                {
                    Cubage = Double.Parse(tbCubage.Text),
                    Horsepower = int.Parse(tbHp.Text),
                    EmissionStandard = tbEmission.Text,
                    IsHybrid = cbIsHybrid.Checked,
                    FuelTypeId = fuelTypeID

                };

                var engines = await _engines.Get<List<EngineModel>>();

                foreach (var engine in engines)
                {
                    if (engine.Cubage.ToString() == tbCubage.Text && engine.Horsepower.ToString() == tbHp.Text
                        && engine.EmissionStandard.ToLower() == tbEmission.Text.ToLower() && engine.IsHybrid == cbIsHybrid.Checked
                        && engine.FuelTypeId == fuelTypeID && engine.Id != _id
                        )
                    {
                        err.SetError(tbCubage, "An identical engine already exists.");
                        return;
                    }
                }

                if (_id.HasValue)
                {
                    await _engines.Update<EngineModel>(_id, request);

                }
                else
                {
                    await _engines.Insert<EngineModel>(request);
                }


                Close();
                if (_dgvEngines != null)
                    _dgvEngines.DataSource = await _engines.Get<List<EngineModel>>();
            }
        }

        private bool Validate()
        {

            if (string.IsNullOrEmpty(tbCubage.Text))
            {
                err.SetError(tbCubage, "Required!");
                return false;
            }
            else err.Clear();
            double dbl;
            if (double.TryParse(tbCubage.Text, out dbl))
            {
                double.Parse(tbCubage.Text);
            }
            else
            {
                err.SetError(tbCubage, "Double value required!");
                return false;
            }

            if (string.IsNullOrEmpty(tbHp.Text))
            {
                err.SetError(tbHp, "Required!");
                return false;
            }
            else err.Clear();
            int i;
            if (int.TryParse(tbHp.Text, out i))
            {
                int.Parse(tbHp.Text);
            }
            else
            {
                err.SetError(tbHp, "Intiger value required!");
                return false;
            }

            if (string.IsNullOrEmpty(cbFuelType.Text))
            {
                err.SetError(cbFuelType, "Required!");
                return false;
            }
            else err.Clear();

            if (string.IsNullOrEmpty(tbEmission.Text))
            {
                err.SetError(tbEmission, "Required!");
                return false;
            }

            return true;
        }

    }
}
