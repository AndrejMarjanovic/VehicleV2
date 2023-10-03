using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.DAL.Entities
{
    public class SeatTypeColour
    {
        public int Id { get; set; }
        public int SeatTypeId { get; set; }
        public virtual SeatType SeatType { get; set; }
        public int ColourId { get; set; }
        public virtual Colour Colour { get; set; }
    }
}
