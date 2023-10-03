using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.DAL.Entities
{
    public class CarShopVehicle
    {
        public int Id { get; set; }
        public int CarShopId { get; set; }
        public virtual CarShop CarShop { get; set; }
        public int VehicleId { get; set; }
        public virtual VehicleEntity Vehicle { get; set; }
    }
}
