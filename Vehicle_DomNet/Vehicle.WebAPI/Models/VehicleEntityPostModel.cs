
using Vehicle.Model;

namespace Vehicle.WebAPI.Models
{
    public class VehicleEntityPostModel
    { 
        public int VehicleModelId { get; set; }
        public int VehicleTypeId { get; set; }
        public int EngineId { get; set; }
        public int SeatsId { get; set; }
        public int ColourId { get; set; }
        public int TransmissionId { get; set; }
        public int ProductionYear { get; set; }
        public int Mileage { get; set; }
        public byte[] Image { get; set; }
        public double Price { get; set; }
    }
}
