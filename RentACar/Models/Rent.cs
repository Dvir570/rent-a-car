using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Models
{
    public class Rent
    {
        public Rent() { }

        public int RentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Paid { get; set; }

        // Foreign keys
        public int UserId { get; set; }
        public int CarId { get; set; }

        // Relations
        public virtual MyUser User { get; set; }
        public virtual Car Cars { get; set; }
        public virtual Bill Bill { get; set; }
    }
}
