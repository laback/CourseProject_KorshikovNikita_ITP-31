#pragma checksum "D:\Учёба\РПБДИС\Курсач\CourseProject_KorshikovNikita_ITP-31\RailroadTransport\RailroadTransport\Views\Staff\ShowTable.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f8e4cee77e543f13e6edce5e00742be10164e15b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Staff_ShowTable), @"mvc.1.0.view", @"/Views/Staff/ShowTable.cshtml")]
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
#line 1 "D:\Учёба\РПБДИС\Курсач\CourseProject_KorshikovNikita_ITP-31\RailroadTransport\RailroadTransport\Views\_ViewImports.cshtml"
using RailroadTransport;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Учёба\РПБДИС\Курсач\CourseProject_KorshikovNikita_ITP-31\RailroadTransport\RailroadTransport\Views\_ViewImports.cshtml"
using RailroadTransport.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f8e4cee77e543f13e6edce5e00742be10164e15b", @"/Views/Staff/ShowTable.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4078f067edbd6ca7655b0d7f8e242710471c560b", @"/Views/_ViewImports.cshtml")]
    public class Views_Staff_ShowTable : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<RailroadTransport.Models.Staff>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Учёба\РПБДИС\Курсач\CourseProject_KorshikovNikita_ITP-31\RailroadTransport\RailroadTransport\Views\Staff\ShowTable.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div>
    <h3>Распродажа книг</h3>
    <table>
        <tr class=""header"">
            <td><p>Номер сотрудника</p></td>
            <td><p>ФИО</p></td>
            <td><p>Возраст</p></td>
            <td><p>Стаж</p></td>
            <td><p>Название должности</p></td>
            <td><p>Номер поезда</p></td>
            <td></td>
        </tr>
");
#nullable restore
#line 18 "D:\Учёба\РПБДИС\Курсач\CourseProject_KorshikovNikita_ITP-31\RailroadTransport\RailroadTransport\Views\Staff\ShowTable.cshtml"
         foreach (var s in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td><p>");
#nullable restore
#line 21 "D:\Учёба\РПБДИС\Курсач\CourseProject_KorshikovNikita_ITP-31\RailroadTransport\RailroadTransport\Views\Staff\ShowTable.cshtml"
                  Write(s.StaffId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p></td>\r\n                <td><p>");
#nullable restore
#line 22 "D:\Учёба\РПБДИС\Курсач\CourseProject_KorshikovNikita_ITP-31\RailroadTransport\RailroadTransport\Views\Staff\ShowTable.cshtml"
                  Write(s.FIO);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p></td>\r\n                <td><p>");
#nullable restore
#line 23 "D:\Учёба\РПБДИС\Курсач\CourseProject_KorshikovNikita_ITP-31\RailroadTransport\RailroadTransport\Views\Staff\ShowTable.cshtml"
                  Write(s.Age);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p></td>\r\n                <td><p>");
#nullable restore
#line 24 "D:\Учёба\РПБДИС\Курсач\CourseProject_KorshikovNikita_ITP-31\RailroadTransport\RailroadTransport\Views\Staff\ShowTable.cshtml"
                  Write(s.WorkExp);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p></td>\r\n                <td><p>");
#nullable restore
#line 25 "D:\Учёба\РПБДИС\Курсач\CourseProject_KorshikovNikita_ITP-31\RailroadTransport\RailroadTransport\Views\Staff\ShowTable.cshtml"
                  Write(s.Post.NameOfPost);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p></td>\r\n                <td><p>");
#nullable restore
#line 26 "D:\Учёба\РПБДИС\Курсач\CourseProject_KorshikovNikita_ITP-31\RailroadTransport\RailroadTransport\Views\Staff\ShowTable.cshtml"
                  Write(s.TrainId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p></td>\r\n            </tr>\r\n");
#nullable restore
#line 28 "D:\Учёба\РПБДИС\Курсач\CourseProject_KorshikovNikita_ITP-31\RailroadTransport\RailroadTransport\Views\Staff\ShowTable.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<RailroadTransport.Models.Staff>> Html { get; private set; }
    }
}
#pragma warning restore 1591
