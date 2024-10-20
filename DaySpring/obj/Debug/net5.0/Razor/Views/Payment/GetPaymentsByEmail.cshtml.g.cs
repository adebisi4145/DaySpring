#pragma checksum "C:\Users\dzumi\source\repos\DaySpring\DaySpring\Views\Payment\GetPaymentsByEmail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "340fb9a8bda44d26da346d6769759565a04534e4"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"340fb9a8bda44d26da346d6769759565a04534e4", @"/Views/Payment/GetPaymentsByEmail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ecd1b4a0891021d69e73dd3f3e1269ab7f070957", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Payment_GetPaymentsByEmail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DaySpring.ViewModels.MembersPaymentViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Member", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
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
            WriteLiteral("\r\n<div class=\"card-header\" style=\"background-color: whitesmoke;\">\r\n    <div class=\"card-title\">\r\n        <h1 class=\"text-center\">");
#nullable restore
#line 10 "C:\Users\dzumi\source\repos\DaySpring\DaySpring\Views\Payment\GetPaymentsByEmail.cshtml"
                           Write(Model.Member.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 10 "C:\Users\dzumi\source\repos\DaySpring\DaySpring\Views\Payment\GetPaymentsByEmail.cshtml"
                                                  Write(Model.Member.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\'s Payments</h1>\r\n    </div>\r\n</div>\r\n");
#nullable restore
#line 13 "C:\Users\dzumi\source\repos\DaySpring\DaySpring\Views\Payment\GetPaymentsByEmail.cshtml"
 if (!string.IsNullOrEmpty(ViewBag.Message))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p class=\"alert alert-warning alert-dismissible\" role=\"alert\">");
#nullable restore
#line 15 "C:\Users\dzumi\source\repos\DaySpring\DaySpring\Views\Payment\GetPaymentsByEmail.cshtml"
                                                             Write(ViewBag.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 16 "C:\Users\dzumi\source\repos\DaySpring\DaySpring\Views\Payment\GetPaymentsByEmail.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <table class=""table"">
        <thead>
            <tr>
                <th>
                    Date
                </th>
                <th>
                    Details
                </th>
                <th>
                    Amount
                </th>
                <th>
                    Transaction Reference
                </th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 37 "C:\Users\dzumi\source\repos\DaySpring\DaySpring\Views\Payment\GetPaymentsByEmail.cshtml"
             foreach (var transation in Model.Payments)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 41 "C:\Users\dzumi\source\repos\DaySpring\DaySpring\Views\Payment\GetPaymentsByEmail.cshtml"
                   Write(Html.DisplayFor(modelItem => transation.CreatedAt));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 44 "C:\Users\dzumi\source\repos\DaySpring\DaySpring\Views\Payment\GetPaymentsByEmail.cshtml"
                   Write(Html.DisplayFor(modelItem => transation.PaymentCategory.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 47 "C:\Users\dzumi\source\repos\DaySpring\DaySpring\Views\Payment\GetPaymentsByEmail.cshtml"
                   Write(Html.DisplayFor(modelItem => transation.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 50 "C:\Users\dzumi\source\repos\DaySpring\DaySpring\Views\Payment\GetPaymentsByEmail.cshtml"
                   Write(Html.DisplayFor(modelItem => transation.PaymentReference));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 53 "C:\Users\dzumi\source\repos\DaySpring\DaySpring\Views\Payment\GetPaymentsByEmail.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 56 "C:\Users\dzumi\source\repos\DaySpring\DaySpring\Views\Payment\GetPaymentsByEmail.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<button class=\"btn offset-9\" style=\"background-color: #202342; color: black; font-size: 2rem;\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "340fb9a8bda44d26da346d6769759565a04534e48436", async() => {
                WriteLiteral("Back");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</button>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DaySpring.ViewModels.MembersPaymentViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
