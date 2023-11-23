using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Products
    {
        public int Id { get; init; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public int BoxSize { get; set; }
        public int ProductGroupId { get; set; }
        public int ProductStatusId { get; set; }
        public int MinimumStock { get; set; }
        public int MaximumShelfLife { get; set; }

        public ICollection<ProductsInOrders> ProductsInOrders { get; set; }
        public ICollection<ProductsOnShelves> ProductsOnShelves { get; set; }
        [ForeignKey("ProductGroupId")]
        public ProductGroup ProductGroup { get; set; }
        [ForeignKey("ProductStatusId")]
        public ProductStatuses ProductStatuses { get; set; }

    }
}
