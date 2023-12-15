using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Orders: IEntity
    {
        [Key]
        public int Id { get; init; }
        public string Name { get; set; }
        public int OrderTypeId { get; set; }
        public int OrderStatusId { get; set; }
        public DateTime TimeCreate { get; set; }

        [ForeignKey("OrderTypeId")]
        public OrderTypes OrderTypes { get; set; }
        [ForeignKey("OrderStatusId")]
        public OrderStatuses OrderStatuses { get; set; }
    }
}
