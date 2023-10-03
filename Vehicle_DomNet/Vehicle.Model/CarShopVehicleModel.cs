using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Model
{
    public class CarShopVehicleModel
    {
        public int Id { get; set; }
        public int CarShopId { get; set; }
        public virtual CarShopModel CarShop { get; set; }
        public int VehicleId { get; set; }
        public virtual VehicleEntityModel Vehicle { get; set; }
    }
}
