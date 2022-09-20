using DaySpring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Dtos
{
    public class UserModel: BaseEntity
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public List<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
