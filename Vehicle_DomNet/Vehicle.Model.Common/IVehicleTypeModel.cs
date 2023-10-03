using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Model.Common
{
    public interface IVehicleTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
