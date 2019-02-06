#pragma checksum "C:\Users\Exia\source\repos\BlogApp\Web\Views\Home\ViewArticles.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e0e20deb9b4735238a87f3bc895cb670962fe5bb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ViewArticles), @"mvc.1.0.view", @"/Views/Home/ViewArticles.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/ViewArticles.cshtml", typeof(AspNetCore.Views_Home_ViewArticles))]
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
#line 1 "C:\Users\Exia\source\repos\BlogApp\Web\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#line 2 "C:\Users\Exia\source\repos\BlogApp\Web\Views\_ViewImports.cshtml"
using Web.Models;

#line default
#line hidden
#line 3 "C:\Users\Exia\source\repos\BlogApp\Web\Views\_ViewImports.cshtml"
using BlogApp.BlogModels;

#line default
#line hidden
#line 4 "C:\Users\Exia\source\repos\BlogApp\Web\Views\_ViewImports.cshtml"
using BlogApp.UserModels;

#line default
#line hidden
#line 5 "C:\Users\Exia\source\repos\BlogApp\Web\Views\_ViewImports.cshtml"
using Web.ViewModels.BlogArticle;

#line default
#line hidden
#line 6 "C:\Users\Exia\source\repos\BlogApp\Web\Views\_ViewImports.cshtml"
using Web.ViewModels.Account;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0e20deb9b4735238a87f3bc895cb670962fe5bb", @"/Views/Home/ViewArticles.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6c02eaa8a47e688642cc07acac649023dc54230c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ViewArticles : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BlogArticle>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "BlogArticle", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(33, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Exia\source\repos\BlogApp\Web\Views\Home\ViewArticles.cshtml"
  
    ViewData["Title"] = "ViewArticles";

#line default
#line hidden
            BeginContext(83, 34, true);
            WriteLiteral("\r\n<h2>ViewArticles</h2>\r\n\r\n<div>\r\n");
            EndContext();
#line 10 "C:\Users\Exia\source\repos\BlogApp\Web\Views\Home\ViewArticles.cshtml"
     foreach (var blogArticle in Model)
    {

#line default
#line hidden
            BeginContext(165, 22, true);
            WriteLiteral("    <div>\r\n        <p>");
            EndContext();
            BeginContext(188, 16, false);
#line 13 "C:\Users\Exia\source\repos\BlogApp\Web\Views\Home\ViewArticles.cshtml"
      Write(blogArticle.Name);

#line default
#line hidden
            EndContext();
            BeginContext(204, 3, true);
            WriteLiteral(" - ");
            EndContext();
            BeginContext(208, 24, false);
#line 13 "C:\Users\Exia\source\repos\BlogApp\Web\Views\Home\ViewArticles.cshtml"
                          Write(blogArticle.CreationDate);

#line default
#line hidden
            EndContext();
            BeginContext(232, 19, true);
            WriteLiteral("</p>\r\n        <p>\r\n");
            EndContext();
#line 15 "C:\Users\Exia\source\repos\BlogApp\Web\Views\Home\ViewArticles.cshtml"
             foreach (var tag in blogArticle.Tags)
            {

#line default
#line hidden
            BeginContext(318, 16, true);
            WriteLiteral("                ");
            EndContext();
            BeginContext(336, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(338, 8, false);
#line 17 "C:\Users\Exia\source\repos\BlogApp\Web\Views\Home\ViewArticles.cshtml"
              Write(tag.Name);

#line default
#line hidden
            EndContext();
            BeginContext(346, 8, true);
            WriteLiteral(" + \" \"\r\n");
            EndContext();
#line 18 "C:\Users\Exia\source\repos\BlogApp\Web\Views\Home\ViewArticles.cshtml"
            }

#line default
#line hidden
            BeginContext(369, 25, true);
            WriteLiteral("        </p>\r\n        <p>");
            EndContext();
            BeginContext(394, 95, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ad1a86367ea34b0bac9bfdb20341ee64", async() => {
                BeginContext(478, 7, true);
                WriteLiteral("Details");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 20 "C:\Users\Exia\source\repos\BlogApp\Web\Views\Home\ViewArticles.cshtml"
                                                                  WriteLiteral(blogArticle.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(489, 18, true);
            WriteLiteral("</p>\r\n    </div>\r\n");
            EndContext();
#line 22 "C:\Users\Exia\source\repos\BlogApp\Web\Views\Home\ViewArticles.cshtml"
    }

#line default
#line hidden
            BeginContext(514, 6, true);
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BlogArticle>> Html { get; private set; }
    }
}
#pragma warning restore 1591
