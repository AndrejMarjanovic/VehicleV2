using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Model;

namespace Vehicle.Model.Common
{
    public interface IEngineModel
    {
        public int Id { get; set; }
        public double Cubage { get; set; }
        public int Horsepower { get; set; }
        public int FuelTypeId { get; set; }
        public bool IsHybrid { get; set; }
        public string EmissionStandard { get; set; }
    }
}
