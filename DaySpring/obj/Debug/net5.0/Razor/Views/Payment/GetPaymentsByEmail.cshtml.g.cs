#pragma checksum "C:\Users\dzumi\source\repos\DaySpring\DaySpring\Views\Payment\GetPaymentsByEmail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eca2fa3715625752fb6fc2ab76e0016c1ddb1450"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Payment_GetPaymentsByEmail), @"mvc.1.0.view", @"/Views/Payment/GetPaymentsByEmail.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\dzumi\source\repos\DaySpring\DaySpring\Views\_ViewImports.cshtml"
using DaySpring;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\dzumi\source\repos\DaySpring\DaySpring\Views\_ViewImports.cshtml"
using DaySpring.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eca2fa3715625752fb6fc2ab76e0016c1ddb1450", @"/Views/Payment/GetPaymentsByEmail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ecd1b4a0891021d69e73dd3f3e1269ab7f070957", @"/Views/_ViewImports.cshtml")]
    public class Views_Payment_GetPaymentsByEmail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DaySpring.ViewModels.PaymentsResponseModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\dzumi\source\repos\DaySpring\DaySpring\Views\Payment\GetPaymentsByEmail.cshtml"
  
    Layout = "~/Views/Shared/_MemberLayout.cshtml";
    ViewData["Title"] = "GetPaymentsByEmail";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"card-header\" style=\"background-color: whitesmoke;\">\r\n    <div class=\"card-title\">\r\n        <h1 class=\"text-center\">My Payments</h1>\r\n    </div>\r\n</div>\r\n");
            WriteLiteral(@"<table class=""table"">
    <thead>
        <tr>
            <th>
                Amount
            </th>
            <th>
                Transaction Reference
            </th>
            <th>
                Details
            </th>
            <th>
                Date
            </th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 32 "C:\Users\dzumi\source\repos\DaySpring\DaySpring\Views\Payment\GetPaymentsByEmail.cshtml"
         foreach (var transation in Model.Data)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 36 "C:\Users\dzumi\source\repos\DaySpring\DaySpring\Views\Payment\GetPaymentsByEmail.cshtml"
               Write(Html.DisplayFor(modelItem => transation.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 39 "C:\Users\dzumi\source\repos\DaySpring\DaySpring\Views\Payment\GetPaymentsByEmail.cshtml"
               Write(Html.DisplayFor(modelItem => transation.PaymentReference));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 42 "C:\Users\dzumi\source\repos\DaySpring\DaySpring\Views\Payment\GetPaymentsByEmail.cshtml"
               Write(Html.DisplayFor(modelItem => transation.PaymentType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 45 "C:\Users\dzumi\source\repos\DaySpring\DaySpring\Views\Payment\GetPaymentsByEmail.cshtml"
               Write(Html.DisplayFor(modelItem => transation.CreatedAt));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 48 "C:\Users\dzumi\source\repos\DaySpring\DaySpring\Views\Payment\GetPaymentsByEmail.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DaySpring.ViewModels.PaymentsResponseModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
