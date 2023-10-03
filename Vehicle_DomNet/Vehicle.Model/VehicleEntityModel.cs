using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Model.Common;

namespace Vehicle.Model
{
    public class VehicleEntityModel : IVehicleEntityModel
    {
        public int Id { get; set; }
        public int VehicleModelId { get; set; }
        public virtual VehicleModelModel VehicleModel { get; set; }
        public int VehicleTypeId { get; set; }
        public virtual VehicleTypeModel VehicleType { get; set; }
        public int EngineId { get; set; }
        public virtual EngineModel Engine { get; set; }
        public int SeatsId { get; set; }
        public virtual SeatsModel Seats { get; set; }
        public int ColourId { get; set; }
        public virtual ColourModel Colour { get; set; }
        public int TransmissionId { get; set; }
        public virtual TransmissionModel Transmission { get; set; }
        public int ProductionYear { get; set; }
        public int Mileage { get; set; }
        public byte[] Image { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"{VehicleModel.VehicleMake} {VehicleModel} {VehicleType} {Engine.Horsepower}";
        }
    }
}
