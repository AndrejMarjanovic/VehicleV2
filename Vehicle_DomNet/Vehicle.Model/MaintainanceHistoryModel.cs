using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Model
{
    public class MaintainanceHistoryModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string MaintainanceInfo { get; set; }
        public int VehicleId { get; set; }
        public VehicleEntityModel Vehicle { get; set; }
    }
}
