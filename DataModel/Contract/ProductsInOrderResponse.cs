using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Contract
{
    public class ProductsInOrderResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        public int OrderId { get; set; }
    }
}
