using DaySpring.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Models
{
    public class Payment: BaseEntity
    {
        public string Email { get; set; }
        public bool Status { get; set; }
        public int Amount { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public DateTime CreatedAt { get; set; }
        public string PaymentReference { get; set; }
        public int PaymentCategoryId { get; set; }
        public PaymentCategory PaymentCategory { get; set; }
    }
}
