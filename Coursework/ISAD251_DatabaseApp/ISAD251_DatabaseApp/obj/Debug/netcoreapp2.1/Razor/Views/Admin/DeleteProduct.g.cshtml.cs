#pragma checksum "C:\Users\Johnny\Documents\Homework\Uni\Isad 251\Coursework\ISAD251_DatabaseApp\ISAD251_DatabaseApp\Views\Admin\DeleteProduct.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9f0f2a88472a1120fd8aee20bd4e5685dabad53c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_DeleteProduct), @"mvc.1.0.view", @"/Views/Admin/DeleteProduct.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/DeleteProduct.cshtml", typeof(AspNetCore.Views_Admin_DeleteProduct))]
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
#line 1 "C:\Users\Johnny\Documents\Homework\Uni\Isad 251\Coursework\ISAD251_DatabaseApp\ISAD251_DatabaseApp\Views\_ViewImports.cshtml"
using ISAD251_DatabaseApp;

#line default
#line hidden
#line 2 "C:\Users\Johnny\Documents\Homework\Uni\Isad 251\Coursework\ISAD251_DatabaseApp\ISAD251_DatabaseApp\Views\_ViewImports.cshtml"
using ISAD251_DatabaseApp.Models;

#line default
#line hidden
#line 3 "C:\Users\Johnny\Documents\Homework\Uni\Isad 251\Coursework\ISAD251_DatabaseApp\ISAD251_DatabaseApp\Views\_ViewImports.cshtml"
using ISAD251_DatabaseApp.Data.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f0f2a88472a1120fd8aee20bd4e5685dabad53c", @"/Views/Admin/DeleteProduct.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c989de5ecae65a579b62d513d87c589f4d06da4", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_DeleteProduct : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ISAD251_DatabaseApp.Models.CafeProducts>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("margin"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteProduct", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(48, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Johnny\Documents\Homework\Uni\Isad 251\Coursework\ISAD251_DatabaseApp\ISAD251_DatabaseApp\Views\Admin\DeleteProduct.cshtml"
  
    ViewData["Title"] = "DeleteProduct";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
            BeginContext(151, 153, true);
            WriteLiteral("\r\n<h2>Delete Product</h2>\r\n\r\n<div>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            Type\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(305, 43, false);
#line 17 "C:\Users\Johnny\Documents\Homework\Uni\Isad 251\Coursework\ISAD251_DatabaseApp\ISAD251_DatabaseApp\Views\Admin\DeleteProduct.cshtml"
       Write(Html.DisplayFor(model => model.ProductType));

#line default
#line hidden
            EndContext();
            BeginContext(348, 91, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            Price\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(440, 44, false);
#line 23 "C:\Users\Johnny\Documents\Homework\Uni\Isad 251\Coursework\ISAD251_DatabaseApp\ISAD251_DatabaseApp\Views\Admin\DeleteProduct.cshtml"
       Write(Html.DisplayFor(model => model.ProductPrice));

#line default
#line hidden
            EndContext();
            BeginContext(484, 90, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            Name\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(575, 43, false);
#line 29 "C:\Users\Johnny\Documents\Homework\Uni\Isad 251\Coursework\ISAD251_DatabaseApp\ISAD251_DatabaseApp\Views\Admin\DeleteProduct.cshtml"
       Write(Html.DisplayFor(model => model.ProductName));

#line default
#line hidden
            EndContext();
            BeginContext(618, 94, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            Calories\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(713, 47, false);
#line 35 "C:\Users\Johnny\Documents\Homework\Uni\Isad 251\Coursework\ISAD251_DatabaseApp\ISAD251_DatabaseApp\Views\Admin\DeleteProduct.cshtml"
       Write(Html.DisplayFor(model => model.ProductCalories));

#line default
#line hidden
            EndContext();
            BeginContext(760, 93, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            Details\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(854, 46, false);
#line 41 "C:\Users\Johnny\Documents\Homework\Uni\Isad 251\Coursework\ISAD251_DatabaseApp\ISAD251_DatabaseApp\Views\Admin\DeleteProduct.cshtml"
       Write(Html.DisplayFor(model => model.ProductDetails));

#line default
#line hidden
            EndContext();
            BeginContext(900, 91, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            Image\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(992, 44, false);
#line 47 "C:\Users\Johnny\Documents\Homework\Uni\Isad 251\Coursework\ISAD251_DatabaseApp\ISAD251_DatabaseApp\Views\Admin\DeleteProduct.cshtml"
       Write(Html.DisplayFor(model => model.ProductImage));

#line default
#line hidden
            EndContext();
            BeginContext(1036, 34, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n\r\n    ");
            EndContext();
            BeginContext(1070, 316, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "98187fec1b554ecc9601bfb3b0dd7edf", async() => {
                BeginContext(1138, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(1148, 43, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5f68b9b584d04b419e9ccbfda70c0c9d", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 52 "C:\Users\Johnny\Documents\Homework\Uni\Isad 251\Coursework\ISAD251_DatabaseApp\ISAD251_DatabaseApp\Views\Admin\DeleteProduct.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ProductId);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1191, 92, true);
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Delete Product\" class=\"btn btn-default\" /> |\r\n        ");
                EndContext();
                BeginContext(1283, 90, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1f22af790de0423d88c0ecd8366205aa", async() => {
                    BeginContext(1357, 12, true);
                    WriteLiteral("Back to List");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1373, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1386, 12, true);
            WriteLiteral("\r\n</div>\r\n\r\n");
            EndContext();
#line 58 "C:\Users\Johnny\Documents\Homework\Uni\Isad 251\Coursework\ISAD251_DatabaseApp\ISAD251_DatabaseApp\Views\Admin\DeleteProduct.cshtml"
  
    if (ViewBag.success == true)
    {

#line default
#line hidden
            BeginContext(1443, 297, true);
            WriteLiteral(@"        <div class=""row margin"">
            <div class=""col-sm-2"">
                <div class=""card bg-success mb-3"">
                    <div class=""card-header bg-success text-center text-white"">Product successfully deleted</div>
                </div>
            </div>
        </div>
");
            EndContext();
#line 68 "C:\Users\Johnny\Documents\Homework\Uni\Isad 251\Coursework\ISAD251_DatabaseApp\ISAD251_DatabaseApp\Views\Admin\DeleteProduct.cshtml"
    }
    else if (ViewBag.success == false)
    {

#line default
#line hidden
            BeginContext(1794, 316, true);
            WriteLiteral(@"        <div class=""row margin"">
            <div class=""col-sm-2"">
                <div class=""card bg-success mb-3"">
                    <div class=""card-header bg-danger text-center text-white"">Product can't be deleted as it is used in orders</div>
                </div>
            </div>
        </div>
");
            EndContext();
#line 78 "C:\Users\Johnny\Documents\Homework\Uni\Isad 251\Coursework\ISAD251_DatabaseApp\ISAD251_DatabaseApp\Views\Admin\DeleteProduct.cshtml"
    }

#line default
#line hidden
            BeginContext(2120, 2, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ISAD251_DatabaseApp.Models.CafeProducts> Html { get; private set; }
    }
}
#pragma warning restore 1591
