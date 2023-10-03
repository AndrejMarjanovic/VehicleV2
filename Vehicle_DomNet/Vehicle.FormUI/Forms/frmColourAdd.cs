using Vehicle.FormUI.API;
using Vehicle.Model;

namespace Vehicle.FormUI.Forms
{
    public partial class frmColourAdd : Form
    {
        private readonly APIService _Colour = new APIService("Colour");

        private int? _id = null;
        private DataGridView? _dgvColours = null;
        public frmColourAdd(DataGridView? dgvColours = null, int? id = null)
        {
            InitializeComponent();
            _dgvColours = dgvColours;
            _id = id;
        }

        private async void frmColourAdd_Load(object sender, EventArgs e)
        {
            if (_id.HasValue) // Colour update
            {
                var colour = await _Colour.GetById<ColourModel>(_id);
                tbColour.Text = colour.Name;
                tbColourCode.Text = colour.ColourCode;
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                ColourPostModel request = new ColourPostModel()
                {
                    Name = tbColour.Text,
                    ColourCode = tbColourCode.Text
                };

                var colours = await _Colour.Get<List<ColourModel>>();

                foreach (var c in colours)
                {
                    if (c.Name.ToLower() == tbColour.Text.ToLower()  && c.Id != _id)
                    {
                        err.SetError(tbColour, "This colour is already added.");
                        return;
                    }
                    else if (c.ColourCode.ToLower() == tbColourCode.Text.ToLower() && c.Id != _id)
                    {
                        err.SetError(tbColourCode, "This colour code is already added.");
                        return;
                    }
                }

                if (_id.HasValue)
                {
                    await _Colour.Update<ColourModel>(_id, request);

                }

                else
                {
                    await _Colour.Insert<ColourModel>(request);
                }


                Close();
                if (_dgvColours != null)
                    _dgvColours.DataSource = await _Colour.Get<List<ColourModel>>();
            }
        }

        private bool Validate()
        {

            if (string.IsNullOrEmpty(tbColour.Text))
            {
                err.SetError(tbColour, "Required!");
                return false;
            }
            else err.Clear();

            if (string.IsNullOrEmpty(tbColourCode.Text))
            {
                err.SetError(tbColourCode, "Required!");
                return false;
            }
            else err.Clear();

            return true;
        }
    }
}
