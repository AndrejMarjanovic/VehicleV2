using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.DAL.Entities
{
    public class Contract
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int CarShopVehicleId { get; set; }
        public virtual CarShopVehicle CarShopVehicle { get; set; }

    }
}
