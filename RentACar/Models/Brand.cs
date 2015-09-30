using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Models
{
    public class Brand
    {
        [Required]
        public int BrandId { get; set; }

        [Required]
        [Display(Name = "Brand")]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual IEnumerable<Car> Cars { get; set; }

        public Brand() { }
    }
}
