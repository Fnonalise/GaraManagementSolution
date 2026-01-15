using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaraApp.Entities
{
    public class Part
    {
        public int PartId { get; set; }         // PK
        public string PartName { get; set; } = "";
        public string Unit { get; set; } = "pcs";
        public decimal UnitPrice { get; set; }
        public int StockQty { get; set; }
        public int MinQty { get; set; } = 0;
    }
}

