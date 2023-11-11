using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class ProductsOnShelves
    {
        public int Id { get; init; }
        public int ProductId { get; set; }
        public int ShelveId { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("ProductId")]
        public Products Products { get; set; }
        [ForeignKey("ShelveId")]
        public Shelving Shelving { get; set; }
    }
}
