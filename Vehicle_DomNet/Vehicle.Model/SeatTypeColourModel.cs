using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Model
{
    public class SeatTypeColourModel
    {
        public int Id { get; set; }
        public int SeatTypeId { get; set; }
        public virtual SeatTypeModel SeatType { get; set; }
        public int ColourId { get; set; }
        public virtual ColourModel Colour { get; set; }

        public override string ToString()
        {
            return $"{SeatType.Type} - {Colour.Name}";
        }
    }
}
