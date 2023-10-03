﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Model.Common;

namespace Vehicle.Model
{
    public class VehicleMakeModel : IVehicleMakeModel
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Abrv { get; set; }
        public int CountryId { get; set; }
        public virtual CountryModel Country { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }

    }
}
