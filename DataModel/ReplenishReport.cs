using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class ReplenishReport
    {
        public string Product { get; set; }
        public string Code { get; set; }
        public string Group { get; set; }
        public string Status { get; set; }
        public int MinimumStock { get; set; }
        public int Quantity { get; set; }
    }
}
