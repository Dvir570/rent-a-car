using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Models
{
    public class CarType
    {
        public CarType() { }

        public int CarTypeId { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<Car> Cars { get; set; }
    }
}
