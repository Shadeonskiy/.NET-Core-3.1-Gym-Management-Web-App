#pragma checksum "F:\KNU\ООКП (Об'єктно-орієнтоване конструювання програм)\Лабораторні роботи\SportsClub\SportsClub\Areas\Admin\Views\Roles\UserList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "494ac9b49d7b2bceace0cb9db253c01ccf6375fb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Roles_UserList), @"mvc.1.0.view", @"/Areas/Admin/Views/Roles/UserList.cshtml")]
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
#line 1 "F:\KNU\ООКП (Об'єктно-орієнтоване конструювання програм)\Лабораторні роботи\SportsClub\SportsClub\Areas\Admin\Views\_ViewImports.cshtml"
using SportsClub;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\KNU\ООКП (Об'єктно-орієнтоване конструювання програм)\Лабораторні роботи\SportsClub\SportsClub\Areas\Admin\Views\_ViewImports.cshtml"
using SportsClub.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\KNU\ООКП (Об'єктно-орієнтоване конструювання програм)\Лабораторні роботи\SportsClub\SportsClub\Areas\Admin\Views\_ViewImports.cshtml"
using SportsClub.Models.Order;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\KNU\ООКП (Об'єктно-орієнтоване конструювання програм)\Лабораторні роботи\SportsClub\SportsClub\Areas\Admin\Views\_ViewImports.cshtml"
using SportsClub.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"494ac9b49d7b2bceace0cb9db253c01ccf6375fb", @"/Areas/Admin/Views/Roles/UserList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2e994bb77c6d40c23d2c142d517b514ae615eeca", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Roles_UserList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SportsClub.Areas.Identity.Data.AppUser>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "F:\KNU\ООКП (Об'єктно-орієнтоване конструювання програм)\Лабораторні роботи\SportsClub\SportsClub\Areas\Admin\Views\Roles\UserList.cshtml"
  
    ViewData["Title"] = "Перелік користувачів";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<h2>");
#nullable restore
#line 8 "F:\KNU\ООКП (Об'єктно-орієнтоване конструювання програм)\Лабораторні роботи\SportsClub\SportsClub\Areas\Admin\Views\Roles\UserList.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<table class=\"table\">\r\n");
#nullable restore
#line 10 "F:\KNU\ООКП (Об'єктно-орієнтоване конструювання програм)\Лабораторні роботи\SportsClub\SportsClub\Areas\Admin\Views\Roles\UserList.cshtml"
     foreach (var user in Model)
	{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t<tr>\r\n\t\t\t<td>");
#nullable restore
#line 13 "F:\KNU\ООКП (Об'єктно-орієнтоване конструювання програм)\Лабораторні роботи\SportsClub\SportsClub\Areas\Admin\Views\Roles\UserList.cshtml"
           Write(user.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 13 "F:\KNU\ООКП (Об'єктно-орієнтоване конструювання програм)\Лабораторні роботи\SportsClub\SportsClub\Areas\Admin\Views\Roles\UserList.cshtml"
                           Write(user.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t<td>");
#nullable restore
#line 14 "F:\KNU\ООКП (Об'єктно-орієнтоване конструювання програм)\Лабораторні роботи\SportsClub\SportsClub\Areas\Admin\Views\Roles\UserList.cshtml"
           Write(user.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t<td>\r\n\t\t\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "494ac9b49d7b2bceace0cb9db253c01ccf6375fb6407", async() => {
                WriteLiteral("Права доступу");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-userid", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 16 "F:\KNU\ООКП (Об'єктно-орієнтоване конструювання програм)\Лабораторні роботи\SportsClub\SportsClub\Areas\Admin\Views\Roles\UserList.cshtml"
                                                                          WriteLiteral(user.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["userid"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-userid", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["userid"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\t\t\t</td>\r\n\t\t</tr>\r\n");
#nullable restore
#line 19 "F:\KNU\ООКП (Об'єктно-орієнтоване конструювання програм)\Лабораторні роботи\SportsClub\SportsClub\Areas\Admin\Views\Roles\UserList.cshtml"
	}

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n<div class=\"form-group\">\r\n\t<p>\r\n\t\t<b>\r\n\t\t\tTotal Users till ");
#nullable restore
#line 24 "F:\KNU\ООКП (Об'єктно-орієнтоване конструювання програм)\Лабораторні роботи\SportsClub\SportsClub\Areas\Admin\Views\Roles\UserList.cshtml"
                        Write(String.Format("{0 : dddd, MMMM d, yyyy}", DateTime.Now));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t:\r\n\t\t</b><span class=\"label label-primary\">");
#nullable restore
#line 26 "F:\KNU\ООКП (Об'єктно-орієнтоване конструювання програм)\Лабораторні роботи\SportsClub\SportsClub\Areas\Admin\Views\Roles\UserList.cshtml"
                                         Write(Model.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n\t</p>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SportsClub.Areas.Identity.Data.AppUser>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591