using Vehicle.FormUI.API;
using Vehicle.Model;

namespace Vehicle.FormUI.Forms
{
    public partial class frmSeatTypeColourAdd : Form
    {
        private readonly APIService _SeatTypeColour = new APIService("SeatTypeColour");
        private readonly APIService _SeatType = new APIService("SeatType");
        private readonly APIService _Colour = new APIService("Colour");

        private int? _id = null;
        private DataGridView? _dgvSeatTypeColour = null;
        public frmSeatTypeColourAdd(DataGridView? dgvSeatTypeColour = null, int? id = null)
        {
            InitializeComponent();
            _dgvSeatTypeColour = dgvSeatTypeColour;
            _id = id;
        }

        private async void frmSeatTypeColourAdd_Load(object sender, EventArgs e)
        {
            await LoadSeatTypes();
            await LoadColours();

            if (_id.HasValue) // Seats type colour update
            {
                var stColour = await _SeatTypeColour.GetById<SeatTypeColourModel>(_id);

                foreach (SeatTypeModel seatType in cbSeatTypes.Items)
                {
                    if (seatType.Id == stColour.SeatTypeId)
                        cbSeatTypes.SelectedItem = seatType;
                }

                foreach (ColourModel colour in cbColours.Items)
                {
                    if (colour.Id == stColour.ColourId)
                        cbColours.SelectedItem = colour;
                }
            }
        }

        private async Task LoadSeatTypes()
        {
            var result = await _SeatType.Get<List<SeatTypeModel>>();
            result.Insert(0, new SeatTypeModel());

            cbSeatTypes.DisplayMember = "Type";
            cbSeatTypes.ValueMember = "Id";
            cbSeatTypes.DataSource = result;
        }

        private async Task LoadColours()
        {
            var result = await _Colour.Get<List<ColourModel>>();
            result.Insert(0, new ColourModel());

            cbColours.DisplayMember = "Name";
            cbColours.ValueMember = "Id";
            cbColours.DataSource = result;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                int seatTypeId = (cbSeatTypes.SelectedItem as SeatTypeModel).Id;
                int colourId = (cbColours.SelectedItem as ColourModel).Id;

                SeatTypeColourPostModel request = new SeatTypeColourPostModel()
                {
                    ColourId = colourId,
                    SeatTypeId = seatTypeId
                };

                var seatTypeColours = await _SeatTypeColour.Get<List<SeatTypeColourModel>>();

                foreach (var stc in seatTypeColours)
                {
                    if (stc.ColourId == colourId && stc.SeatTypeId == seatTypeId && stc.Id != _id)
                    {
                        err.SetError(cbColours, "This seat type is already added in " + stc.Colour.Name.ToLower() + ".");
                        return;
                    }
                }

                if (_id.HasValue)
                {
                    await _SeatTypeColour.Update<SeatTypeColourModel>(_id, request);

                }

                else
                {
                    await _SeatTypeColour.Insert<SeatTypeColourModel>(request);
                }


                Close();
                if (_dgvSeatTypeColour != null)
                    _dgvSeatTypeColour.DataSource = await _SeatTypeColour.Get<List<SeatTypeColourModel>>();
            }
        }

        private bool Validate()
        {

            if (string.IsNullOrEmpty(cbColours.Text))
            {
                err.SetError(cbColours, "Required!");
                return false;
            }
            else err.Clear();

            if (string.IsNullOrEmpty(cbSeatTypes.Text))
            {
                err.SetError(cbSeatTypes, "Required!");
                return false;
            }
            else err.Clear();


            return true;
        }
    }
}
