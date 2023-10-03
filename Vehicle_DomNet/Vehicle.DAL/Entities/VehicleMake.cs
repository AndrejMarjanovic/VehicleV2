using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.DAL.Entities;

namespace Vehicle.DAL
{
    public class VehicleMake
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Abrv { get; set; } 
        public int CountryId { get; set; }
        public Country Country { get; set; }

    }
}
