using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Models
{
    public class Member: BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
        public List<Payment> Payments { get; set; }
    }
}
