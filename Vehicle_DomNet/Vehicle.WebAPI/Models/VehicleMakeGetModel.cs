
namespace Vehicle.WebAPI.Models
{
    public class VehicleMakeGetModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public int CountryId { get; set; }
        //public virtual CountryGetModel Country { get; set; }
    }
}
