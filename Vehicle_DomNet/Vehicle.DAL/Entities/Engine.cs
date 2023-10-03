using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.DAL.Entities
{
    public class Engine
    {
        public int Id { get; set; } 
        public double Cubage { get; set; }
        public int Horsepower { get; set; }
        public int FuelTypeId { get; set; }
        public virtual FuelType FuelType { get; set; }
        public bool IsHybrid { get; set; }
        public string EmissionStandard { get; set; }
    }
}
