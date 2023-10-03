using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Model
{
    public class SeatsModel
    {
        public int Id { get; set; }
        public int NumberOfSeats { get; set; }
        public int SeatTypeColourId { get; set; }
        public virtual SeatTypeColourModel SeatTypeColour { get; set; }

        public override string ToString()
        {
            return $"{SeatTypeColour} - {NumberOfSeats}";
        }
    }
}
