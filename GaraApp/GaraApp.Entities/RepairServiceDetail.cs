using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaraApp.Entities
{
    public class RepairServiceDetail
    {
        public int RepairServiceDetailId { get; set; }

        public int RepairOrderId { get; set; }
        public virtual RepairOrder? RepairOrder { get; set; }

        public int ServiceId { get; set; }
        public virtual Service? Service { get; set; }

        public int Qty { get; set; } = 1;
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
    }
}

