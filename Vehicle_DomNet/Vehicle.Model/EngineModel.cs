using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Model.Common;

namespace Vehicle.Model
{
    public class EngineModel : IEngineModel
    {
        public int Id { get; set; } 
        public double Cubage { get; set; }
        public int Horsepower { get; set; }
        public int FuelTypeId { get; set; }
        public virtual FuelTypeModel FuelType { get; set; }
        public bool IsHybrid { get; set; }
        public string EmissionStandard { get; set; }

        public override string ToString()
        {
            return $"{Cubage.ToString("0.0")} - {Horsepower} hp";
        }
    }
}
