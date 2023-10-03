
namespace Vehicle.WebAPI.Models
{
    public class EngineGetModel
    {
        public int Id { get; set; } 
        public double Cubage { get; set; }
        public int Horsepower { get; set; }
        public int FuelTypeId { get; set; }
        public virtual FuelTypeGetModel FuelType { get; set; }
        public bool IsHybrid { get; set; }
        public string EmissionStandard { get; set; }
    }
}
