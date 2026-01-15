using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaraApp.Entities
{
    public class Car
    {
        public int CarId { get; set; }          // PK
        public string LicensePlate { get; set; } = ""; // Unique
        public string Brand { get; set; } = "";
        public string Model { get; set; } = "";
        public int Year { get; set; }

        public int CustomerId { get; set; }     // FK
        public virtual Customer? Customer { get; set; }
    }
}
