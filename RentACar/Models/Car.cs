using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Models
{
    public class Car
    {
        public Car() { }

        public int CarId { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string ImageUrl { get; set; }

        public double CostPerDay { get; set; }

        public int NumberTotal { get; set; }
        public int NumberReserved { get; set; }
        public int NumberInUse { get; set; }

        // Foreign keys
        public int CarTypeId { get; set; }
        public int BrandId { get; set; }

        // Relations
        public virtual CarType Type { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual IEnumerable<Rent> Rents { get; set; }

        public bool ReserveCar()
        {
            if(this.NumberTotal - this.NumberReserved - this.NumberInUse > 0)
            {
                this.NumberReserved++;
                return true;
            }
            return false;
        }

        public bool GetCar()
        {
            if(this.NumberTotal - this.NumberReserved - this.NumberInUse > 0)
            {
                this.NumberInUse++;
                return true;
            }
            return false;
        }

        public bool GetReservedCar()
        {
            if(this.NumberReserved > 0)
            {
                this.NumberReserved--;
                this.NumberInUse++;
                return true;
            }
            return false;
        }

        public bool ReturnCar()
        {
            if(this.NumberInUse > 0)
            {
                this.NumberInUse--;
                return true;
            }
            return false;
        }
    }
}
