
namespace Vehicle.WebAPI.Models
{
    public class EnginePostModel
    {
        public double Cubage { get; set; }
        public int Horsepower { get; set; }
        public int FuelTypeId { get; set; }
        public bool IsHybrid { get; set; }
        public string EmissionStandard { get; set; }
    }
}
