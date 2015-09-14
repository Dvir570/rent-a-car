using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Models
{
    public class Bill
    {
        public Bill() { }

        [Key, ForeignKey("Rent")]
        public int RentId { get; set; }
        public DateTime Date { get; set; }
        public double Cost { get; set; }

        public virtual Rent Rent { get; set; }

        public void CalculateTotalCost(int days, double costPerDay)
        {
            this.Cost = days * costPerDay;
        }
    }
}
