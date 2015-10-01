using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        // Foreign keys
        public int UserId { get; set; }
        public int CarId { get; set; }

        // Relationships
        public virtual Car Car { get; set; }
        public virtual MyUser User { get; set; }
    }
}
