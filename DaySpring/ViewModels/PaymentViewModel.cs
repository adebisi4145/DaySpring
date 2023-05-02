using DaySpring.Dtos;
using DaySpring.Enums;
using DaySpring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.ViewModels
{
    public class CreatePaymentRequestModel
    {
        public int Amount { get; set; }
        public int PaymentCategoryId { get; set; }
    }

    public class PaymentResponseModel : BaseResponse
    {
        public PaymentModel Data { get; set; }
    }

    public class PaymentsResponseModel : BaseResponse
    {
        public List<PaymentModel> Data { get; set; }
    }
}
