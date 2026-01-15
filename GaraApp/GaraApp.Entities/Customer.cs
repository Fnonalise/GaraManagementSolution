using System.Collections.Generic;

namespace GaraApp.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }     // PK
        public string FullName { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Address { get; set; } = "";

        public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }
}
