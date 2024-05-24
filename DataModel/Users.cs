using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Users : IEntity
    {
        [Key]
        public int Id { get; init; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Roles Role { get; set; }

        public Users() { }
        private Users(string login, string passwordHash, int role)
        {
            Login = login;
            PasswordHash = passwordHash;
            RoleId = role;
        }

        public static Users Create(string login, string passwordHash, int role)
        {
            return new Users(login, passwordHash, role);
        }
    }
}
