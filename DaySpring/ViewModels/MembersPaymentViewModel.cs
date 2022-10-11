
using DaySpring.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.ViewModels
{
    public class MembersPaymentViewModel
    {
        public MemberModel Member { get; set; }
        public List<PaymentModel> Payments { get; set; }
    }
}
