﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Model
{
    public class FuelTypeModel
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return $"{Type}";

        }
    }
}
