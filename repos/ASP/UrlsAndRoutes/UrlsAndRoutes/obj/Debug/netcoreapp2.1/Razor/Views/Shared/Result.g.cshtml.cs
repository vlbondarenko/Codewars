#pragma checksum "C:\Users\VIP\source\repos\UrlsAndRoutes\UrlsAndRoutes\Views\Shared\Result.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c005b0e403b911e52242dbf00d601608a58fbff9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Result), @"mvc.1.0.view", @"/Views/Shared/Result.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Result.cshtml", typeof(AspNetCore.Views_Shared_Result))]
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
#line 1 "C:\Users\VIP\source\repos\UrlsAndRoutes\UrlsAndRoutes\Views\_ViewImports.cshtml"
using UrlsAndRoutes.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c005b0e403b911e52242dbf00d601608a58fbff9", @"/Views/Shared/Result.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"addc3bd70a18d70a9493811fbea41d66327b5a3f", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Result : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Result>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-href-include", "lib/bootstrap/dist/css/*.min.css", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("panel-body"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\VIP\source\repos\UrlsAndRoutes\UrlsAndRoutes\Views\Shared\Result.cshtml"
  
    Layout = null;

#line default
#line hidden
            BeginContext(42, 25, true);
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            EndContext();
            BeginContext(67, 184, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "22133e0faa9a4517b6d61904e0c890ae", async() => {
                BeginContext(73, 92, true);
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\"/>\r\n    <title>Routing</title>\r\n    ");
                EndContext();
                BeginContext(165, 77, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6a163ad0dd9948efb83d61b4037d6628", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.HrefInclude = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(242, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(251, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(253, 365, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0125439986fe4faf8e7974f7a5acd863", async() => {
                BeginContext(278, 110, true);
                WriteLiteral("\r\n    <table class=\"table table-bordered table-striped table-condensed\">\r\n        <tr><th>Controller:</th><th>");
                EndContext();
                BeginContext(389, 16, false);
#line 14 "C:\Users\VIP\source\repos\UrlsAndRoutes\UrlsAndRoutes\Views\Shared\Result.cshtml"
                               Write(Model.Controller);

#line default
#line hidden
                EndContext();
                BeginContext(405, 44, true);
                WriteLiteral("</th></tr>\r\n        <tr><th>Action:</th><th>");
                EndContext();
                BeginContext(450, 12, false);
#line 15 "C:\Users\VIP\source\repos\UrlsAndRoutes\UrlsAndRoutes\Views\Shared\Result.cshtml"
                           Write(Model.Action);

#line default
#line hidden
                EndContext();
                BeginContext(462, 12, true);
                WriteLiteral("</th></tr>\r\n");
                EndContext();
#line 16 "C:\Users\VIP\source\repos\UrlsAndRoutes\UrlsAndRoutes\Views\Shared\Result.cshtml"
         foreach(string key in Model.Data.Keys){ 

#line default
#line hidden
                BeginContext(525, 20, true);
                WriteLiteral("            <tr><th>");
                EndContext();
                BeginContext(546, 3, false);
#line 17 "C:\Users\VIP\source\repos\UrlsAndRoutes\UrlsAndRoutes\Views\Shared\Result.cshtml"
               Write(key);

#line default
#line hidden
                EndContext();
                BeginContext(549, 9, true);
                WriteLiteral("</th><th>");
                EndContext();
                BeginContext(559, 15, false);
#line 17 "C:\Users\VIP\source\repos\UrlsAndRoutes\UrlsAndRoutes\Views\Shared\Result.cshtml"
                            Write(Model.Data[key]);

#line default
#line hidden
                EndContext();
                BeginContext(574, 12, true);
                WriteLiteral("</th></tr>\r\n");
                EndContext();
#line 18 "C:\Users\VIP\source\repos\UrlsAndRoutes\UrlsAndRoutes\Views\Shared\Result.cshtml"
        }

#line default
#line hidden
                BeginContext(597, 14, true);
                WriteLiteral("    </table>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(618, 17, true);
            WriteLiteral("\r\n</html>\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Result> Html { get; private set; }
    }
}
#pragma warning restore 1591