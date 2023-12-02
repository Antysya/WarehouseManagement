using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class ProductsInOrders : IEntity
    {
        public int Id { get; init; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public int StatusId { get; set; }

        [ForeignKey("ProductId")]
        public Products Products { get; set; }
        [ForeignKey("OrderId")]
        public Orders Orders { get; set; }
        [ForeignKey("StatusId")]
        public ProductStatusInOrder ProductStatusInOrder { get; set; }

    }
}
