#pragma checksum "C:\Users\dzumi\source\repos\DaySpring\DaySpring\Views\Payment\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b853301983587b01c75f9537fc91c14ad109f027"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Payment_Index), @"mvc.1.0.view", @"/Views/Payment/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b853301983587b01c75f9537fc91c14ad109f027", @"/Views/Payment/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ecd1b4a0891021d69e73dd3f3e1269ab7f070957", @"/Views/_ViewImports.cshtml")]
    public class Views_Payment_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DaySpring.ViewModels.PaymentsResponseModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\dzumi\source\repos\DaySpring\DaySpring\Views\Payment\Index.cshtml"
  
    Layout = "~/Views/Shared/_SuperAdminLayout.cshtml";
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"card-header\" style=\"background-color: whitesmoke;\">\r\n    <div class=\"card-title\">\r\n        <h1 class=\"text-center\">Payments</h1>\r\n    </div>\r\n</div>\r\n");
            WriteLiteral(@"<table class=""table"">
    <thead>
        <tr>
            <th>
                First Name
            </th>
            <th>
                Last Name
            </th>
            <th>
                Email
            </th>
            <th>
                Amount
            </th>
            <th>
                Payment Reference
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
#line 41 "C:\Users\dzumi\source\repos\DaySpring\DaySpring\Views\Payment\Index.cshtml"
         foreach (var transation in Model.Data)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 45 "C:\Users\dzumi\source\repos\DaySpring\DaySpring\Views\Payment\Index.cshtml"
           Write(Html.DisplayFor(modelItem => transation.Member.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 48 "C:\Users\dzumi\source\repos\DaySpring\DaySpring\Views\Payment\Index.cshtml"
           Write(Html.DisplayFor(modelItem => transation.Member.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 51 "C:\Users\dzumi\source\repos\DaySpring\DaySpring\Views\Payment\Index.cshtml"
           Write(Html.DisplayFor(modelItem => transation.Member.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 54 "C:\Users\dzumi\source\repos\DaySpring\DaySpring\Views\Payment\Index.cshtml"
           Write(Html.DisplayFor(modelItem => transation.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 57 "C:\Users\dzumi\source\repos\DaySpring\DaySpring\Views\Payment\Index.cshtml"
           Write(Html.DisplayFor(modelItem => transation.PaymentReference));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 60 "C:\Users\dzumi\source\repos\DaySpring\DaySpring\Views\Payment\Index.cshtml"
           Write(Html.DisplayFor(modelItem => transation.PaymentType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 63 "C:\Users\dzumi\source\repos\DaySpring\DaySpring\Views\Payment\Index.cshtml"
           Write(Html.DisplayFor(modelItem => transation.CreatedAt));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 66 "C:\Users\dzumi\source\repos\DaySpring\DaySpring\Views\Payment\Index.cshtml"
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