using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public DateTime Date { get; set; }

        // Foreign keys
        public int? UserId { get; set; }
        public int CarId { get; set; }

        // Relationships
        public virtual Car Car { get; set; }
        public virtual MyUser User { get; set; }

        public Reservation() { }
    }
}
