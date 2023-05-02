using DaySpring.Enums;
using DaySpring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Dtos
{
    public class PaymentModel : BaseEntity
    {
        public string Email { get; set; }
        public int Amount { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public PaymentCategory PaymentCategory { get; set; }
        public int PaymentCategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string PaymentReference { get; set; }
    }
}
