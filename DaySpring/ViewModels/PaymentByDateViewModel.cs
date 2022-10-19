using DaySpring.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.ViewModels
{
    public class PaymentByDateViewmodel
    {
        public List<PaymentModel> Payments { get; set; }
        public double TotalAmount { get; set; }
    }
}
