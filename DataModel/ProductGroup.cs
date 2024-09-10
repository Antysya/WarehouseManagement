using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class ProductGroup : IEntity
    {
        [Key]
        public int Id { get; init; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
