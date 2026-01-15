using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

namespace GaraApp.Entities
{
    public class RepairOrder
    {
        public int RepairOrderId { get; set; }  // PK
        public int CarId { get; set; }          // FK
        public virtual Car? Car { get; set; }

        public DateTime ReceiveDate { get; set; } = DateTime.Now;
        public string Symptom { get; set; } = "";
        public int Odometer { get; set; }
        public string Status { get; set; } = "OPEN"; // OPEN / PAID / CANCELED

        public decimal TotalAmount { get; set; }

        public virtual ICollection<RepairServiceDetail> ServiceDetails { get; set; } = new HashSet<RepairServiceDetail>();
        public virtual ICollection<RepairPartDetail> PartDetails { get; set; } = new HashSet<RepairPartDetail>();
    }
}

