using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.DAL;

namespace Vehicle.DAL.Entities
{
    public class Seats
    {
        public int Id { get; set; }
        public int NumberOfSeats { get; set; }
        public int SeatTypeColourId { get; set; }
        public virtual SeatTypeColour SeatTypeColour { get; set; }
    }
}
