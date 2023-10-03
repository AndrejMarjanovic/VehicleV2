using Vehicle.FormUI.API;
using Vehicle.Model;

namespace Vehicle.FormUI.Forms
{
    public partial class frmSeatsAdd : Form
    {
        private readonly APIService _Seats = new APIService("Seats");
        private readonly APIService _SeatTypeColour = new APIService("SeatTypeColour");

        private int? _id = null;
        private DataGridView? _dgvSeats = null;
        public frmSeatsAdd(DataGridView? dgvSeats = null, int? id = null)
        {
            InitializeComponent();
            _dgvSeats = dgvSeats;
            _id = id;
        }

        private async void frmSeatsAdd_Load(object sender, EventArgs e)
        {
            await LoadSeatTypeColours();

            if (_id.HasValue) // Seats update
            {
                var seats = await _Seats.GetById<SeatsModel>(_id);
                tbNoOfSeats.Text = seats.NumberOfSeats.ToString();

                foreach (SeatTypeColourModel stc in cbSeats.Items)
                {
                    if (stc.Id == seats.SeatTypeColourId)
                        cbSeats.SelectedItem = stc;
                }
            }
        }

        private async Task LoadSeatTypeColours()
        {
            var result = await _SeatTypeColour.Get<List<SeatTypeColourModel>>();
            result.Insert(0, new SeatTypeColourModel());

            cbSeats.DisplayMember = "Id";
            cbSeats.ValueMember = "Id";
            cbSeats.DataSource = result;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                int stcID = (cbSeats.SelectedItem as SeatTypeColourModel).Id;

                SeatsPostModel request = new SeatsPostModel()
                {
                    NumberOfSeats = int.Parse(tbNoOfSeats.Text),
                    SeatTypeColourId = stcID

                };

                var seats = await _Seats.Get<List<SeatsModel>>();

                foreach (var s in seats)
                {
                    if (s.NumberOfSeats.ToString() == tbNoOfSeats.Text.ToLower() && s.SeatTypeColourId == stcID && s.Id != _id)
                    {
                        err.SetError(tbNoOfSeats, "There are already seats added with that material, colour and number combination.");
                        return;
                    }
                }

                if (_id.HasValue)
                {
                    await _Seats.Update<SeatsModel>(_id, request);

                }

                else
                {
                    await _Seats.Insert<SeatsModel>(request);
                }


                Close();
                if (_dgvSeats != null)
                    _dgvSeats.DataSource = await _Seats.Get<List<SeatsModel>>();
            }
        }

        private bool Validate()
        {

            if (string.IsNullOrEmpty(tbNoOfSeats.Text))
            {
                err.SetError(tbNoOfSeats, "Required!");
                return false;
            }
            else err.Clear();

            if (string.IsNullOrEmpty(cbSeats.Text))
            {
                err.SetError(cbSeats, "Required!");
                return false;
            }
            else err.Clear();


            return true;
        }

        private void cbSeats_Format(object sender, ListControlConvertEventArgs e)
        {
            var seatType = (e.ListItem as SeatTypeColourModel).SeatType;
            var colour = (e.ListItem as SeatTypeColourModel).Colour;
            e.Value = seatType + " - " + colour;
        }
    }
}
