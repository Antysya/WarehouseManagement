using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class OrderTypes
    {
        public int Id { get; init; }
        public string Name { get; set; }

        public ICollection<Orders> Orders { get; set; }
    }
}
