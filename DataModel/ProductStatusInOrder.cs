using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class ProductStatusInOrder : IEntity
    {
        public int Id { get; init; }
        public string Name { get; set; }
    }
}
