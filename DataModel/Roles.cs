using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Roles:IEntity
    {
        [Key]
        public int Id { get; init; }
        public string Name { get; set; }

        [InverseProperty("Role")]
        public ICollection<Users> Users { get; set; }
    }
}
