#pragma checksum "F:\KNU\ООКП (Об'єктно-орієнтоване конструювання програм)\Лабораторні роботи\SportsClub\SportsClub\Views\Shared\_NotificationPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "da83382bd267ebeaa0df3affce743bd784d0eda5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__NotificationPartial), @"mvc.1.0.view", @"/Views/Shared/_NotificationPartial.cshtml")]
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
#line 1 "F:\KNU\ООКП (Об'єктно-орієнтоване конструювання програм)\Лабораторні роботи\SportsClub\SportsClub\Views\_ViewImports.cshtml"
using SportsClub;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\KNU\ООКП (Об'єктно-орієнтоване конструювання програм)\Лабораторні роботи\SportsClub\SportsClub\Views\_ViewImports.cshtml"
using SportsClub.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\KNU\ООКП (Об'єктно-орієнтоване конструювання програм)\Лабораторні роботи\SportsClub\SportsClub\Views\_ViewImports.cshtml"
using SportsClub.Models.Order;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\KNU\ООКП (Об'єктно-орієнтоване конструювання програм)\Лабораторні роботи\SportsClub\SportsClub\Views\_ViewImports.cshtml"
using SportsClub.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da83382bd267ebeaa0df3affce743bd784d0eda5", @"/Views/Shared/_NotificationPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2e994bb77c6d40c23d2c142d517b514ae615eeca", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__NotificationPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "F:\KNU\ООКП (Об'єктно-орієнтоване конструювання програм)\Лабораторні роботи\SportsClub\SportsClub\Views\Shared\_NotificationPartial.cshtml"
 if (TempData["Success"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"alert alert-success notification\">\r\n                ");
#nullable restore
#line 4 "F:\KNU\ООКП (Об'єктно-орієнтоване конструювання програм)\Лабораторні роботи\SportsClub\SportsClub\Views\Shared\_NotificationPartial.cshtml"
           Write(TempData["Success"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 6 "F:\KNU\ООКП (Об'єктно-орієнтоване конструювання програм)\Лабораторні роботи\SportsClub\SportsClub\Views\Shared\_NotificationPartial.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 8 "F:\KNU\ООКП (Об'єктно-орієнтоване конструювання програм)\Лабораторні роботи\SportsClub\SportsClub\Views\Shared\_NotificationPartial.cshtml"
 if (TempData["Error"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"alert alert-danger notification\">\r\n                ");
#nullable restore
#line 11 "F:\KNU\ООКП (Об'єктно-орієнтоване конструювання програм)\Лабораторні роботи\SportsClub\SportsClub\Views\Shared\_NotificationPartial.cshtml"
           Write(TempData["Error"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 13 "F:\KNU\ООКП (Об'єктно-орієнтоване конструювання програм)\Лабораторні роботи\SportsClub\SportsClub\Views\Shared\_NotificationPartial.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
