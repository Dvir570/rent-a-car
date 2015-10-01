using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Models
{
    public class Rent
    {
        public Rent() { }

        public int RentId { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        public bool Paid { get; set; }
        public bool Billed { get; set; }

        // Foreign keys
        public int UserId { get; set; }
        public int CarId { get; set; }

        // Relations
        public virtual MyUser User { get; set; }
        public virtual Car Car { get; set; }
        public virtual Bill Bill { get; set; }
    }
}
