using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Model
{
    public class CarShopModel
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int CountryId { get; set; }
        public virtual CountryModel Country { get; set; }
        public string Adress { get; set; }

    }
}
