#pragma checksum "C:\Projetos Pessoais\LojaVirtual\LojaVirtual\Areas\Colaborador\Views\Categoria\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0a9275f5c5543cafd6f951303124ad5429900965"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Colaborador_Views_Categoria_Index), @"mvc.1.0.view", @"/Areas/Colaborador/Views/Categoria/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Colaborador/Views/Categoria/Index.cshtml", typeof(AspNetCore.Areas_Colaborador_Views_Categoria_Index))]
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
#line 2 "C:\Projetos Pessoais\LojaVirtual\LojaVirtual\Areas\Colaborador\Views\_ViewImports.cshtml"
using LojaVirtual.Models;

#line default
#line hidden
#line 3 "C:\Projetos Pessoais\LojaVirtual\LojaVirtual\Areas\Colaborador\Views\_ViewImports.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#line 4 "C:\Projetos Pessoais\LojaVirtual\LojaVirtual\Areas\Colaborador\Views\_ViewImports.cshtml"
using X.PagedList;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a9275f5c5543cafd6f951303124ad5429900965", @"/Areas/Colaborador/Views/Categoria/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90799275c998573c5584c7fde9507bc8004803f8", @"/Areas/Colaborador/Views/_ViewImports.cshtml")]
    public class Areas_Colaborador_Views_Categoria_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<X.PagedList.IPagedList<LojaVirtual.Models.Categoria>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Projetos Pessoais\LojaVirtual\LojaVirtual\Areas\Colaborador\Views\Categoria\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(102, 20, true);
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n");
            EndContext();
#line 8 "C:\Projetos Pessoais\LojaVirtual\LojaVirtual\Areas\Colaborador\Views\Categoria\Index.cshtml"
 foreach(Categoria categoria in Model)
{
    

#line default
#line hidden
            BeginContext(170, 14, false);
#line 10 "C:\Projetos Pessoais\LojaVirtual\LojaVirtual\Areas\Colaborador\Views\Categoria\Index.cshtml"
Write(categoria.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(184, 8, true);
            WriteLiteral("<br />\r\n");
            EndContext();
#line 11 "C:\Projetos Pessoais\LojaVirtual\LojaVirtual\Areas\Colaborador\Views\Categoria\Index.cshtml"
}

#line default
#line hidden
            BeginContext(196, 85, false);
#line 12 "C:\Projetos Pessoais\LojaVirtual\LojaVirtual\Areas\Colaborador\Views\Categoria\Index.cshtml"
Write(Html.PagedListPager((IPagedList)Model, pagina => Url.Action("Index", new { pagina })));

#line default
#line hidden
            EndContext();
            BeginContext(281, 2, true);
            WriteLiteral("\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<X.PagedList.IPagedList<LojaVirtual.Models.Categoria>> Html { get; private set; }
    }
}
#pragma warning restore 1591