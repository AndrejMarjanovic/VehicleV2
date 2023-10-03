using Vehicle.FormUI.API;
using Vehicle.Model;

namespace Vehicle.FormUI.Forms
{
    public partial class frmSeatTypeAdd : Form
    {
        private readonly APIService _SeatType = new APIService("SeatType");

        private int? _id = null;
        private DataGridView? _dgvSeatType = null;
        public frmSeatTypeAdd(DataGridView? dgvSeatType = null, int? id = null)
        {
            InitializeComponent();
            _dgvSeatType = dgvSeatType;
            _id = id;
        }

        private async void frmSeatTypeAdd_Load(object sender, EventArgs e)
        {
            if (_id.HasValue) // Seats update
            {
                var seatType = await _SeatType.GetById<SeatTypeModel>(_id);
                tbSeatType.Text = seatType.Type;
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                SeatTypePostModel request = new SeatTypePostModel()
                {
                    Type = tbSeatType.Text,
                };

                var seatTypes = await _SeatType.Get<List<SeatTypeModel>>();

                foreach (var s in seatTypes)
                {
                    if (s.Type.ToLower() == tbSeatType.Text.ToLower() && s.Id != _id)
                    {
                        err.SetError(tbSeatType, "Seat material of this type is already added.");
                        return;
                    }
                }

                if (_id.HasValue)
                {
                    await _SeatType.Update<SeatTypeModel>(_id, request);

                }

                else
                {
                    await _SeatType.Insert<SeatTypeModel>(request);
                }


                Close();
                if (_dgvSeatType != null)
                    _dgvSeatType.DataSource = await _SeatType.Get<List<SeatTypeModel>>();
            }
        }

        private bool Validate()
        {

            if (string.IsNullOrEmpty(tbSeatType.Text))
            {
                err.SetError(tbSeatType, "Required!");
                return false;
            }
            else err.Clear();

            return true;
        }
    }
}
