using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Models
{
    public class Brand
    {
        public Brand() { }

        public int BrandId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual IEnumerable<Car> Cars { get; set; }
    }
}
