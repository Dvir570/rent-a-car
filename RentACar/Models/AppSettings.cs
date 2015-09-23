using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Models
{
    public class AppSettings
    {
        public int AppSettingsId { get; set; }

        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        public string EmailUsername { get; set; }

        [DataType(DataType.Password)]
        public string EmailPassword { get; set; }
    }
}
