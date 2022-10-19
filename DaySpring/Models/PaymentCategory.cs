using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Models
{
    public class PaymentCategory:BaseEntity
    {
        public string Name { get; set; }
        public List<PaymentCategory> paymentCategories { get; set; } = new List<PaymentCategory>();
    }
}
