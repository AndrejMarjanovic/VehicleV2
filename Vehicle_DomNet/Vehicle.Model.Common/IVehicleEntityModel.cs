using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Model.Common
{
    public interface IVehicleEntityModel
    {
        public int Id { get; set; }
        public int ProductionYear { get; set; }
        public int Mileage { get; set; }
    }
}
