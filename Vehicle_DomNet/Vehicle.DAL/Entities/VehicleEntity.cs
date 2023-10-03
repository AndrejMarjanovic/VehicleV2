using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Vehicle.DAL.Entities
{
    public class VehicleEntity
    {
        public int Id { get; set; }
        public int VehicleModelId { get; set; }
        public virtual VehicleModel VehicleModel { get; set; }
        public int VehicleTypeId { get; set; }
        public virtual VehicleType VehicleType { get; set; }
        public int EngineId { get; set; }
        public virtual Engine Engine { get; set; }    
        public int SeatsId { get; set; }
        public virtual Seats Seats { get; set; }
        public int ColourId { get; set; }
        public virtual Colour Colour { get; set; }
        public int TransmissionId { get; set; }
        public virtual Transmission Transmission { get; set; }
        public int ProductionYear { get; set; }
        public int Mileage { get; set; }
        public byte[]? Image { get; set; }
        public double Price { get; set; }
    }
}
