using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class ProductStatuses : IEntity
    {
        public int Id { get; init; }
        public string Name { get; set; }
    }
}
