
using Vehicle.Model;

namespace Vehicle.WebAPI.Models
{
    public class VehicleEntityGetModel
    { 
        public int Id { get; set; }
        public int VehicleModelId { get; set; }
        public virtual VehicleModelGetModel VehicleModel { get; set; }
        public int vehicleTypeId { get; set; }
        public VehicleTypeGetModel VehicleType { get; set; }
        public int EngineId { get; set; }
        public virtual EngineGetModel Engine { get; set; }
        public int SeatsId { get; set; }
        public virtual SeatsGetModel Seats { get; set; }
        public int ColourId { get; set; }      
        public virtual ColourGetModel Colour { get; set; }
        public int TransmissionId { get; set; }
        public virtual TransmissionGetModel Transmission { get; set; }
        public int ProductionYear { get; set; }
        public int Mileage { get; set; }
        public byte[]? Image { get; set; }
        public double Price { get; set; }
    }
}
